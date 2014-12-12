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
    public class PrevUrls : ConfigItem, Pickle.IModelPickle {

        int _maxItems;
        Dictionary<string, Dictionary<string, List<string>>> _prev;

        public string[] GetPrev(string webSvcSource, string webSvcMethod) {

            Dictionary<string, List<string>> webSvcMapUrl;
            if (_prev.TryGetValue(webSvcSource, out webSvcMapUrl)) {

                List<string> urls;
                if (webSvcMapUrl.TryGetValue(webSvcMethod, out urls)) {
                    return urls.ToArray();
                }
                else {
                    return new string[] { };
                }
            }
            else {
                return new string[] { };
            }

        }

        public PrevUrls(int maxItems) {
            _maxItems = maxItems;
            _prev = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        public void Add(string webSvcSrc, string webSvcMethod, string url) {
            Modified = true;

            AddItem(webSvcSrc, webSvcMethod, url);
        }

        //http://www.webservicex.net/globalweather.asmx?WSDL||GetWeather||http://www.webservicex.net/globalweather.asmx
        void Pickle.IModelPickle.Deserialize(string[] serializedData) {

            //AddItem adds each item to the start of the list, the file stores the most recent url first
            //inorder to display the urls in the correct access order reverse the list
            foreach (var line in serializedData.Reverse()) {

                string[] splitLines = line.Split("||".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
                string webSvcSrc = splitLines[0];
                string webSvcMethod = splitLines[1];
                string url = splitLines[2];

                AddItem(webSvcSrc, webSvcMethod, url);

            }
        }

        string[] Pickle.IModelPickle.Serialize() {

            List<string> serializedUrls = new List<string>();

            string formatString = "{0}||{1}||{2}";

            foreach (var webSvcMapUrl in _prev) {
                string webSvcSrc = webSvcMapUrl.Key;

                foreach (var webMethodMapUrl in webSvcMapUrl.Value) {
                    string webMethod = webMethodMapUrl.Key;

                    foreach (var url in webMethodMapUrl.Value) {

                        string line = string.Format(formatString, webSvcSrc, webMethod, url);
                        serializedUrls.Add(line);
                    }
                }
            }
            return serializedUrls.ToArray();
        }

        void AddItem(string webSvcSrc, string webSvcMethod, string url) {

            Dictionary<string, List<string>> webSvcMapUrl;
            if (_prev.TryGetValue(webSvcSrc, out webSvcMapUrl)) {

                List<string> urls;
                if (webSvcMapUrl.TryGetValue(webSvcMethod, out urls)) {

                    //remove so that it is added to the start of the list
                    if (urls.Contains(url)) {
                        urls.Remove(url);
                        urls.Insert(0, url);
                        return;
                    }

                    if (urls.Count() == _maxItems) {
                        urls.RemoveAt(_maxItems - 1);

                        //this method is called when Deserialize the urls and after a web service is called. If the url is changed during 
                        //Deserialize set to modified so that these changes are saved when the progran closses
                        Modified = true;
                    }

                    urls.Insert(0, url);
                }
                else {
                    urls = new List<string>();
                    urls.Add(url);
                    webSvcMapUrl[webSvcMethod] = urls;
                }

            }
            else {

                List<string> urls = new List<string>();
                urls.Add(url);

                webSvcMapUrl = new Dictionary<string, List<string>>();
                webSvcMapUrl[webSvcMethod] = urls;

                _prev[webSvcSrc] = webSvcMapUrl;

            }

        }
    }
}
