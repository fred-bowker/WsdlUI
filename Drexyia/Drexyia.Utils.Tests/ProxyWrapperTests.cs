/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Net;

using NUnit.Framework;

using model = Drexyia.WebSvc.Model;

namespace Drexyia.Utils.Tests
{
    [TestFixture]
    public class ProxyWrapperTests
    {
        [Test]
        public void TestGetWebProxy() {

            //test 1 check that we can successfully get the system proxy, on linux system wide proxy is not used
            model.Proxy proxy = new model.Proxy();
            proxy.ProxyType = model.Proxy.EProxyType.System;
            WebProxy webProxy = Drexyia.Utils.ProxyWrapper.GetWebProxy(proxy);
    
            Assert.IsNotNull(webProxy);
        }
    }
}
