/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;
using System.Collections.Generic;
using System.Windows.Forms;

using WsdlUI.App.UI.UserControls.Widgets;
using drexProcess = Drexyia.WebSvc.Process;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_WmResponse : UserControl {
        public uc_WmResponse() {
            InitializeComponent();
        }

        public void PopulateForm(drexProcess.WebSvcAsync.Result.CallAsyncResult result) {
            uc_responseMessage.PopulateForm(result.Response.Body);
            pg_responseHeaders.SelectedObject = new ResponsePropertyGrid(result.Response.Status, result.Response.Headers);
        }

        public void PopulateForm(string respMsg, string status, string contentType) {
            uc_responseMessage.PopulateForm(respMsg);

            Dictionary<string, string> headers = new Dictionary<string, string> {
                {"Content-Type", contentType}
            };
            pg_responseHeaders.SelectedObject = new ResponsePropertyGrid(status, headers);
        }

        public void Clear() {
            pg_responseHeaders.SelectedObject = null;
            uc_responseMessage.Clear();
        }

        void uc_WmResponse_Load(object sender, EventArgs e) {
            Font = DefaultFonts.Instance.Small;
        }


    }










}
