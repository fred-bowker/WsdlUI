/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;
using System.Web.Services.Description;
using System.Xml.Schema;
using model = WsdlUI.App.Model;
using process = WsdlUI.App.Process;

namespace WsdlUI.App.Process.WebSvcGenerate {
    class Generator {

        List<ServiceDescription> _descriptions;
        List<XmlSchema> _schemas;
        string _webSvcSource;

        public Generator(string webSvcSource, List<ServiceDescription> descriptions, List<XmlSchema> schemas) {
            _webSvcSource = webSvcSource;
            _descriptions = descriptions;
            _schemas = schemas;
        }

        public model.WebSvc Generate() {
   process.Logger.Instance.Log.Info ("Start: " + _webSvcSource);

            var wsdlGenerator = new GenWsdlData(_descriptions[0]);
            string wsdlContent = wsdlGenerator.Generate();

            var metaData = new GenMetaData(_descriptions[0]);
            metaData.Parse();

            var sampleData = new Sample.GenSampleData(metaData.ServiceURI, _descriptions, _schemas);
            Dictionary<string, model.WebSvcMethod> webSvcMethods = sampleData.GenerateSampleData();

            return new model.WebSvc(_webSvcSource, metaData.Name, wsdlContent, webSvcMethods);

        }
    }
}
