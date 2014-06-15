/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Threading;
using log4net;
using NUnit.Framework;
using model = Drexyia.WebSvc.Model;
using process = Drexyia.WebSvc.Process;

namespace Drexyia.WebSvc.Process.Tests {

    [TestFixture]
    public class RetrieveAsyncOpTests {

        const int RETRIEVE_TIMEOUT = 60;

        ILog _log;
        model.Proxy _proxy;

        process.WebSvcAsync.Result.RetrieveAsyncResult _testHelloWorldResult;

        [SetUp]
        public void Init() {
            
            _log = LogManager.GetLogger(typeof(RetrieveAsyncOpTests));

            _proxy = new model.Proxy();
            _proxy.ProxyType = model.Proxy.EProxyType.Disabled;
        }

        [Test]
        public void TestHelloWorld() {

            var parser = new WebSvc.Wsdl.Parser();

            var retrieve = new process.WebSvcAsync.Operations.RetrieveAsyncOp(TestDataReader.Instance.WsdlUri, RETRIEVE_TIMEOUT, parser, _proxy, _log);
            retrieve.OnComplete +=retrieve_OnComplete;
           
            var thread = new Thread(() => {
                retrieve.Start();
            });
            thread.Name = "TestHelloWorld Thread";
            thread.Start();
            thread.Join();

            Assert.AreEqual("CallSyncOpService", _testHelloWorldResult.WebSvcResult.ServiceName);

            var webMethod = _testHelloWorldResult.WebSvcResult.WebSvcMethods["HelloWorld"];
            Assert.AreEqual(webMethod.Name, "HelloWorld");
            Assert.AreEqual(TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"], webMethod.Request.BodyUnformatted);
        }

        void retrieve_OnComplete(object sender, WebSvcAsync.EventParams.AsyncArgsCompleteRetrieve e)
        {
            _testHelloWorldResult = e.Result;
        }

    }
}
