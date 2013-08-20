/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/


using System.Collections.Generic;
using System.Linq;

namespace WsdlUI.App.Model.Config {
    public class PrevWsdls : ConfigItem, Pickle.IModelPickle {
        int _maxPrevWsdls;
        List<string> _prevWsdls;

        public string[] WsdlList {
            get {
                return _prevWsdls.ToArray();
            }
        }

        public PrevWsdls(int maxPrevWsdls) {
            _maxPrevWsdls = maxPrevWsdls;
            _prevWsdls = new List<string>();
        }

        public void Add(string wsdlFile) {
            Modified = true;

            //remove so that it is added to the start of the list
            if (_prevWsdls.Contains(wsdlFile)) {
                _prevWsdls.Remove(wsdlFile);
                _prevWsdls.Insert(0, wsdlFile);
                return;
            }

            if (_prevWsdls.Count() == _maxPrevWsdls) {
                _prevWsdls.RemoveAt(_maxPrevWsdls - 1);
            }

            _prevWsdls.Insert(0, wsdlFile);
        }

        void Pickle.IModelPickle.Deserialize(string[] serializedData) {
            _prevWsdls = serializedData.ToList();

            if (serializedData.Count() > _maxPrevWsdls) {
                _prevWsdls = _prevWsdls.GetRange(0, _maxPrevWsdls);
                Modified = true;
            }
        }

        string[] Pickle.IModelPickle.Serialize() {
            return _prevWsdls.ToArray();
        }



    }
}
