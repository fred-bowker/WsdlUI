/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using drexModel = Drexyia.WebSvc.Model;

namespace WsdlUI.App.UI.Dialogs {
    public partial class dg_ConfigProxy : dg_BaseUpdate {
        public dg_ConfigProxy() {
            InitializeComponent();
        }

        protected override bool ValidateForm() {
            //validate port must be number between 1 through 65535
            int result;
            bool isValidNum = int.TryParse(txt_Port.Text, out result);
            if (!isValidNum) {
                toolTip1.ToolTipTitle = "Invalid Port";
                toolTip1.Show("Port must be a valid number between 1 and 65535", txt_Port, txt_Port.Location, 5000);
                return false;
            }

            if (result < 1 || result > 65535) {
                toolTip1.ToolTipTitle = "Invalid Port";
                toolTip1.Show("Port must be a valid number between 1 and 65535", txt_Port, txt_Port.Location, 5000);
                return false;
            }

            return true;
        }

        private void dg_ConfigProxy_Load(object sender, System.EventArgs e) {
            txt_Host.Text = State.Instance.ConfigProxy.Host;
            txt_Port.Text = State.Instance.ConfigProxy.Port.ToString();

            cb_Enabled.SelectedIndex = (int)State.Instance.ConfigProxy.ProxyType;
        }

        //save config changes
        private void dg_ConfigProxy_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e) {
            State.Instance.ConfigProxy.Host = txt_Host.Text;

            if (txt_Port.Text != "") {
                int parseResult = 0;
                if (int.TryParse(txt_Port.Text, out parseResult)) {
                    State.Instance.ConfigProxy.Port = parseResult;
                }
            }

            State.Instance.ConfigProxy.ProxyType = (drexModel.Proxy.EProxyType)cb_Enabled.SelectedIndex;
        }
    }
}
