/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Configuration;

namespace WsdlUI.App.UI {
    public sealed class AppConfig {

        public string DefaultWsdlPath {
            get {
                return ConfigurationManager.AppSettings["WsdlUI.App.UI.DefaultWsdlPath"];
            }
        }

        public int MaxPrevWsdls {
            get {
                return int.Parse(ConfigurationManager.AppSettings["WsdlUI.App.UI.MaxPrevWsdls"]);
            }
        }

        public int MaxPrevUrls {
            get {
                return int.Parse(ConfigurationManager.AppSettings["WsdlUI.App.UI.MaxPrevUrls"]);
            }
        }

        public int MaxStartupWsdls {
            get {
                return int.Parse(ConfigurationManager.AppSettings["WsdlUI.App.UI.MaxStartupWsdls"]);
            }
        }

        public string UpdateUrl {
            get {
                return ConfigurationManager.AppSettings["WsdlUI.App.UI.UpdateUrl"];
            }
        }

        public int WebSvcRetrieveTimeout {
            get {
                return int.Parse(ConfigurationManager.AppSettings["WsdlUI.App.UI.WebSvcRetrieveTimeout"]);
            }
        }

        public int UpdateTimeout {
            get {
                return int.Parse(ConfigurationManager.AppSettings["WsdlUI.App.UI.UpdateTimeout"]);
            }
        }

        AppConfig() {

        }

        public static AppConfig Instance {
            get {
                return Nested.instance;
            }
        }

        class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly AppConfig instance = new AppConfig();
        }
    }


}
