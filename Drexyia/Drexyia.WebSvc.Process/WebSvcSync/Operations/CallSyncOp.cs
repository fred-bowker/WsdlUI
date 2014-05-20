/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.IO;
using System.Net;

using log4net;

using model = Drexyia.WebSvc.Model;

//SYNC objects contain no cancel operation
namespace Drexyia.WebSvc.Process.WebSvcSync.Operations {
    public class CallSyncOp : SyncOp {

        const int DEFAULT_TIMEOUT = 60;

        model.WebSvcMethod _webSvcMethod;

        public CallSyncOp(model.WebSvcMethod webSvcMethod)
            : base(webSvcMethod.Name, DEFAULT_TIMEOUT) {
            _webSvcMethod = webSvcMethod;
        }

        public CallSyncOp(model.WebSvcMethod webSvcMethod, int timeoutPeriod, model.Proxy proxy, ILog log)
            : base(webSvcMethod.Name, timeoutPeriod, proxy, log) {

            _webSvcMethod = webSvcMethod;
        }

        public model.WebSvcMessageResponse Work() {

            HttpWebResponse _webResponse = null;
            StreamWriter _streamWriter = null;
            StreamReader _streamReader = null;

            try {

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.CreateDefault(new Uri(_webSvcMethod.ServiceURI));

                webRequest.Method = "Post";
                webRequest.ContentType = _webSvcMethod.Request.HeaderContentType;
                webRequest.Headers["SOAPAction"] = _webSvcMethod.Request.HeaderSoapAction;
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Proxy = base.WebProxy;

                webRequest.Timeout = base.TimeoutInSec * 1000;

                _streamWriter = new StreamWriter(webRequest.GetRequestStream());

                _streamWriter.Write(_webSvcMethod.Request.Body);
                _streamWriter.Flush();
                _streamWriter.Close();

                _webResponse = (HttpWebResponse)webRequest.GetResponse();

                base.Log.Info("Work Response Process " + base.Name);

                _streamReader = new StreamReader(_webResponse.GetResponseStream());

                string responseMessage = _streamReader.ReadToEnd();
                string status = ((int)_webResponse.StatusCode).ToString() + " " + _webResponse.StatusCode.ToString();
                
                //TODO: FB we are currently not doing anything with the headers returned add this for next version
                //Dictionary<string, string> headers = new Dictionary<string, string>();
                //string contentLength = "Content-Length," + _webResponse.ContentLength.ToString();
                //foreach (string key in _webResponse.Headers.Keys) {
                //    headers[key] = _webResponse.Headers[key];
                //}

                model.WebSvcMessageResponse response = new model.WebSvcMessageResponse() {
                    Body = responseMessage,
                    Status = status
                };

                return response;

            }
            finally 
            {
                if (_webResponse != null) {
                    _webResponse.Close();
                }
                if (_streamWriter != null) {
                    _streamWriter.Close();
                }
                if (_streamReader != null) {
                    _streamReader.Close();
                }
            }
    
        }


    }
}
