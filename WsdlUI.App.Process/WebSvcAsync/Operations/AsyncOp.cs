/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Net;

using model = WsdlUI.App.Model;
using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.Process.WebSvcAsync.Operations {
    public abstract class AsyncOp {

        public event EventHandler<EventParams.TimeoutAsyncArgs> OnTimeout;

        //we can expect calls to the web server to fail as such these are handled in a different way
        public event EventHandler<websvcasync.EventParams.ExceptionAsyncArgs> OnWebException;
        public event EventHandler<websvcasync.EventParams.ExceptionAsyncArgs> OnException;

        model.Config.Proxy _configProxy;

        TimeoutObject _timeoutObject;
        protected bool HasTimedOut {
            get {
                return _timeoutObject.HasTimedOut;
            }
        }

        protected string Name {
            get;
            private set;
        }

        protected abstract void Work();
        protected abstract void TearDown();

        protected IWebProxy WebProxy {
            get {
                IWebProxy proxy = null;

                if (_configProxy.ProxyType != model.Config.Proxy.EProxyType.Disabled) {
                    proxy = (_configProxy.ProxyType == model.Config.Proxy.EProxyType.Enabled)
                        ? new WebProxy(_configProxy.Host, _configProxy.Port)
                        : DefaultProxy.Instance.Proxy;

                    proxy.Credentials = CredentialCache.DefaultCredentials;
                }

                return proxy;
            }
        }

        protected AsyncOp(string name, model.Config.Proxy configProxy, int timeoutPeriod) {
            Name = name;
            _configProxy = configProxy;

            _timeoutObject = new TimeoutObject(Name, timeoutPeriod);
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

                Logger.Instance.Log.Error(ex.ToString());

                if (_timeoutObject.HasTimedOut) {
                    return;
                }

                //timeouts are handled by the timeout object.
                if (ex.Status == WebExceptionStatus.Timeout) {
                    Logger.Instance.Log.Info("Work Response Timeout " + Name);
                    return;
                }

                if (OnWebException != null) {
                    OnWebException(this,
                        new websvcasync.EventParams.ExceptionAsyncArgs(Name, ex));
                }

            }
            catch (Exception ex) {
                if (_timeoutObject.HasTimedOut) {
                    return;
                }

                if (OnException != null) {
                    OnException(this,
                        new websvcasync.EventParams.ExceptionAsyncArgs(Name, ex));
                }
            }
            finally {
                TearDown();
            }

            _timeoutObject.Stop();

        }

        protected void Stop() {

            //in the event of user cancel the timout thread must be stopped
            _timeoutObject.Stop();
        }









    }
}
