/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using log4net;
using NUnit.Framework;
using model = Drexyia.WebSvc.Model;
using process = Drexyia.WebSvc.Process;

namespace Drexyia.WebSvc.Process.Tests {

    [TestFixture]
    public class CallSyncOpTests {

        const int RETRIEVE_TIMEOUT = 60;
     
        ILog _log;
        model.Proxy _proxy;

        [SetUp]
        public void Init() {
            _log = LogManager.GetLogger(typeof(CallSyncOpTests));

            _proxy = new model.Proxy();
            _proxy.ProxyType = model.Proxy.EProxyType.Disabled;
        }

        [Test]
        [Ignore ("fiddler proxy must be running for this test to pass")]
        public void TestHelloWorldProxy() {

            var webMethod = new model.WebSvcMethod("HelloWorld", TestDataReader.Instance.ServiceUriProxy);
            webMethod.Request = new model.WebSvcMessageRequest();
            webMethod.Request.Headers[model.WebSvcMessageRequest.HEADER_NAME_SOAP_ACTION] = "http://tempuri.org/ICallSyncOpService/HelloWorld";
            webMethod.Request.Body = TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"];

            var proxy = new model.Proxy();
            proxy.ProxyType = model.Proxy.EProxyType.Enabled;
            proxy.Host = @"127.0.0.1";
            proxy.Port = 8888;

            var call = new process.WebSvcSync.Operations.CallSyncOp(webMethod, RETRIEVE_TIMEOUT, proxy, _log);
            webMethod.Response = call.Work();

            Assert.AreEqual(webMethod.Response.BodyUnformatted, TestDataReader.Instance.RequestResponseMessages["HelloWorldResponse"]);
            Assert.AreEqual(webMethod.Response.Status, "200 OK");
        }

        [Test]
        public void TestHelloWorld() {

            var webMethod = new model.WebSvcMethod("HelloWorld", TestDataReader.Instance.ServiceUri);
            webMethod.Request = new model.WebSvcMessageRequest();
            webMethod.Request.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE] = "text/xml; charset=utf-8";
            webMethod.Request.Headers[model.WebSvcMessageRequest.HEADER_NAME_SOAP_ACTION] = "http://tempuri.org/ICallSyncOpService/HelloWorld";
            webMethod.Request.Body = TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"];

            var call = new process.WebSvcSync.Operations.CallSyncOp(webMethod);
            webMethod.Response = call.Work();

            var contentLengthResult = webMethod.Response.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_LENGTH];
            var contentTypeResult = webMethod.Response.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE];

            Assert.AreEqual("211", contentLengthResult);
            Assert.AreEqual("text/xml; charset=utf-8", contentTypeResult);
            Assert.AreEqual(webMethod.Response.BodyUnformatted, TestDataReader.Instance.RequestResponseMessages["HelloWorldResponse"]);
            Assert.AreEqual(webMethod.Response.Status, "200 OK");
		}

        [Test]
        public void TestHelloWorldStatus201()
        {

            var webMethod = new model.WebSvcMethod("HelloWorldStatus201", TestDataReader.Instance.ServiceUri);
            webMethod.Request = new model.WebSvcMessageRequest();
            webMethod.Request.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE] = "text/xml; charset=utf-8";
            webMethod.Request.Headers[model.WebSvcMessageRequest.HEADER_NAME_SOAP_ACTION] = "http://tempuri.org/ICallSyncOpService/HelloWorldStatus201";
            webMethod.Request.Body = TestDataReader.Instance.RequestResponseMessages["HelloWorld201Request"];

            var call = new process.WebSvcSync.Operations.CallSyncOp(webMethod);
            webMethod.Response = call.Work();

            Assert.AreEqual("201 Created", webMethod.Response.Status);
        }
       
        [Test]
        public void TestHelloWorldMex() {

            var webMethod = new model.WebSvcMethod("HelloWorld", TestDataReader.Instance.ServiceUriMex);
            webMethod.Request = new model.WebSvcMessageRequest();
            webMethod.Request.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE] = "text/xml; charset=utf-8";
            webMethod.Request.Headers[model.WebSvcMessageRequest.HEADER_NAME_SOAP_ACTION] = "http://tempuri.org/ICallSyncOpServiceMex/HelloWorld";
            webMethod.Request.Body = TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"];

            var call = new process.WebSvcSync.Operations.CallSyncOp(webMethod);
            webMethod.Response = call.Work();

            var contentLengthResult = webMethod.Response.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_LENGTH];
            var contentTypeResult = webMethod.Response.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE];

            Assert.AreEqual("211", contentLengthResult);
            Assert.AreEqual("text/xml; charset=utf-8", contentTypeResult);
            Assert.AreEqual(webMethod.Response.BodyUnformatted, TestDataReader.Instance.RequestResponseMessages["HelloWorldResponse"]);
            Assert.AreEqual(webMethod.Response.Status, "200 OK");
        }
    }
}
