/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System;
using System.Collections.Generic;

namespace WsdlUI.App.Model.Config {
    public class Proxy : ConfigItem, Pickle.IModelPickle {
        public enum EProxyType {
            Enabled = 0
            ,Disabled = 1
            ,System = 2
        }

        int _port;
        public int Port {
            get {
                return _port;
            }
            set {
                if (value != _port) {
                    _port = value;
                    Modified = true;
                }
            }
        }

        string _host = "";
        public string Host {
            get {
                return _host;
            }
            set {
                string trimmed = value.Trim();

                if (trimmed != _host) {
                    _host = value;
                    Modified = true;
                }
            }
        }

        EProxyType _proxyType;
        public EProxyType ProxyType {
            get {
                return _proxyType;
            }
            set {
                if (value != _proxyType) {
                    _proxyType = value;
                    Modified = true;
                }
            }
        }


        public Proxy() {
            _port = 8888;
            _host = "127.0.0.1";
            _proxyType = EProxyType.System;
        }


        void Pickle.IModelPickle.Deserialize(string[] serializedData) {
            _host = serializedData[0].Replace("hostname:", "").Trim();
            _port = int.Parse(serializedData[1].Replace("port:", "").Trim());
            string proxySetting = serializedData[2].Replace("enabled:", "").Trim();

            _proxyType = (EProxyType)Enum.Parse(typeof(EProxyType), proxySetting);
        }

        //host: www.google.com
        //port: 8080
        //enabled: Enabled | Disabled | System
        string[] Pickle.IModelPickle.Serialize() {
            List<string> serializedData = new List<string>();

            serializedData.Add("hostname: " + _host);
            serializedData.Add("port: " + _port.ToString());
            serializedData.Add("enabled: " + _proxyType.ToString());

            return serializedData.ToArray();
        }


    }
}
