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
using log4net;
using model = Drexyia.WebSvc.Model;
using process = Drexyia.WebSvc.Process;
using wsdl = Drexyia.WebSvc.Wsdl;

namespace Drexyia.WebSvc.Process.WebSvcAsync.Operations {

    public class RetrieveAsyncOp : AsyncOp {

        const int DEFAULT_TIMEOUT = 25;

        WsdlDownload _downloader;
        wsdl.Parser _parser;
        string _webSvcPath;

        public event EventHandler<process.WebSvcAsync.EventParams.AsyncArgsCompleteRetrieve> OnComplete;

        public RetrieveAsyncOp(string webSvcPath, wsdl.Parser parser)
            : base(webSvcPath, DEFAULT_TIMEOUT) {

            _webSvcPath = webSvcPath;
            _downloader = new WsdlDownload(webSvcPath, DEFAULT_TIMEOUT);
            _parser = parser;
        }

        public RetrieveAsyncOp(string webSvcPath, int timeoutPeriod, wsdl.Parser parser, model.IProxy configProxy, ILog log)
            : base(webSvcPath, timeoutPeriod, configProxy, log) {

            _webSvcPath = webSvcPath;
            _downloader = new WsdlDownload(webSvcPath, timeoutPeriod);
            _parser = parser;
        }

        protected override void Work() {

            DateTime startTime = DateTime.Now;

            base.Log.Info("Start: " + _webSvcPath);

            List<ServiceDescription> descriptions;
            List<XmlSchema> schemas;
            bool descriptionsFound = _downloader.Download(base.Proxy, out descriptions, out schemas);

            if (base.HasTimedOut) {
                return;
            }

            if (!descriptionsFound) {
                throw new SvcDescsNotFoundException();    
            }

            var webSvc = _parser.Generate(_webSvcPath, descriptions, schemas);

            if (base.HasTimedOut) {
                return;
            }

            //success
            if (OnComplete != null) {

                DateTime endTime = DateTime.Now;

                OnComplete(this, new process.WebSvcAsync.EventParams.AsyncArgsCompleteRetrieve(_webSvcPath, startTime, endTime,
                        new process.WebSvcAsync.Result.RetrieveAsyncResult(webSvc)
                        ));
            }
        }

        protected override void TearDown() {
        }

    }
}
