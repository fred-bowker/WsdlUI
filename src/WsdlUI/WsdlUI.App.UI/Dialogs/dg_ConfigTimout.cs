/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;

namespace WsdlUI.App.UI.Dialogs {
    public partial class dg_ConfigTimout : dg_BaseUpdate
    {
        //No timeout is set to an hour
        Dictionary<int, string> _timeoutTextMapping = new Dictionary<int, string>()
        {
            {3600, "No Timeout"}
            ,{15, "15 Second"}
            ,{30, "30 Second"}
            ,{60, "1 Minute"}
            ,{120, "2 Minute"}
            ,{240, "4 Minute"}
        };

        public dg_ConfigTimout()
        {
            InitializeComponent();
        }

        private void dg_ConfigTimeout_Load(object sender, System.EventArgs e) {

            foreach (var keyValue in _timeoutTextMapping)
            {
                cb_Timeout.Items.Add(keyValue.Value);
            }

            string timeoutText = _timeoutTextMapping[State.Instance.ConfigTimeout.Timeout];

            cb_Timeout.SelectedText = timeoutText;
        }

        //save config changes
        private void dg_ConfigTimeout_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            foreach (var keyValue in _timeoutTextMapping)
            {
                if (keyValue.Value == cb_Timeout.SelectedText)
                {
                    State.Instance.ConfigTimeout.Timeout = keyValue.Key;
                }
            }
        }
    }
}
