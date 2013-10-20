/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;

namespace WsdlUI.App.Model.Config {
    public class CallTimeout : ConfigItem, Pickle.IModelPickle {

        int _timeout;
        public int Timeout {
            get {
                return _timeout;
            }
            set {
                if (value != _timeout) {
                    _timeout = value;
                    Modified = true;
                }
            }
        }

        public CallTimeout() {
            _timeout = 60;
        }

        void Pickle.IModelPickle.Deserialize(string[] serializedData) {
            _timeout = int.Parse(serializedData[0].Replace("timeout:", "").Trim());
        }

        //timeout: 60
        string[] Pickle.IModelPickle.Serialize() {
            List<string> serializedData = new List<string>();
            serializedData.Add("timeout: " + _timeout);
            return serializedData.ToArray();
        }


    }
}
