/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System.Windows.Forms;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_Status : UserControl {
        public uc_Status() {
            InitializeComponent();
            tslbl_Status.AutoSize = false;
            tslbl_Status.Spring = false;

            ss_Progress.BackColor = Consts.DisabledBGColor;
            ss_Progress.SizeChanged += ss_Progress_SizeChanged;

            pb_Running.Minimum = 1;
            pb_Running.Value = 1;
            pb_Running.Step = 1;

            //interval of half a second
            timer1.Interval = 500;
            timer1.Tick += timer1_Tick;
        }

        void ss_Progress_SizeChanged(object sender, System.EventArgs e) {
            pb_Running.Width = ss_Progress.Width - 114;
        }

        internal void StatusInProgress() {

            tslbl_Status.Text = "In Progress";

            pb_Running.Maximum = State.Instance.ConfigTimeout.Timeout * 2;
            timer1.Enabled = true;
            timer1.Start();

        }

        internal void StatusReady() {

            timer1.Stop();

            tslbl_Status.Text = "Ready";
            pb_Running.Value = 1;
        }

        private void uc_Status_Load(object sender, System.EventArgs e) {
            Font = DefaultFonts.Instance.Small;
            tslbl_Status.Font = DefaultFonts.Instance.Small;
        }

        void timer1_Tick(object sender, System.EventArgs e) {
            if (pb_Running.Value != pb_Running.Maximum) {
                pb_Running.Value++;
            }
            else {
                timer1.Stop();
            }
        }

    }
}
