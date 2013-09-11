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
using System.Xml;

using model = WsdlUI.App.Model;
using WsdlUI.App.UI.UserControls.Widgets;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_WmRequest : UserControl {
        model.WebSvcMethod _webSvcMethod;

        public void Enable() {
            rtb_Request.BackColor = Consts.EnableBGColor;
            rtb_Request.ReadOnly = false;
        }

        public void Disable() {
            rtb_Request.BackColor = Consts.DisabledBGColor;
            rtb_Request.ReadOnly = true;
        }

        //returns null if valid else returns an error string, text passed in as we are then using a copy from other thread
        public string ValidateForm(string url, string xml) {
            if (string.IsNullOrEmpty(url)) {
                return "url is empty";
            }

            if (string.IsNullOrEmpty(xml)) {
                return "xml text is empty";
            }

            try {
                new XmlDocument().LoadXml(xml);

                return null;
            }
            catch (XmlException ex) {
                return ex.Message;
            }
        }

        public void Clear() {
            rtb_Request.Text = "";
        }

        public void PopulateForm(string webSvcSrcUri, WsdlUI.App.Model.WebSvcMethod webSvcMethod) {
            _webSvcMethod = webSvcMethod;

            rtb_Request.Text = webSvcMethod.SampleRequestMessage;

            pg_headers.SelectedObject = new RequestPropertyGrid(webSvcSrcUri, webSvcMethod.Name, webSvcMethod.HeaderContentType, webSvcMethod.HeaderSoapAction, webSvcMethod.ServiceURI);
        }

        public WsdlUI.App.Model.WebSvcMethod RetrieveForm() {
            RequestPropertyGrid items = (RequestPropertyGrid)pg_headers.SelectedObject;

            _webSvcMethod.ServiceURI = items.Url;
            _webSvcMethod.SampleRequestMessage = rtb_Request.Text;

            return _webSvcMethod;
        }

        public string ValidateForm() {
            try {
                RequestPropertyGrid items = (RequestPropertyGrid)pg_headers.SelectedObject;

                Uri url = new Uri(items.Url);
                if (url.Scheme != Uri.UriSchemeHttp && url.Scheme != Uri.UriSchemeHttps) {
                    return "invalid url";
                }
                
                return null;
            }
            catch (UriFormatException) {
                return "invalid url";
            }
        }

        public uc_WmRequest() {
            InitializeComponent();
        }

        private void uc_WmRequest_Load(object sender, EventArgs e) {
            Font = DefaultFonts.Instance.Small;
            rtb_Request.Font = DefaultFonts.Instance.Large;
        }
    }
}
