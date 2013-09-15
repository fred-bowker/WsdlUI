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

using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

using model = WsdlUI.App.Model;
using WsdlUI.App.UI.UserControls.Widgets;

namespace WsdlUI.App.UI.UserControls {
    public partial class uc_WmRequest : UserControl {
        model.WebSvcMethod _webSvcMethod;

        public void Enable() {
            tec_Request.BackColor = Consts.EnableBGColor;
            tec_Request.Enabled = true;
        }

        public void Disable() {
            tec_Request.BackColor = Consts.DisabledBGColor;
            tec_Request.Enabled = false;
        }


        public void PopulateForm(string webSvcSrcUri, WsdlUI.App.Model.WebSvcMethod webSvcMethod) {
            _webSvcMethod = webSvcMethod;
            tec_Request.Text = webSvcMethod.SampleReqMsg;
            pg_headers.SelectedObject = new RequestPropertyGrid(webSvcSrcUri, webSvcMethod.Name, webSvcMethod.HeaderContentType, webSvcMethod.HeaderSoapAction, webSvcMethod.ServiceURI);
        }

        public WsdlUI.App.Model.WebSvcMethod RetrieveForm() {
            RequestPropertyGrid items = (RequestPropertyGrid)pg_headers.SelectedObject;

            _webSvcMethod.ServiceURI = items.Url;
            _webSvcMethod.SampleReqMsg = tec_Request.Text;

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
    }
}
