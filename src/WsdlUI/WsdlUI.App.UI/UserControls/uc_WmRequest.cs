/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;
using System.Windows.Forms;
using System.Xml;
using WsdlUI.App.UI.UserControls.Widgets;

using drexModel = Drexyia.WebSvc.Model;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_WmRequest : UserControl {
        public class XmlFormatErrorEventArgs : EventArgs {

            public string ErrorMessage {
                get;
                private set;
            }

            public XmlFormatErrorEventArgs(string errorMessage) {
                ErrorMessage = errorMessage;
            }
        }

        drexModel.WebSvcMethod _webSvcMethod;

        public event EventHandler<XmlFormatErrorEventArgs> OnXmlFormatError;

        public void Enable() {
            tec_Request.BackColor = Consts.EnableBGColor;
            tec_Request.Enabled = true;
        }

        public void Disable() {
            tec_Request.BackColor = Consts.DisabledBGColor;
            tec_Request.Enabled = false;
        }

        public void PopulateForm(string webSvcSrcUri, drexModel.WebSvcMethod webSvcMethod) {
            _webSvcMethod = webSvcMethod;
            tec_Request.Text = webSvcMethod.Request.Body;
            pg_headers.SelectedObject = new RequestPropertyGrid(webSvcSrcUri, 
                webSvcMethod.Name,
                webSvcMethod.Request.Headers[drexModel.WebSvcMessage.HEADER_NAME_CONTENT_TYPE], 
                webSvcMethod.Request.Headers[drexModel.WebSvcMessageRequest.HEADER_NAME_SOAP_ACTION], 
                webSvcMethod.ServiceURI);
        }

        public drexModel.WebSvcMethod RetrieveForm() {
            RequestPropertyGrid items = (RequestPropertyGrid)pg_headers.SelectedObject;

            _webSvcMethod.ServiceURI = items.Url;
            _webSvcMethod.Request.Body = tec_Request.XmlUnformatted;

            return _webSvcMethod;
        }

        public string ValidateForm() {
            try {
                RequestPropertyGrid items = (RequestPropertyGrid)pg_headers.SelectedObject;

                if (string.IsNullOrEmpty(items.Url)) {
                    return "url is empty";
                }

                if (string.IsNullOrEmpty(tec_Request.Text)) {
                    return "xml text is empty";
                }

                Uri url = new Uri(items.Url);
                if (url.Scheme != Uri.UriSchemeHttp && url.Scheme != Uri.UriSchemeHttps) {
                    return "invalid url";
                }

                new XmlDocument().LoadXml(tec_Request.Text);

                return null;
            }
            catch (XmlException ex) {
                return ex.Message;
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
            tec_Request.Font = DefaultFonts.Instance.Large;
        }
        private void formatXmlToolStripMenuItem_Click(object sender, EventArgs e) {
            string validationMessage = tec_Request.FormatXml();
            if (validationMessage != null) {
                if (OnXmlFormatError != null) {
                    OnXmlFormatError(this, new XmlFormatErrorEventArgs(validationMessage));
                }
            
            }
        }
    }
}
