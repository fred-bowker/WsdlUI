/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.ComponentModel;

namespace WsdlUI.App.UI.UserControls.Widgets {

    public class RequestPropertyGrid {

        const string LINE_CATEGORY_NAME = "Request Line";
        const string HEADER_CATEGORY_NAME = "Request Headers";

        [Browsable(false)]
        public string WebSvcSrcUri {
            get;
            private set;
        }

        [Browsable(false)]
        public string WebSvcMethod {
            get;
            private set;
        }

        [CategoryAttribute(HEADER_CATEGORY_NAME)]
        [DisplayName(WsdlUI.App.Model.WebSvcMethod.HEADER_NAME_CONTENT_TYPE)]
        public string ContentType {
            get;
            private set;
        }

        [CategoryAttribute(HEADER_CATEGORY_NAME)]
        [DisplayName(WsdlUI.App.Model.WebSvcMethod.HEADER_NAME_SOAP_ACTION)]
        public string SoapAction {
            get;
            private set;
        }

        [TypeConverter(typeof(UrlConverter))]
        [CategoryAttribute(LINE_CATEGORY_NAME)]
        [DisplayName("URL")]
        public string Url {
            get;
            set;
        }

        public RequestPropertyGrid(string webSvcSrcUri, string webSvcMethod, string contentType, string soapAction, string url) {
            WebSvcSrcUri = webSvcSrcUri;
            WebSvcMethod = webSvcMethod;
            ContentType = contentType;
            SoapAction = soapAction;
            Url = url;
        }
    }

    public class UrlConverter : StringConverter {

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context) {
            RequestPropertyGrid gridInstance = (RequestPropertyGrid)context.Instance;
            string[] prevUrls = State.Instance.ConfigPrevUrls.GetPrev(gridInstance.WebSvcSrcUri, gridInstance.WebSvcMethod);
            return new StandardValuesCollection(prevUrls);
        }

        public override bool GetStandardValuesSupported(
                           ITypeDescriptorContext context) {
            return true;
        }

        public override bool GetStandardValuesExclusive(
                           ITypeDescriptorContext context) {
            return false;
        }
    }

}
