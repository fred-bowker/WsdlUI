/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;
using System.Drawing;
using System.Windows.Forms;

namespace WsdlUI.App.UI.Dialogs {
    public partial class dg_Error : dg_BaseCancel {
        public dg_Error() {
            InitializeComponent();
        }

        public void PopulateForm(Exception ex) {
            rtb_error.SelectionColor = Color.Red;
            rtb_error.AppendText(ex.ToString());
        }

        void btn_Copy_Click(object sender, EventArgs e) {
            Clipboard.SetText(rtb_error.Text);
        }

        private void rtb_error_KeyPress(object sender, KeyPressEventArgs e) {
            e.Handled = true;
        }

    }
}
