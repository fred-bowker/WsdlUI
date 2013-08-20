/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;

namespace WsdlUI.App.Model {
    public class WebSvcMethod {
        string _initialSampleRequest;

        public const string HEADER_NAME_CONTENT_TYPE = "Content-Type";
        public const string HEADER_NAME_SOAP_ACTION = "SOAPAction";

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

        public string ServiceURI {
            get;
            set;
        }

        public string SampleRequestMessage {
            get;
            set;
        }

        public string HeaderContentType {
            get {
                return RequestHeaders[HEADER_NAME_CONTENT_TYPE];
            }
        }

        public WebSvcMethod(string name, string sampleRequest, string serviceURI) {
            RequestHeaders = new Dictionary<string, string>();

            _initialSampleRequest = sampleRequest;
            Name = name;
            ServiceURI = serviceURI;

            ParseSoapHeaders();
            ParseSoapMessage();
        }

        void ParseSoapHeaders() {
            string[] splitLines = _initialSampleRequest.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            string soapAction = GetHeader(splitLines, "SOAPAction:");
            string contentType = GetHeader(splitLines, "Content-Type:");

            RequestHeaders[WsdlUI.App.Model.WebSvcMethod.HEADER_NAME_CONTENT_TYPE] = contentType;
            RequestHeaders[WsdlUI.App.Model.WebSvcMethod.HEADER_NAME_SOAP_ACTION] = soapAction;
        }

        void ParseSoapMessage() {
            int indexOfMessage = _initialSampleRequest.IndexOf(@"<soap:Envelope");
            SampleRequestMessage = _initialSampleRequest.Substring(indexOfMessage);
        }

        string GetHeader(string[] splitLines, string headerName) {
            foreach (var v in splitLines) {
                if (v.StartsWith(headerName)) {
                    return v.Replace(headerName, "").Trim();
                }
            }

            throw new Exception("Error Here");
        }

    }
}
