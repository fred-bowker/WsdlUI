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

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_Log : UserControl {
        //timestamp - message
        const string LOG_FORMAT_STRING = "{0} - {1}";

        public uc_Log() {
            InitializeComponent();

            rtb_log.BackColor = Consts.DisabledBGColor;
        }

        public void LogErrorMessage(string message) {
            string logMessage = string.Format(LOG_FORMAT_STRING, DateTime.Now.ToString("hh:mm:ss.fff"), message);

            rtb_log.SelectionColor = Color.Red;
            rtb_log.AppendText(logMessage + "\n");
        }

        public void LogInfoMessage(string message) {
            string logMessage = string.Format(LOG_FORMAT_STRING, DateTime.Now.ToString("hh:mm:ss.fff"), message);

            rtb_log.SelectionColor = Color.Green;
            rtb_log.AppendText(logMessage + "\n");

        }

        public void LogSystemMessage(string message) {
            rtb_log.SelectionColor = Color.Blue;
            rtb_log.AppendText(message + "\n");
        }

        void clearToolStripMenuItem_Click(object sender, EventArgs e) {
            rtb_log.ResetText();
        }

        private void uc_Log_Load(object sender, EventArgs e) {
            Font = DefaultFonts.Instance.Small;
        }

    }
}
