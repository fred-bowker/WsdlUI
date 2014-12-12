/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.IO;
using System.Windows.Forms;

namespace WsdlUI.App.UI.Dialogs {
    //NOTE: A wsdl path must be a valid uri this can either be a file or a web address
    //  NOTE: example file://c:/temp/fred.wsdl http://temp/temp.wsdl
    public partial class dg_AddWS : dg_BaseCancel {
        public string SelectedWSDL {
            get {
                return cb_Wsdl.Text;
            }
        }

        public string ErrorMessage {
            get;
            private set;
        }

        public dg_AddWS() {
            InitializeComponent();
        }

        public void PopulateForm() {
            foreach (string line in State.Instance.ConfigPrevWsdls.WsdlList) {
                cb_Wsdl.Items.Add(line);
            }
        }

        void btnGo_Click(object sender, EventArgs e) {
            if (ValidateForm() == false) {
                return;
            }

            State.Instance.ConfigPrevWsdls.Add(cb_Wsdl.Text);
        }

        protected bool ValidateForm() {
            if (string.IsNullOrEmpty(cb_Wsdl.Text)) {
                ErrorMessage = @"the uri can not be empty";

                return false;
            }

            if (!cb_Wsdl.Text.StartsWith("http") && !cb_Wsdl.Text.StartsWith("file")) {
                ErrorMessage = @"a vaid uri must be used for the wsdl address either file:// or http://";

                return false;
            }

            Uri outUri = null;
            if (Uri.TryCreate(cb_Wsdl.Text, UriKind.Absolute, out outUri) == false) {
                ErrorMessage = @"invalid uri entered example valid uris file://c:/temp/fred.wsdl http://temp/temp.wsdl";

                return false;
            }

            if (outUri.IsFile) {
                if (File.Exists(outUri.LocalPath) == false) {
                    ErrorMessage = @"file location does not exist";

                    return false;
                }
            }

            return true;
        }

        void btn_fileSelect_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = AppConfig.Instance.DefaultWsdlPath;;
            openFileDialog1.Filter = "wsdl files (*.wsdl)|*.wsdl";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string uri = @"file://" + openFileDialog1.FileName;
                cb_Wsdl.Text = uri;
            }
        }

     
    }
}
