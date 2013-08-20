/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Windows.Forms;

namespace WsdlUI.App.UI.UserControls
{
    public partial class uc_PanelInfo : UserControl
    {
        private Control _childControl;

        public uc_PanelInfo()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            _childControl = new Panel();
            _childControl.Parent = this;
            _childControl.Dock = DockStyle.Fill;
            _childControl.BringToFront();
        }

        public void DispayControl(Control childControl)
        {
            childControl.Parent = this;
            childControl.Dock = DockStyle.Fill;

            _childControl = childControl;

            _childControl.BringToFront();         
        }
    }
}
