/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Threading;
using System.Windows.Forms;

using model = WsdlUI.App.Model;
using process = WsdlUI.App.Process;
using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.UI.UserControls
{
    public partial class uc_Wm : UserControl
    {
        websvcasync.CancelToken _cancelToken;
     
        public uc_Wm()
        {             
            InitializeComponent();
        }

        public void PopulateForm(WsdlUI.App.Model.WebSvcMethod webSvcMethod)
        {
            uc_wm_request1.PopulateForm(webSvcMethod);
        }

       void tsBtnGo_Click(object sender, EventArgs e)
        {
            SetInProgress();

            uc_wm_response1.Clear();

           string errorMessage = uc_wm_request1.ValidateForm();
           if (errorMessage != null) {
                
               uc_log1.LogErrorMessage(errorMessage);
               uc_log1.LogInfoMessage("request finish");
            
                SetReady("request end");
                return;
            }

            model.WebSvcMethod webSvcMethod = uc_wm_request1.RetrieveForm();
            CallWebSvcCallAsync(webSvcMethod);       
        }

       void CallWebSvcCallAsync(model.WebSvcMethod webSvcMethod) {

           process.Logger.Instance.Log.Info("Start " + webSvcMethod.Name);

           _cancelToken = new websvcasync.CancelToken();

           Thread thread = new Thread(() => {

               var call = new websvcasync.Operations.CallAsyncOp(webSvcMethod, _cancelToken, State.Instance.ConfigProxy, AppConfig.Instance.WebSvcCallTimeout);
               call.OnComplete += call_OnComplete;
               call.OnWebException += call_OnWebException;
               call.OnCancel += call_OnCancel;
               call.OnTimeout += call_OnTimeout;
               call.Start();
           
           });

           //the windows forms control must be updated by a thread with single threaded appartment property
           thread.SetApartmentState(ApartmentState.STA);
           thread.Start();
       }

       void call_OnWebException(object sender, websvcasync.EventParams.ExceptionAsyncArgs e) {

           Invoke((MethodInvoker)(() => {

               uc_log1.LogErrorMessage(e.Message);

           }));

           SetReady("request end");

       }

       void call_OnCancel(object sender, EventArgs e) {

           SetReady("request cancelled");

       }

       void call_OnTimeout(object sender, EventArgs e) {

           Invoke((MethodInvoker)(() => {

               uc_log1.LogErrorMessage("request timed out");

    
           }));

           SetReady("request end");

       }

       //the time between the start log message and end log message may be different to the time elapsed
        //this is because the time elapsed is the time for the web service call to complete and does not include the pocessing displaying of the web service call.
       void call_OnComplete(object sender, websvcasync.EventParams.AsyncArgsCompleteCall e) {

           Invoke((MethodInvoker)(() => {

               uc_wm_response1.PopulateForm(e.Result);

           }));

           string message = "request end, time elapsed " + e.TotalTime + "ms";

           SetReady(message);
       }

       void SetReady(string message) {

           Invoke((MethodInvoker)(() => {

               uc_log1.LogInfoMessage(message);

               uc_Status1.StatusReady();

               uc_wm_request1.Enable();

               tsbtn_Go.Enabled = true;
               tsbtn_Cancel.Enabled = false;

           }));
       }

       void SetInProgress()
        {
            Invoke((MethodInvoker)(() => {

                uc_log1.LogInfoMessage("request start");

                uc_Status1.StatusInProgress();

                uc_wm_request1.Disable();

                tsbtn_Go.Enabled = false;
                tsbtn_Cancel.Enabled = true;

            }));
        }

       void tsbtn_Cancel_Click(object sender, EventArgs e)
        {
            process.Logger.Instance.Log.Info("Start");

            _cancelToken.IsCancellationRequested = true;
        }

       private void uc_Wm_Load(object sender, EventArgs e) {

           Font = DefaultFonts.Instance.Small;
          
       }
    }
}
