/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Drexyia.WebSvc.Wsdl.Tests
{
    [TestFixture]
    public class ParserTests
    {
        Parser _parser;
        string _testDataDirectory;

        [SetUp]
        public void Init() {
            _parser = new Parser();
            _testDataDirectory = System.IO.Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "TestData" + Path.DirectorySeparatorChar + "Drexyia.WebSvc.Wsdl.Tests";
        }

        [Test]
        public void TestHelloWorld() {

            string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"helloworld.wsdl";
            string testDataPathRequest = _testDataDirectory + Path.DirectorySeparatorChar + @"helloworld-request.xml";
            var webSvc = _parser.Generate(testDataPath);

            Assert.AreEqual(webSvc.SourceURI, testDataPath);
            Assert.AreEqual("CallSyncOpService", webSvc.ServiceName);
            var webMethod = webSvc.WebSvcMethods["HelloWorld"];
            Assert.AreEqual(webMethod.Name, "HelloWorld");
            Assert.AreEqual(FlattenXml(webMethod.Request.Body), FlattenXml(File.ReadAllText(testDataPathRequest)));
        }

        [Test]
        public void TestUnionType() {

            try {
                string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"test-union-type.wsdl";
                string testDataPathRequest = _testDataDirectory + Path.DirectorySeparatorChar + @"test-union-type-response.xml";
                var webSvc = _parser.Generate(testDataPath);

                var webMethod = webSvc.WebSvcMethods["TestUnionType"];
                Assert.AreEqual(FlattenXml(webMethod.Response.Body), FlattenXml(File.ReadAllText(testDataPathRequest)));
            }
            catch (Exception ex) {
                Assert.Fail(ex.Message);
            }
        }

        [Test]
        [Ignore("Currently failing as does not include xml namespace for complex types")]
        public void TestHelloWorldUsingDataContract() {

            string testDataPath = _testDataDirectory + Path.DirectorySeparatorChar + @"helloworld.wsdl";
            string testDataPathRequest = _testDataDirectory + Path.DirectorySeparatorChar + @"helloworld-usingdatacontract-request.xml";
            var webSvc = _parser.Generate(testDataPath);

            Assert.AreEqual(webSvc.SourceURI, testDataPath);
            Assert.AreEqual("CallSyncOpService", webSvc.ServiceName);
            var webMethod = webSvc.WebSvcMethods["HelloWorldUsingDataContract"];
            Assert.AreEqual(webMethod.Name, "HelloWorldUsingDataContract");
            Assert.AreEqual(FlattenXml(webMethod.Request.Body), FlattenXml(File.ReadAllText(testDataPathRequest)));
        }

        //change
        //<Operation xmlns="">VOID
        //</Operation>
        //to
        //<Operation xmlns="">VOID</Operation>
        string FlattenXml(string xmlString) {
            Regex parser = new Regex(@"\s*<");
            string xmlUnformatted = parser.Replace(xmlString, "<");

            parser = new Regex(@">\s*<");
            xmlUnformatted = parser.Replace(xmlUnformatted, "><");
            return xmlUnformatted;

        }
    }
}
