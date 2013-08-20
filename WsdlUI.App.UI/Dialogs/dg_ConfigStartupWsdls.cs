/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;

using model = WsdlUI.App.Model;

namespace WsdlUI.App.UI.Dialogs {
    public partial class dg_ConfigStartupWsdls : dg_BaseUpdate {
        public dg_ConfigStartupWsdls() {
            InitializeComponent();
        }

        protected override bool ValidateForm() {
            if (string.IsNullOrEmpty(txt_Wsdls.Text)) {
                return true;
            }

            //remove blank lines
            RemoveBlankLines();

            for (int i = 0; i <= txt_Wsdls.Lines.Length - 1; i++) {
                string errorMessage = model.Config.StartupWsdls.VaildateWsdl(txt_Wsdls.Lines[i]);
                if (errorMessage != null) {
                    toolTip1.ToolTipTitle = "Invalid Wsdl";
                    toolTip1.Show("Error on line " + i.ToString() + " " + errorMessage, txt_Wsdls, txt_Wsdls.Location, 5000);
                    return false;
                }
            }
            return true;
        }

        void RemoveBlankLines() {

            List<string> linesList = new List<string>(txt_Wsdls.Lines);
            linesList
                .RemoveAll(item => item.Trim() == "");

            txt_Wsdls.Lines = linesList.ToArray();

        }

        void txt_Wsdls_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == '\r') {
                //if first line and is blank do not move to next line
                if (txt_Wsdls.Lines.Length == 0 && txt_Wsdls.Text == "") {
                    e.Handled = true;
                    return;
                }
                //if the current line is blank do not move to next line
                int currentLineIndex = txt_Wsdls.GetLineFromCharIndex(txt_Wsdls.GetFirstCharIndexOfCurrentLine());
                string currentLine = txt_Wsdls.Lines[currentLineIndex];
                if (currentLine == "") {
                    e.Handled = true;
                    return;
                }

                //restrict to maximum number of lines alloed
                if (txt_Wsdls.Lines.Length >= AppConfig.Instance.MaxStartupWsdls) {
                    e.Handled = true;
                    return;
                }
            }
        }

        void txt_Wsdls_TextChanged(object sender, EventArgs e) {
            cb_Enabled.Enabled = (string.IsNullOrEmpty(txt_Wsdls.Text) == false);

            //restirct to max lines
            if (txt_Wsdls.Lines.Length > AppConfig.Instance.MaxStartupWsdls) {
                txt_Wsdls.Undo();
                txt_Wsdls.ClearUndo();
            }
        }

        private void dg_ConfigStartupWsdls_Load(object sender, EventArgs e) {

            txt_Wsdls.Lines = State.Instance.ConfigStartupWsdls.Wsdls;
         
            if (txt_Wsdls.Lines.Length == 0) {
                cb_Enabled.Enabled = false;
                return;
            }

            cb_Enabled.Checked = State.Instance.ConfigStartupWsdls.Enabled;

        }

        //saves data, if an exception occurs this method will not be called and the application closes successfully.
        private void dg_ConfigStartupWsdls_FormClosed(object sender, FormClosedEventArgs e) {
            State.Instance.ConfigStartupWsdls.Wsdls = txt_Wsdls.Lines;
            State.Instance.ConfigStartupWsdls.Enabled = cb_Enabled.Checked;
        }

    }
}
