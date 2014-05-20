/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Net;
using log4net;
using model = Drexyia.WebSvc.Model;
using utils = Drexyia.Utils;

namespace Drexyia.WebSvc.Process.WebSvcSync.Operations {
    public abstract class SyncOp {

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

        protected SyncOp(string name, int timeout) {
            Name = name;
            TimeoutInSec = timeout;
            Log = LogManager.GetLogger(typeof(SyncOp));
            Proxy = new model.Proxy();
        }

        protected SyncOp(string name, int timeout, model.IProxy proxy, ILog log) {
            Log = log;
            Name = name;
            Proxy = proxy;
            TimeoutInSec = timeout;
        }
    }
}
