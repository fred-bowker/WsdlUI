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
using drexModel = Drexyia.WebSvc.Model;
using drexProcess = Drexyia.WebSvc.Process;
using utils = Drexyia.Utils;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_Wm : UserControl {
        drexProcess.WebSvcAsync.CancelToken _cancelToken;
        string _webSvcSrcUri;

        public uc_Wm() {
            InitializeComponent();
        }

        public void PopulateForm(string webSvcSrcUri, drexModel.WebSvcMethod webSvcMethod) {
            _webSvcSrcUri = webSvcSrcUri;
            uc_wm_request1.PopulateForm(webSvcSrcUri, webSvcMethod);
            uc_wm_response1.PopulateForm(webSvcMethod.Response.Body, "200 OK", webSvcMethod.Response.HeaderContentType);
            uc_wm_request1.OnXmlFormatError += uc_wm_request1_OnXmlFormatError;
        }
        void uc_wm_request1_OnXmlFormatError(object sender, uc_WmRequest.XmlFormatErrorEventArgs e) {

            Invoke((MethodInvoker)(() => {
                uc_log1.LogErrorMessage(e.ErrorMessage);
            }));

        }

        void tsBtnGo_Click(object sender, EventArgs e) {
            SetInProgress();

            uc_wm_response1.Clear();

            string errorMessage = uc_wm_request1.ValidateForm();
            if (errorMessage != null) {

                uc_log1.LogErrorMessage(errorMessage);
                uc_log1.LogInfoMessage("request finish");

                SetReady("request end");
                return;
            }

            drexModel.WebSvcMethod webSvcMethod = uc_wm_request1.RetrieveForm();

            //add to the list of previous uris the uri has already been validated by ValidateForm
            if (State.Instance.Mode == ProjectMode.MultipleWsdl) {
                State.Instance.ConfigPrevUrls.Add(_webSvcSrcUri, webSvcMethod.Name, webSvcMethod.ServiceURI);
            }

            CallWebSvcCallAsync(webSvcMethod);
        }

        void CallWebSvcCallAsync(drexModel.WebSvcMethod webSvcMethod) {

            utils.Logger.Instance.Log.Info("Start " + webSvcMethod.Name);

            _cancelToken = new drexProcess.WebSvcAsync.CancelToken();

            Thread thread = new Thread(() => {

                var call = new drexProcess.WebSvcAsync.Operations.CallAsyncOp(webSvcMethod, _cancelToken, State.Instance.ConfigTimeout.Timeout, State.Instance.ConfigProxy, utils.Logger.Instance.Log);
                call.OnComplete += call_OnComplete;
                call.OnWebException += call_OnWebException;
                call.OnException += call_OnException;
                call.OnCancel += call_OnCancel;
                call.OnTimeout += call_OnTimeout;
                call.Start();

            });

            //the windows forms control must be updated by a thread with single threaded appartment property
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        void call_OnException(object sender, drexProcess.WebSvcAsync.EventParams.ExceptionAsyncArgs e) {

            Invoke((MethodInvoker)(() => {

                uc_log1.LogErrorMessage(e.Message);

            }));

            SetReady("request end");
        }

        void call_OnWebException(object sender, drexProcess.WebSvcAsync.EventParams.ExceptionAsyncArgs e) {

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
        void call_OnComplete(object sender, drexProcess.WebSvcAsync.EventParams.AsyncArgsCompleteCall e) {

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

        void SetInProgress() {
            Invoke((MethodInvoker)(() => {

                uc_log1.LogInfoMessage("request start");

                uc_Status1.StatusInProgress();

                uc_wm_request1.Disable();

                tsbtn_Go.Enabled = false;
                tsbtn_Cancel.Enabled = true;

            }));
        }

        void tsbtn_Cancel_Click(object sender, EventArgs e) {
            //process.Logger.Instance.Log.Info("Start");

            _cancelToken.IsCancellationRequested = true;
        }

        private void uc_Wm_Load(object sender, EventArgs e) {

            Font = DefaultFonts.Instance.Small;

        }
    }
}
