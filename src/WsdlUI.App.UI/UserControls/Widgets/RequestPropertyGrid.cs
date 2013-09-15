using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
