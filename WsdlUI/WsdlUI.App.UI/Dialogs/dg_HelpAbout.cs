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

using wsdlProcess = WsdlUI.App.Process;

namespace WsdlUI.App.UI.Dialogs {
    public partial class dg_HelpAbout : dg_BaseCancel {

        bool _formClosed = false;

        public dg_HelpAbout() {
            InitializeComponent();

            lbl_Version.Text = AppInfo.Instance.Version;
            rtb_WebSite.Text = AppInfo.Instance.WebSite;
            txt_License.Text = AppInfo.Instance.License;

            lbl_Version.Select();

            pb_Update.Minimum = 1;
            pb_Update.Value = 1;
            pb_Update.Step = 1;
            //interval of a second
            timer1.Interval = 1000;

        }

        private void txt_License_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void txt_License_TextChanged(object sender, System.EventArgs e) {
            txt_License.Undo();
            txt_License.ClearUndo();
        }

        private void dg_HelpAbout_Load(object sender, System.EventArgs e) {
            txt_License.Font = DefaultFonts.Instance.Smaller;

            pb_Update.Maximum = AppConfig.Instance.UpdateTimeout;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += timer1_Tick;

            var updateCheck = new wsdlProcess.WebSvcAsync.Operations.UpdateAsyncOp(AppConfig.Instance.UpdateUrl, AppInfo.Instance.Version, State.Instance.ConfigProxy, AppConfig.Instance.UpdateTimeout);
            updateCheck.OnComplete += updateCheck_OnComplete;
            updateCheck.OnWebException += updateCheck_OnWebException;

            Thread thread = new Thread(() =>
                updateCheck.Start()
                );
            thread.Start();
        }

        void updateCheck_OnWebException(object sender, EventArgs e) {
            timer1.Stop();
            if (_formClosed) {
                return;
            }

            this.Invoke(new MethodInvoker(delegate() {
                pb_Update.Value = pb_Update.Maximum;

                rtb_UpdateResult.Text = "An error occurred connecting to the update page";
                rtb_UpdateResult.Visible = true;
            }));
        }

        void timer1_Tick(object sender, EventArgs e) {
            if (pb_Update.Value != pb_Update.Maximum) {
                pb_Update.Value++;
            }
            else {
                timer1.Stop();
            }
        }

        void updateCheck_OnComplete(object sender, wsdlProcess.WebSvcAsync.EventParams.UpdateAsyncArgs e) {
            timer1.Stop();
            if (_formClosed) {
                return;
            }

            this.Invoke(new MethodInvoker(delegate() {

                pb_Update.Visible = false;

                if (e.UpdateAvailable) {
                    string resultMsg = string.Format(Consts.UpdateFormatMsg, e.DownloadUrl);
                    rtb_UpdateResult.Text = resultMsg;
                    rtb_UpdateResult.Visible = true;
                }
                else {
                    rtb_UpdateResult.Text = "WsdlUI is up to date";
                    rtb_UpdateResult.Visible = true;
                }

                rtb_UpdateResult.Visible = true;
            }));

        }

        //TODO: FB if the form is closed before the operation completes then do not update any dialogs when the form completes
        //this implementation is a quick fix a better solution would be to handle this as a cancel at the async call level.
        private void dg_HelpAbout_FormClosed(object sender, FormClosedEventArgs e) {
            _formClosed = true;
        }
    }
}
