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
        int _maxItems;
        List<string> _prev;

        public string[] WsdlList {
            get {
                return _prev.ToArray();
            }
        }

        public PrevWsdls(int maxPrevWsdls) {
            _maxItems = maxPrevWsdls;
            _prev = new List<string>();
        }

        public void Add(string wsdlFile) {
            Modified = true;

            AddItem(wsdlFile);
        }

        void Pickle.IModelPickle.Deserialize(string[] serializedData) {

            //AddItem adds each item to the start of the list, the file stores the most recent wsdl first
            //inorder to display the wsdls in the correct access order reverse the list
            foreach (string line in serializedData.Reverse()) {
                AddItem(line);
            }
        }

        void AddItem(string wsdlFile) {

            //remove so that it is added to the start of the list
            if (_prev.Contains(wsdlFile)) {
                _prev.Remove(wsdlFile);
                _prev.Insert(0, wsdlFile);
                return;
            }

            if (_prev.Count() == _maxItems) {
                _prev.RemoveAt(_maxItems - 1);

                //this method is called when Deserialize the urls and after a web service is called. If the url is changed during 
                //Deserialize set to modified so that these changes are saved when the progran closses
                Modified = true;
            }

            _prev.Insert(0, wsdlFile);
        }


        string[] Pickle.IModelPickle.Serialize() {
            return _prev.ToArray();
        }



    }
}
