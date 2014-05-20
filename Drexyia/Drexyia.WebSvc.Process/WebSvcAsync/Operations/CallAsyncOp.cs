/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using log4net;

using model = Drexyia.WebSvc.Model;
using process = Drexyia.WebSvc.Process;

namespace Drexyia.WebSvc.Process.WebSvcAsync.Operations {
    public class CallAsyncOp : AsyncOp {

        const int DEFAULT_TIMEOUT = 60;

        public event EventHandler<process.WebSvcAsync.EventParams.AsyncArgsCompleteCall> OnComplete;
        public event EventHandler OnCancel;

        HttpWebResponse _webResponse = null;
        StreamWriter _streamWriter = null;
        StreamReader _streamReader = null;

        model.WebSvcMethod _webSvcMethod;

        //if the cancel token is not set then the call will run with no option for cancelling the operation
        CancelToken _cancelToken;
        process.WebSvcAsync.CancelObject _cancelObject;

        public CallAsyncOp(model.WebSvcMethod webSvcMethod)
            : base(webSvcMethod.Name, DEFAULT_TIMEOUT) {

            _webSvcMethod = webSvcMethod;
        }

        public CallAsyncOp(model.WebSvcMethod webSvcMethod, CancelToken cancelToken, int timeoutPeriod, model.IProxy proxy, ILog log)
            : base(webSvcMethod.Name, timeoutPeriod, proxy, log) {

            _webSvcMethod = webSvcMethod;
            _cancelToken = cancelToken;

            _cancelObject = new process.WebSvcAsync.CancelObject(webSvcMethod.Name, cancelToken);
            _cancelObject.OnCancel += _cancelObject_OnCancel;
        }

        void _cancelObject_OnCancel(object sender, EventArgs e) {

            //stop the timer object
            base.Stop();

            if (OnCancel != null) {
                OnCancel(sender, e);
            }
        }

        protected override void Work() {

            DateTime startTime = DateTime.Now;

            try {

                if (_cancelObject != null) {
                    _cancelObject.Start();
                }

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

                if (_cancelToken != null) {
                    if (_cancelToken.IsCancellationRequested) {
                        base.Log.Info("Work Response Cancel " + base.Name);
                        return;
                    }
                }
                base.Log.Info("Work Response Process " + base.Name);

                _streamReader = new StreamReader(_webResponse.GetResponseStream());

                string responseMessage = _streamReader.ReadToEnd();
                string contentLength = "Content-Length," + _webResponse.ContentLength.ToString();
                string status = ((int)_webResponse.StatusCode).ToString() + " " + _webResponse.StatusCode.ToString();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                foreach (string key in _webResponse.Headers.Keys) {
                    headers[key] = _webResponse.Headers[key];
                }

                if (OnComplete != null) {

                    DateTime endTime = DateTime.Now;

                    OnComplete(this,
                        new process.WebSvcAsync.EventParams.AsyncArgsCompleteCall(base.Name, startTime, endTime,
                            new process.WebSvcAsync.Result.CallAsyncResult(responseMessage, contentLength, status, headers)
                            ));

                }
            }
            catch (System.Net.WebException ex) 
            {
                if (_cancelToken != null) {

                    //if exception is thrown on the server then check whether user has cancelled before returning
                    if (_cancelToken.IsCancellationRequested) {
                        base.Log.Info("Work Response Exception, User Cancelled " + Name + " " + ex.Message);
                        return;
                    }
                }

                //throw for the base class to handle
                throw ex;

            }
            finally 
            {
                TearDown();
            }
    
        }

        protected override void TearDown() {

            try {

                _cancelObject.Stop();

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
            catch (Exception) {
            }

        }

    }
}