/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Threading;

using NUnit.Framework;
using model = Drexyia.WebSvc.Model;
using process = Drexyia.WebSvc.Process;

namespace Drexyia.WebSvc.Process.Tests {

    [TestFixture]
    public class CallAsyncOpTests {

        const int RETRIEVE_TIMEOUT = 60;
        model.Proxy _proxy;

        process.WebSvcAsync.Result.CallAsyncResult _testHelloWorldResult;

        [SetUp]
        public void Init() {

            _proxy = new model.Proxy();
            _proxy.ProxyType = model.Proxy.EProxyType.Disabled;
        }

        [Test]
        public void TestHelloWorld() {

            var webMethod = new model.WebSvcMethod("HelloWorld", TestDataReader.Instance.ServiceUri);
            webMethod.Request = new model.WebSvcMessageRequest();
            webMethod.Request.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE] = "text/xml; charset=utf-8";
            webMethod.Request.Headers[model.WebSvcMessageRequest.HEADER_NAME_SOAP_ACTION] = "http://tempuri.org/ICallSyncOpService/HelloWorld";
            webMethod.Request.Body = TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"];

            var call = new process.WebSvcAsync.Operations.CallAsyncOp(webMethod);
            call.OnComplete += call_OnComplete;

            var thread = new Thread(() => {
                call.Start();
            });
            thread.Name = "TestHelloWorld Thread";
            thread.Start();
            thread.Join();

            var contentLengthResult = _testHelloWorldResult.Response.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_LENGTH];
            var contentTypeResult = _testHelloWorldResult.Response.Headers[model.WebSvcMessage.HEADER_NAME_CONTENT_TYPE];

            Assert.AreEqual("211", contentLengthResult);
            Assert.AreEqual("text/xml; charset=utf-8", contentTypeResult);
            Assert.AreEqual(_testHelloWorldResult.Response.BodyUnformatted, TestDataReader.Instance.RequestResponseMessages["HelloWorldResponse"]);
            Assert.AreEqual(_testHelloWorldResult.Response.Status, "200 OK");
        }

        void call_OnComplete(object sender, WebSvcAsync.EventParams.AsyncArgsCompleteCall e) {
            
            _testHelloWorldResult = e.Result;
        }

    }
}
