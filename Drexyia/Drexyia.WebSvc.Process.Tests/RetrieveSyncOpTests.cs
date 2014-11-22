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
    public class RetrieveSyncOpTests {

        const int RETRIEVE_TIMEOUT = 60;

        ILog _log;
        model.Proxy _proxy;
    
        [SetUp]
        public void Init() {

            _log = LogManager.GetLogger(typeof(RetrieveSyncOpTests));

            _proxy = new model.Proxy();
            _proxy.ProxyType = model.Proxy.EProxyType.Disabled;
        }
			
		// The web service that this runs against includes the xsd as seperate documents in the wsdl
		// There is currently a bug in handling multiple xsds in the wsdl
        [Test]
		#if __MonoCS__
		[Ignore ("Currently failing on mono")]
		#endif
		//TODO: Fix this bug on mono.
		public void TestHelloWorldSeperate() {
			TestHelloWorld (TestDataReader.Instance.WsdlUri);
        }

		[Test]
		public void TestHelloWorldSingle() {
			TestHelloWorld (TestDataReader.Instance.WsdlUriSingle);
		}

		void TestHelloWorld(string uri) {

			var parser = new WebSvc.Wsdl.Parser();

			var retrieve = new process.WebSvcSync.Operations.RetrieveSyncOp(uri, RETRIEVE_TIMEOUT, parser, _proxy, _log);
			var _webSvcData = retrieve.Work();

			Assert.AreEqual("CallSyncOpService", _webSvcData.ServiceName);
			var webMethod = _webSvcData.WebSvcMethods["HelloWorld"];
			Assert.AreEqual(webMethod.Name, "HelloWorld");

			Assert.AreEqual(TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"], webMethod.Request.BodyUnformatted);

		}
			
        [Test]
		#if __MonoCS__
		[Ignore ("Currently failing on mono")]
		#endif
		//TODO: Fix this bug on mono
        public void TestHelloWorldMex() {

            var parser = new WebSvc.Wsdl.Parser();
            
            var retrieve = new process.WebSvcSync.Operations.RetrieveSyncOp(TestDataReader.Instance.MexUri, RETRIEVE_TIMEOUT, parser, _proxy, _log);
            var _webSvcData = retrieve.Work();

            Assert.AreEqual("CallSyncOpServiceMex", _webSvcData.ServiceName);
            var webMethod = _webSvcData.WebSvcMethods["HelloWorld"];
            Assert.AreEqual(webMethod.Name, "HelloWorld");
            Assert.AreEqual(TestDataReader.Instance.RequestResponseMessages["HelloWorldRequest"], webMethod.Request.BodyUnformatted);
        }
    }
}
