/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Windows.Forms;

namespace WsdlUI.App.UI.Dialogs {
    public class dg_BaseUpdate : dg_Base {
        public dg_BaseUpdate()
            : base() {
            this.FormClosing += dg_BaseUpdate_FormClosing;
        }

        protected virtual bool ValidateForm() {
            return true;
        }

        void dg_BaseUpdate_FormClosing(object sender, FormClosingEventArgs e) {

            bool isValid = ValidateForm();

            if (!isValid) {
                e.Cancel = true;
                return;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.Escape) {
                bool isValid = ValidateForm();
                if (isValid) {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
