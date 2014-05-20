/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;

using System.Windows.Forms;

namespace WsdlUI.App.UI.UserControls {
    
    public class UserControlBase : UserControl {

        public UserControlBase() {
            this.Load += UserControlBase_Load;
        }

        void UserControlBase_Load(object sender, EventArgs e) {

            if (State.Instance.Mode == ProjectMode.SingleWsdl) {
                LoadSingleRequestMode();
            }
            else {
                LoadMultipleRequestMode();
            }
        }

        public virtual void LoadSingleRequestMode() {
        }
        public virtual void LoadMultipleRequestMode() {
        }

    }
}
