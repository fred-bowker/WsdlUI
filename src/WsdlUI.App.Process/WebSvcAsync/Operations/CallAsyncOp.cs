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

using model = WsdlUI.App.Model;
using process = WsdlUI.App.Process;
using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.Process.WebSvcAsync.Operations {
    public class CallAsyncOp : AsyncOp {

        public event EventHandler<websvcasync.EventParams.AsyncArgsCompleteCall> OnComplete;
        public event EventHandler OnCancel;

        HttpWebResponse _webResponse = null;
        StreamWriter _streamWriter = null;
        StreamReader _streamReader = null;
        CancelToken _cancelToken;
        int _timeoutPeriod;

        model.WebSvcMethod _webSvcMethod;
        websvcasync.CancelObject _cancelObject;
      
        public CallAsyncOp(model.WebSvcMethod webSvcMethod, CancelToken cancelToken, model.Config.Proxy configProxy, int timeoutPeriod)
            : base(webSvcMethod.Name, configProxy, timeoutPeriod) {

            _webSvcMethod = webSvcMethod;
            _cancelToken = cancelToken;
            _timeoutPeriod = timeoutPeriod;

            _cancelObject = new websvcasync.CancelObject(webSvcMethod.Name, cancelToken);
            _cancelObject.OnCancel +=_cancelObject_OnCancel;
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
                _cancelObject.Start();

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.CreateDefault(new Uri(_webSvcMethod.ServiceURI));

                webRequest.Method = "Post";
                webRequest.ContentType = _webSvcMethod.HeaderContentType;
                webRequest.Headers["SOAPAction"] = _webSvcMethod.HeaderSoapAction;
                webRequest.ServicePoint.Expect100Continue = false;
                webRequest.Proxy = base.WebProxy;
                webRequest.Timeout = _timeoutPeriod * 1000;

                _streamWriter = new StreamWriter(webRequest.GetRequestStream());

                _streamWriter.Write(_webSvcMethod.SampleReqMsg);
                _streamWriter.Flush();
                _streamWriter.Close();

                _webResponse = (HttpWebResponse)webRequest.GetResponse();

                if (_cancelToken.IsCancellationRequested) {
                    process.Logger.Instance.Log.Info("Work Response Cancel " + base.Name);
                    return;
                }
                process.Logger.Instance.Log.Info("Work Response Process " + base.Name);

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
                        new websvcasync.EventParams.AsyncArgsCompleteCall(base.Name, startTime, endTime,
                            new process.WebSvcAsync.Result.CallAsyncResult(responseMessage, contentLength, status, headers)
                            ));

                }
            }
            catch (System.Net.WebException ex) 
            {
                //if exception is thrown on the server then check whether user has cancelled before returning
                if (_cancelToken.IsCancellationRequested) {
                    Logger.Instance.Log.Info("Work Response Exception, User Cancelled " + Name + " " + ex.Message);
                    return;
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
