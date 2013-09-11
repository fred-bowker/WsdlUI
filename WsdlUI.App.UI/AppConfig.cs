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

        public int WebSvcCallTimeout {
            get {
                return int.Parse(ConfigurationManager.AppSettings["WsdlUI.App.UI.WebSvcCallTimeout"]);
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
