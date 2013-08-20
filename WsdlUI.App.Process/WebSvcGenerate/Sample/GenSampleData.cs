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
using System.Xml.Serialization;

using model = WsdlUI.App.Model;

namespace WsdlUI.App.Process.WebSvcGenerate.Sample {
    public class GenSampleData {
        string _serviceURI;
        List<ServiceDescription> _descriptions;
        List<XmlSchema> _schemas;

        public GenSampleData(string serviceURI, List<ServiceDescription> descriptions, List<XmlSchema> schemas) {
            _serviceURI = serviceURI;
            _descriptions = descriptions;
            _schemas = schemas;
        }

        public Dictionary<string, model.WebSvcMethod> GenerateSampleData() {
            Dictionary<string, model.WebSvcMethod> results = new Dictionary<string, model.WebSvcMethod>();

            List<string> methodList = GetMethodList();

            foreach (string method in methodList) {
                ServiceDescriptionCollection descCol = new ServiceDescriptionCollection();
                foreach (ServiceDescription sd in _descriptions) {
                    descCol.Add(sd);
                }

                XmlSchemas schemaCol;
                if (_schemas.Count > 0) {
                    schemaCol = new XmlSchemas();
                    foreach (XmlSchema sc in _schemas) {
                        schemaCol.Add(sc);
                    }
                }
                else {
                    schemaCol = descCol[0].Types.Schemas;
                }

                string req;
                SampleGeneratorWebSvc sg = new SampleGeneratorWebSvc(descCol, schemaCol);
                sg.GenerateMessages(method, null, "Soap", out req);

                model.WebSvcMethod webMethod = new model.WebSvcMethod(method, req, _serviceURI);
                results[method] = webMethod;
            }

            return results;
        }

        List<string> GetMethodList() {
            List<string> methodList = new List<string>();

            foreach (var description in _descriptions) {
                foreach (PortType portType in description.PortTypes) {
                    foreach (Operation operation in portType.Operations) {
                        methodList.Add(operation.Name);
                    }
                }
            }

            return methodList;
        }

    }
}
