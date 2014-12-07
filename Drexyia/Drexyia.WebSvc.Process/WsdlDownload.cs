/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Web.Services.Discovery;
using System.Xml.Schema;
using model = Drexyia.WebSvc.Model;
using utils = Drexyia.Utils;
using wsdlDescription = System.Web.Services.Description;

namespace Drexyia.WebSvc.Process {

    internal class WsdlDownload {
        string _wsdlEndpoint;
        int _timeoutInSeconds;

        internal WsdlDownload(string wsdlEndpoint, int timeoutInSeconds) {
            _wsdlEndpoint = wsdlEndpoint;
            _timeoutInSeconds = timeoutInSeconds;
        }

        //returns true if service descriptions are retrieved
        //returns false if 0 service descriptions found, this signifies that the end point is not a web service description
        internal bool Download(model.IProxy proxy, out List<wsdlDescription.ServiceDescription> descriptions, out List<XmlSchema> schemas) {
            
            descriptions = new List<wsdlDescription.ServiceDescription>();
            schemas = new List<XmlSchema>();

            if (_wsdlEndpoint.StartsWith("file")) {
                DownloadFile(out descriptions, out schemas);
            }
            else {
                DownloadWeb(proxy, out descriptions, out schemas);
            }

            return (descriptions.Count > 0);

        }

        //MetadataExchangeClient can only download data from a local wsdl file, if it is a file we user the DiscoveryClientProtocol
        void DownloadFile(out List<wsdlDescription.ServiceDescription> descriptions, out List<XmlSchema> schemas) {
            
            descriptions = new List<wsdlDescription.ServiceDescription>();
            schemas = new List<XmlSchema>();

            DiscoveryClientProtocol client = new DiscoveryClientProtocol();
            
            //download document
            client.AllowAutoRedirect = true;
            client.Timeout = _timeoutInSeconds * 1000;

            client.Documents.Clear();
            client.DiscoverAny(_wsdlEndpoint);

            client.ResolveAll();

            foreach (var v in client.Documents.Values) {
                if (v is wsdlDescription.ServiceDescription) {
                    descriptions.Add((wsdlDescription.ServiceDescription)v);
                }
                else if (v is XmlSchema) {
                    schemas.Add((XmlSchema)v);
                }
            }
        }

#if __MonoCS__ 

        //TODO: FB client.GetMetadata is not working working on linux, instead use DiscoveryClientProtocol.
            //this means that mex bindings are currently not supported on linux
        void DownloadWeb(model.IProxy proxy, out List<wsdlDescription.ServiceDescription> descriptions, out List<XmlSchema> schemas) {

            DiscoveryClientProtocol client = new DiscoveryClientProtocol();

            if (proxy.ProxyType == model.Proxy.EProxyType.Enabled) {

                client.Proxy = new System.Net.WebProxy(proxy.Host, proxy.Port);
                client.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials; 
            }

            descriptions = new List<wsdlDescription.ServiceDescription>();
            schemas = new List<XmlSchema>();

            //download document
            client.AllowAutoRedirect = true;
            client.Timeout = _timeoutInSeconds * 1000;

            client.Documents.Clear();
            client.DiscoverAny(_wsdlEndpoint);
            client.ResolveAll();

            //generate stub
            foreach (var v in client.Documents.Values) {
                if (v is wsdlDescription.ServiceDescription) {
                    descriptions.Add((wsdlDescription.ServiceDescription)v);
                }
                else if (v is XmlSchema) {
                    schemas.Add((XmlSchema)v);
                }
            }
        }

#else

        void DownloadWeb(model.IProxy proxy, out List<wsdlDescription.ServiceDescription> descriptions, out List<XmlSchema> schemas) {

            descriptions = new List<wsdlDescription.ServiceDescription>();
            schemas = new List<XmlSchema>();

            MetadataExchangeClient client;
            MetadataExchangeClientMode exchangeMode;

            if (_wsdlEndpoint.EndsWith("mex")) {

                WSHttpBinding mexBinding = utils.BindingWrapper.GetMexBinding(proxy);

                client = new MetadataExchangeClient(mexBinding);
                exchangeMode = MetadataExchangeClientMode.MetadataExchange;
            }
            else {

                BasicHttpBinding wsdlBinding = utils.BindingWrapper.GetWsdlBinding(proxy);

                client = new MetadataExchangeClient(wsdlBinding);
                exchangeMode = MetadataExchangeClientMode.HttpGet;

            }

            client.ResolveMetadataReferences = true;
            client.OperationTimeout = new TimeSpan(0, 0, _timeoutInSeconds);

            MetadataSet metadata = client.GetMetadata(new Uri(_wsdlEndpoint), exchangeMode);

            foreach (var metaDataSection in metadata.MetadataSections) {
                if (metaDataSection.Metadata is wsdlDescription.ServiceDescription) {
                    descriptions.Add((wsdlDescription.ServiceDescription)metaDataSection.Metadata);
                }
                else if (metaDataSection.Metadata is XmlSchema) {
                    schemas.Add((XmlSchema)metaDataSection.Metadata);
                }
            }
        }

    #endif

    }
}
