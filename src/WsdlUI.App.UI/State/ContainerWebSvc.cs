/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;
using System.Linq;

using websvcasync = WsdlUI.App.Process.WebSvcAsync;

namespace WsdlUI.App.UI {
    public class ContainerWebSvc {
        List<ContainerItemWebSvc> _webServiceItems = new List<ContainerItemWebSvc>();

        //returns the previous web service in the list for display reasons
        //returns null if no webservices left
        public UserControls.uc_SourceBrowser RemoveWebService(string key) {
            //find the item
            ContainerItemWebSvc wsItem = _webServiceItems
                .Where(x => x.Name == key)
                .Single();

            int currentIndex = _webServiceItems.IndexOf(wsItem);

            //remove the item
            _webServiceItems.RemoveAt(currentIndex);

            if (currentIndex == 0) {
                return null;
            }

            //return the previous item in the list
            currentIndex = currentIndex - 1;
            return _webServiceItems[currentIndex].wsControl;
        }

        public bool ContainsWebService(string key) {
            return _webServiceItems
                .Exists(x => x.Name == key);
        }

        public UserControls.uc_SourceBrowser GetWebService(string key) {
            return _webServiceItems
                .Where(x => x.Name == key)
                .Select(x => x.wsControl)
                .Single();
        }

        public UserControls.uc_Wm GetWebMethod(string wsKey, string wmKey) {
            ContainerItemWebSvc wsItem = _webServiceItems
                .Where(x => x.Name == wsKey)
                .Single();

            UserControls.uc_Wm wmItem = wsItem.uc_webMethods
                .Where(x => x.Key == wmKey)
                .Select(x => x.Value)
                .Single();

            return wmItem;
        }

        public void Populate(websvcasync.Result.RetrieveAsyncResult item) {
            UserControls.uc_SourceBrowser ucWebService = new UserControls.uc_SourceBrowser();
            ucWebService.PopulateForm(item.WebSvcResult.WSDL);

            Dictionary<string, UserControls.uc_Wm> ucWebMethods = new Dictionary<string, UserControls.uc_Wm>();
            foreach (var v in item.WebSvcResult.WebSvcMethods) {
                UserControls.uc_Wm ucWebMethod = new UserControls.uc_Wm();
                ucWebMethod.PopulateForm(item.WebSvcResult.SourceURI, v.Value);
                ucWebMethods[v.Key] = ucWebMethod;
            }

            ContainerItemWebSvc wsItem = new ContainerItemWebSvc(item.WebSvcResult.SourceURI, ucWebService, ucWebMethods);

            _webServiceItems.Add(wsItem);
        }
    }
}
