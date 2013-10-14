/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.IO;
using System.Reflection;

using model = WsdlUI.App.Model;
using pickle = WsdlUI.App.Model.Config.Pickle;

namespace WsdlUI.App.UI {
    public sealed class State {

        string _executingDirectoryPath;

        string _configPrevWsdlPath = Path.Combine(Consts.ConfigDirectory, "prev_wsdl.data");
        string _configPrevUrlPath = Path.Combine(Consts.ConfigDirectory, "prev_url.data");
        string _configProxyPath = Path.Combine(Consts.ConfigDirectory, "proxy.data");
        string _configUpdatePath = Path.Combine(Consts.ConfigDirectory, "update.data");
        string _configTimeoutPath = Path.Combine(Consts.ConfigDirectory, "timeout.data");
        string _configStartupWsdlsPath = Path.Combine(Consts.ConfigDirectory, "startupWsdls.data");

        public model.Config.Proxy ConfigProxy {
            get;
            private set;
        }

        public model.Config.PrevUrls ConfigPrevUrls {
            get;
            private set;
        }

        public model.Config.CallTimeout ConfigTimeout {
            get;
            private set;
        }

        public model.Config.PrevWsdls ConfigPrevWsdls {
            get;
            private set;
        }

        public model.Config.Update ConfigUpdate {
            get;
            private set;
        }

        public model.Config.StartupWsdls ConfigStartupWsdls {
            get;
            private set;
        }

        public ContainerWebSvc ContainerWebSvc {
            get;
            private set;

        }

        State() {
            ContainerWebSvc = new ContainerWebSvc();
            _executingDirectoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar;
        }

        public static State Instance {
            get {
                return Nested.instance;
            }
        }

        class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly State instance = new State();
        }

        public void Save() {
            var storageProxy = new pickle.Pickler(_executingDirectoryPath + _configProxyPath);
            var storageTimeout = new pickle.Pickler(_executingDirectoryPath + _configTimeoutPath);
            var storagePrevWsdl = new pickle.Pickler(_executingDirectoryPath + _configPrevWsdlPath);
            var storagePrevUrl = new pickle.Pickler(_executingDirectoryPath + _configPrevUrlPath);
            var storageUpdate = new pickle.Pickler(_executingDirectoryPath + _configUpdatePath);
            var storageStartupWsdls = new pickle.Pickler(_executingDirectoryPath + _configStartupWsdlsPath);

            storageTimeout.Save(ConfigTimeout);
            storageProxy.Save(ConfigProxy);
            storagePrevWsdl.Save(ConfigPrevWsdls);
            storagePrevUrl.Save(ConfigPrevUrls);
            storageUpdate.Save(ConfigUpdate);
            storageStartupWsdls.Save(ConfigStartupWsdls);
        }

        //user can clear previous saved data by deleting the file from the config location
        public void Load() {

            var storageProxy = new pickle.Pickler(_executingDirectoryPath + _configProxyPath);
            var storagePrevWsdl = new pickle.Pickler(_executingDirectoryPath + _configPrevWsdlPath);
            var storageTimeout = new pickle.Pickler(_executingDirectoryPath + _configTimeoutPath);
            var storagePrevUrl = new pickle.Pickler(_executingDirectoryPath + _configPrevUrlPath);
            var storageUpdate = new pickle.Pickler(_executingDirectoryPath + _configUpdatePath);
            var storageStartupWsdls = new pickle.Pickler(_executingDirectoryPath + _configStartupWsdlsPath);

            ConfigTimeout = new model.Config.CallTimeout();
            ConfigProxy = new model.Config.Proxy();
            ConfigPrevWsdls = new model.Config.PrevWsdls(AppConfig.Instance.MaxPrevWsdls);
            ConfigPrevUrls = new model.Config.PrevUrls(AppConfig.Instance.MaxPrevUrls);
            ConfigUpdate = new model.Config.Update();
            ConfigStartupWsdls = new model.Config.StartupWsdls(AppConfig.Instance.MaxStartupWsdls);

            storageTimeout.Load(ConfigTimeout);
            storageUpdate.Load(ConfigUpdate);
            storageProxy.Load(ConfigProxy);
            storagePrevWsdl.Load(ConfigPrevWsdls);
            storagePrevUrl.Load(ConfigPrevUrls);
            storageStartupWsdls.Load(ConfigStartupWsdls);
        }
    }
}
