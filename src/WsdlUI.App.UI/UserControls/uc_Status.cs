/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System.Drawing;
using System.Windows.Forms;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_Status : UserControl {
        public uc_Status() {
            InitializeComponent();

            ss_Progress.BackColor = Color.FromArgb(215, 228, 242); 
        }

        internal void StatusInProgress() {
            tslbl_Status.Text = "In Progress";
            ss_Progress.BackColor = Color.LightPink;
        }

        internal void StatusReady() {
            tslbl_Status.Text = "Ready";

            ss_Progress.BackColor = Color.FromArgb(215, 228, 242); 
        }

        private void uc_Status_Load(object sender, System.EventArgs e) {
            Font = DefaultFonts.Instance.Small;
            tslbl_Status.Font = DefaultFonts.Instance.Small;
        }

    }
}
