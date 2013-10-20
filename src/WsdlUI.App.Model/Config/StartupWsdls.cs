/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace WsdlUI.App.Model.Config {
    public class StartupWsdls : ConfigItem, Pickle.IModelPickle {
        int _maxWsdls;

        string[] _wsdls;
        public string[] Wsdls {
            get {
                return _wsdls;
            }
            set {
                if (value != _wsdls) {
                    _wsdls = value;
                    Modified = true;
                }
            }
        }

        bool _enabled;
        public bool Enabled {
            get {
                return _enabled;
            }
            set {
                if (value != _enabled) {
                    _enabled = value;
                    Modified = true;
                }
            }
        }

      
        public void AddWsdl(string wsdl) {

            if (_wsdls.Count() == _maxWsdls) {
                return;
            }

            List<string> wsdlsList = _wsdls.ToList();
            wsdlsList.Add(wsdl);
            _wsdls = wsdlsList.ToArray();

            Modified = true;
            
        }

        public void RemoveWsdl(string wsdl) {

            List<string> wsdlsList = _wsdls.ToList();
            wsdlsList.Remove(wsdl);
           _wsdls = wsdlsList.ToArray();

           if (_wsdls.Count() == 0) {
               _enabled = false;
           }

            Modified = true;

        }

        public bool ContainsWsdl(string wsdl) {
            return _wsdls.Contains(wsdl);
        }

        public StartupWsdls(int maxWsdls) {
            _maxWsdls = maxWsdls;
            _wsdls = new string[] { };
        }

        public void Deserialize(string[] serializedData) {
            List<string> wsdls = new List<string>();

            foreach (var v in serializedData) {
                if (v.StartsWith("enabled")) {
                    _enabled = bool.Parse(v.Replace("enabled:", "").Trim());
                    break;
                }

                wsdls.Add(v);
            }

            if (wsdls.Count() > _maxWsdls) {
                wsdls = wsdls.GetRange(0, _maxWsdls);
                Modified = true;
            }

            _wsdls = wsdls.ToArray();
        }

        //enabled: true | false
        public string[] Serialize() {
            List<string> serializedData = _wsdls.ToList();
            serializedData.Add("enabled: " + _enabled.ToString());
            return serializedData.ToArray();
        }

        //returns null if valid otherwise returns error message
        public static string VaildateWsdl(string wsdl) {
            if (string.IsNullOrEmpty(wsdl)) {
                return @"the uri can not be empty";
            }

            if (!wsdl.StartsWith("http") && !wsdl.StartsWith("file")) {
                return @"a vaid uri must be used for the wsdl address either file:// or http://";
            }

            Uri outUri = null;
            if (Uri.TryCreate(wsdl, UriKind.Absolute, out outUri) == false) {
                return @"invalid uri entered example valid uris file://c:/temp/fred.wsdl http://temp/temp.wsdl";
            }

            return null;
        }
    }
}
