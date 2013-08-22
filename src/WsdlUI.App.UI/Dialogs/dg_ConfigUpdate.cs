/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

namespace WsdlUI.App.UI.Dialogs {
    public partial class dg_ConfigUpdate : dg_BaseUpdate {
        public dg_ConfigUpdate() {
            InitializeComponent();
        }

        public void RetrieveForm() {
            State.Instance.ConfigUpdate.Enabled = cb_EnableUpdate.Checked;

        }

        private void dg_ConfigUpdate_Load(object sender, System.EventArgs e) {
            cb_EnableUpdate.Checked = State.Instance.ConfigUpdate.Enabled;

        }
    }
}
