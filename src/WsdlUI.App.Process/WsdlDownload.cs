/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Collections.Generic;
using System.Net;
using System.Web.Services.Description;
using System.Web.Services.Discovery;
using System.Xml.Schema;


namespace WsdlUI.App.Process {
    internal class WsdlDownload {
        string _wsdlEndpoint;
        int _timeoutInSeconds;

        internal WsdlDownload(string wsdlEndpoint, int timeoutInSeconds) {
            _wsdlEndpoint = wsdlEndpoint;
            _timeoutInSeconds = timeoutInSeconds;
        }

        internal void Download(IWebProxy webProxy, out List<ServiceDescription> descriptions, out List<XmlSchema> schemas) {

            DiscoveryClientProtocol client = new DiscoveryClientProtocol();
            client.Proxy = webProxy;

            descriptions = new List<ServiceDescription>();
            schemas = new List<XmlSchema>();

            //download document
            client.AllowAutoRedirect = true;
            client.Timeout = _timeoutInSeconds * 1000;

            client.Documents.Clear();
            client.DiscoverAny(_wsdlEndpoint);
            client.ResolveAll();

            //generate stub
            foreach (var v in client.Documents.Values) {
                if (v is ServiceDescription) {
                    descriptions.Add((ServiceDescription)v);
                }
                else if (v is XmlSchema) {
                    schemas.Add((XmlSchema)v);
                }
            }


        }

    }
}
