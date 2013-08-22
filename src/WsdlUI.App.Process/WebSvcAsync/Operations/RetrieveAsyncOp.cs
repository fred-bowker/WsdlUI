/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.Web.Services.Description;
using System.Xml.Schema;

using model = WsdlUI.App.Model;
using process = WsdlUI.App.Process;
using websvcasync = WsdlUI.App.Process.WebSvcAsync;
using websvcgenerate = WsdlUI.App.Process.WebSvcGenerate;

namespace WsdlUI.App.Process.WebSvcAsync.Operations {
    public class RetrieveAsyncOp : AsyncOp {

        WsdlDownload _downloader;
        string _webSvcPath;

        public event EventHandler<websvcasync.EventParams.RetrieveCompleteAsyncArgs> OnComplete;

        public RetrieveAsyncOp(string webSvcPath, model.Config.Proxy configProxy, int timeoutPeriod)
            : base(webSvcPath, configProxy, timeoutPeriod) {

            _webSvcPath = webSvcPath;
            _downloader = new WsdlDownload(webSvcPath, timeoutPeriod);
        }

        protected override void Work() {

   Logger.Instance.Log.Info("Start: " + _webSvcPath);

            List<ServiceDescription> descriptions;
            List<XmlSchema> schemas;
            _downloader.Download(base.WebProxy, out descriptions, out schemas);

            if (base.HasTimedOut) {
                return;
            }

            websvcgenerate.Generator generator = new websvcgenerate.Generator(_webSvcPath, descriptions, schemas);
            var webSvc = generator.Generate();

            if (base.HasTimedOut) {
                return;
            }

            //success
            if (OnComplete != null) {

                OnComplete(this, new process.WebSvcAsync.EventParams.RetrieveCompleteAsyncArgs(_webSvcPath,
                        new process.WebSvcAsync.Result.RetrieveAsyncResult(webSvc)
                        ));
            }
        }

        protected override void TearDown() {
        }

    }
}
