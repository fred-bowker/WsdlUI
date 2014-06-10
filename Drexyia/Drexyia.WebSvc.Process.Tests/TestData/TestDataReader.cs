/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Drexyia.WebSvc.Process.Tests {
    public sealed class TestDataReader {

        private static volatile TestDataReader instance;
        private static object syncRoot = new Object();

        public string WsdlUri {
            get;
            private set;
        }

        public string MexUri {
            get;
            private set;
        }

        public string ServiceUri {
            get;
            private set;
        }

        public string ServiceUriProxy {
            get;
            private set;
        }

           public string ServiceUriMex {
            get;
            private set;
        }

        Dictionary<string, string> _requestResponseMessages = new Dictionary<string, string>();
        public Dictionary<string, string> RequestResponseMessages {
            get {
                return _requestResponseMessages;
            }
        }

        private TestDataReader() {

            var testDataDirectory = Directory.GetCurrentDirectory()
                + Path.DirectorySeparatorChar + "TestData"
                + Path.DirectorySeparatorChar + "Drexyia.WebSvc.Process.Tests";
            
            _requestResponseMessages["HelloWorldRequest"] = FlattenXml(File.ReadAllText(testDataDirectory + Path.DirectorySeparatorChar + "hello-world-request.xml"));
            _requestResponseMessages["HelloWorldResponse"] = FlattenXml(File.ReadAllText(testDataDirectory + Path.DirectorySeparatorChar + "hello-world-response.xml"));
            _requestResponseMessages["HelloWorld201Request"] = FlattenXml(File.ReadAllText(testDataDirectory + Path.DirectorySeparatorChar + "hello-world-201-request.xml"));

            ServiceUri = ConfigurationManager.AppSettings["TestServiceUri"];
            ServiceUriProxy = ConfigurationManager.AppSettings["TestServiceUriProxy"];
            WsdlUri = ServiceUri + "?wsdl";
            ServiceUriMex = ConfigurationManager.AppSettings["TestServiceUriMex"];
            MexUri = ServiceUriMex + "mex";

        }

        public static TestDataReader Instance {
            get {
                if (instance == null) {
                    lock (syncRoot) {
                        if (instance == null)
                            instance = new TestDataReader();
                    }
                }

                return instance;
            }
        }

        string FlattenXml(string xml) {
            Regex parser = new Regex(@"\s*<");
            string xmlUnformatted = parser.Replace(xml, "<");

            parser = new Regex(@">\s*<");
            xmlUnformatted = parser.Replace(xmlUnformatted, "><");
            return xmlUnformatted;
        }
    }
}
