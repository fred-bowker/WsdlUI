/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;
using System.Web.Services.Discovery;
using System.Xml.Schema;
using log4net;
using model = Drexyia.WebSvc.Model;
using wsdlDescription = System.Web.Services.Description;

namespace Drexyia.WebSvc.Wsdl {
    
    public class Parser {
        ILog _log;

        public Parser() {
            _log = LogManager.GetLogger(typeof(Parser)); ;
        }

        public Parser(ILog log) {
            _log = log;
        }

        public model.WebSvc Generate(string filePath) {

            List<wsdlDescription.ServiceDescription> descriptions = new List<wsdlDescription.ServiceDescription>();
            List<XmlSchema> schemas = new List<XmlSchema>();

            DiscoveryClientProtocol client = new DiscoveryClientProtocol();

            //load Document from file
            client.AllowAutoRedirect = true;
            client.Documents.Clear();
            client.DiscoverAny(filePath);
            client.ResolveAll();

            foreach (var v in client.Documents.Values) {
                if (v is wsdlDescription.ServiceDescription) {
                    descriptions.Add((wsdlDescription.ServiceDescription)v);
                }
                else if (v is XmlSchema) {
                    schemas.Add((XmlSchema)v);
                }
            }

            return Generate(filePath, descriptions, schemas);
        }

        public model.WebSvc Generate(string webSvcPath, List<wsdlDescription.ServiceDescription> descriptions, List<XmlSchema> schemas) {

            _log.Info("Start: " + webSvcPath);

            var wsdlGenerator = new GenWsdlData(descriptions[0]);
            string wsdlContent = wsdlGenerator.Generate();

            var metaData = new GenMetaData(descriptions[0]);
            metaData.Parse();

            var sampleData = new Sample.GenSampleData(metaData.ServiceURI, descriptions, schemas);
            model.WebSvcMethodContainer webSvcMethods = sampleData.GenerateSampleData();

            return new model.WebSvc(webSvcPath, metaData.Name, wsdlContent, webSvcMethods);
        }

    }
}
