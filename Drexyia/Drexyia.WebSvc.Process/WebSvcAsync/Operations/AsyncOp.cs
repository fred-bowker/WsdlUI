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
using Drexyia.WebSvc.Process.WebSvcAsync.EventParams;
using Drexyia.WebSvc.Process.WebSvcAsync.Result;
using log4net;
using model = Drexyia.WebSvc.Model;
using process = Drexyia.WebSvc.Process;
using utils = Drexyia.Utils;

namespace Drexyia.WebSvc.Process.WebSvcAsync.Operations {
    public abstract class AsyncOp {

        public event EventHandler<EventParams.TimeoutAsyncArgs> OnTimeout;

        //we can expect calls to the web server to fail as such these are handled in a different way
        public event EventHandler<process.WebSvcAsync.EventParams.ExceptionAsyncArgs> OnWebException;
        public event EventHandler<process.WebSvcAsync.EventParams.ExceptionAsyncArgs> OnException;


        protected abstract void Work();
        protected abstract void TearDown();

        TimeoutObject _timeoutObject;
        protected bool HasTimedOut {
            get {
                return _timeoutObject.HasTimedOut;
            }
        }

        protected int TimeoutInSec {
            get;
            private set;
        }

        protected ILog Log {
            get;
            private set;
        }

        protected string Name {
            get;
            private set;
        }

        protected model.IProxy Proxy {
            get;
            private set;
        }

        protected WebProxy WebProxy {
            get {
                return utils.ProxyWrapper.GetWebProxy(Proxy);
            }
        }

        protected AsyncOp(string name, int timeout) {
            Name = name;
            TimeoutInSec = timeout;

            _timeoutObject = new TimeoutObject(Name, timeout);
            _timeoutObject.OnTimeout += _timeoutObject_OnTimeout;

            Log = LogManager.GetLogger(typeof(AsyncOp));
            Proxy = new model.Proxy();
        }

        protected AsyncOp(string name, int timeout, model.IProxy proxy, ILog log) {
            Log = log; 
            Name = name;
            Proxy = proxy;
            TimeoutInSec = timeout;

            _timeoutObject = new TimeoutObject(Name, timeout);
            _timeoutObject.OnTimeout += _timeoutObject_OnTimeout;
        }

        void _timeoutObject_OnTimeout(object sender, EventParams.TimeoutAsyncArgs e) {

            TearDown();

            if (OnTimeout != null) {
                OnTimeout(sender, e);
            }
        }

        public void Start() {

            _timeoutObject.Start();

            try {
                Work();
            }
            catch (System.Net.WebException ex) {

                Log.Error(ex.ToString());

                if (_timeoutObject.HasTimedOut) {
                    return;
                }

                HandleWebException(ex);

            } //if the url does not contain a valid wsdl
            //if no service descriptions are found at the endpoint 
            catch (SvcDescsNotFoundException ex) {

                Log.Error(ex.ToString());

                if (OnWebException != null) {
                    OnWebException(this,
                        new process.WebSvcAsync.EventParams.ExceptionAsyncArgs(Name, ex));
                }
            }
            //if the url does not contain a valid wsdl
            catch (InvalidOperationException ex) {

                Log.Error(ex.ToString());

                //proxy 407 exceptions are thrown as invalid operation exceptions however the innerexception is a web exception.
                System.Net.WebException webException = ex.InnerException as System.Net.WebException;
                if (webException != null) {
                    HandleWebException(webException);
                }
                else {
                    //the user should handle these events in the same way as a web exception, ot does not have a timeout status
                    if (OnWebException != null) {
                        OnWebException(this,
                            new process.WebSvcAsync.EventParams.ExceptionAsyncArgs(Name, ex));
                    }
                }
            }
            catch (Exception ex) {

                Log.Error(ex.ToString());

                if (_timeoutObject.HasTimedOut) {
                    return;
                }

                if (OnException != null) {
                    OnException(this,
                        new process.WebSvcAsync.EventParams.ExceptionAsyncArgs(Name, ex));
                }
            }
            finally {
                TearDown();
            }

            _timeoutObject.Stop();

        }

        void HandleWebException(System.Net.WebException ex) {
            //timeouts are handled by the timeout object.
            if (ex.Status == WebExceptionStatus.Timeout) {
                Log.Info("Work Response Timeout " + Name);
                return;
            }

            if (OnWebException != null) {
                var streamReader = new StreamReader(ex.Response.GetResponseStream());
                string body = streamReader.ReadToEnd();

                string status = ((HttpWebResponse)ex.Response).StatusCode.ToString();
                Dictionary<string, string> headers = new Dictionary<string, string>();
                foreach (string key in ex.Response.Headers.Keys)
                {
                    headers[key] = ex.Response.Headers[key];
                }

                ExceptionAsyncArgs args = new ExceptionAsyncArgs(Name, ex)
                {
                    Result = new CallAsyncResult(body, status, headers)
                };

                OnWebException(this, args);
            }

        }

        protected void Stop() {

            //in the event of user cancel the timout thread must be stopped
            _timeoutObject.Stop();
        }
    }
}