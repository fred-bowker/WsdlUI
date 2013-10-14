/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;

namespace WsdlUI.App.Model {
    public class WebSvcMethod {

        public const string HEADER_NAME_CONTENT_TYPE = "Content-Type";
        public const string HEADER_NAME_SOAP_ACTION = "SOAPAction";

        public string ServiceURI {
            get;
            set;
        }

        public string SampleReqMsg {
            get;
            set;
        }

        public string SampleRespMsg {
            get;
            private set;
        }

        public Dictionary<string, string> RequestHeaders {
            get;
            private set;
        }

        public string Name {
            get;
            private set;
        }

        public string HeaderSoapAction {
            get {
                return RequestHeaders[HEADER_NAME_SOAP_ACTION];
            }
        }

        public string SampleResponseMessage {
            get;
            private set;

        }

        public string HeaderContentType {
            get {
                return RequestHeaders[HEADER_NAME_CONTENT_TYPE];
            }
        }

        public string RespHeaderContentType {
            get;
            private set;
        }

        public WebSvcMethod(string name, string sampleReq, string sampleResp, string serviceURI, string soapAction, string reqContentType, string respContentType) {

            Name = name;
            SampleReqMsg = sampleReq;
            SampleRespMsg = sampleResp;
            ServiceURI = serviceURI;

            RequestHeaders = new Dictionary<string, string>();
            RequestHeaders[WsdlUI.App.Model.WebSvcMethod.HEADER_NAME_CONTENT_TYPE] = reqContentType;
            RequestHeaders[WsdlUI.App.Model.WebSvcMethod.HEADER_NAME_SOAP_ACTION] = soapAction;

            RespHeaderContentType = respContentType;

        }

    }
}
