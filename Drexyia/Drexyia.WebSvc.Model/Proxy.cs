/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

namespace Drexyia.WebSvc.Model {
    public class Proxy : IProxy {
      
        public enum EProxyType {
            Enabled = 0
            ,Disabled = 1
            ,System = 2
        }

        public int Port {
            get;
            set;
        }

        public string Host {
            get;
            set; 
        }

        public EProxyType ProxyType {
            get;
            set;
        }

        public Proxy() {
            Port = 8888;
            Host = "127.0.0.1";
            ProxyType = EProxyType.System;
        }
    }
}
