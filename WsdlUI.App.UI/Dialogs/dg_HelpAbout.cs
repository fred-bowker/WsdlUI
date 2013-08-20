/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


namespace WsdlUI.App.UI.Dialogs
{
    public partial class dg_HelpAbout : dg_BaseCancel
    {
        public dg_HelpAbout()
        {
            InitializeComponent();

            lbl_Version.Text = AppInfo.Instance.Version;
            lbl_WebSite.Text = AppInfo.Instance.WebSite;
            lbl_Developer.Text = AppInfo.Instance.Developer;
            txt_License.Text = AppInfo.Instance.License;

            lbl_Developer.Select();
        }

        private void txt_License_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
            e.Handled = true;
        }

        private void txt_License_TextChanged(object sender, System.EventArgs e) {
            txt_License.Undo();
            txt_License.ClearUndo();
        }
    }
}
