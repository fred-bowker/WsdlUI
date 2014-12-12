/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Net;
using System.Reflection;

using model = Drexyia.WebSvc.Model;

namespace Drexyia.Utils {

    public class ProxyWrapper {

        //System wide proxy settings are not implemented for linux, instead proxy settings must be explicitly set.
        public static WebProxy GetWebProxy(model.IProxy proxy) {

            WebProxy webProxy;

            switch (proxy.ProxyType) {
                case model.Proxy.EProxyType.Disabled:

                    return null;

                case model.Proxy.EProxyType.Enabled:

                    webProxy = new WebProxy(proxy.Host, proxy.Port);
                    webProxy.Credentials = CredentialCache.DefaultCredentials;
                    return webProxy;

                case model.Proxy.EProxyType.System:

#if __MonoCS__           
                     return new WebProxy();
#else
                    //Bug fix: WebRequest.GetSystemWebProxy throws a null reference exception on Windows 7 x64.
                    //WebRequest.DefaultWebProxy uses a proxy if set in the web.config otherwise uses the system wide proxy settings from IE
                    webProxy = ConvertToWebProxy(WebRequest.DefaultWebProxy);
                    webProxy.Credentials = CredentialCache.DefaultCredentials;
                    return webProxy;
#endif
                default:

                    return null;
            }
        }

        //IWebProxy does not give access to the underlying WebProxy it returns type WebProxyWrapper
        //the underlying webproxy is needed in order to use the proxy address, the following uses reflecion to cast to WebProxy
        static WebProxy ConvertToWebProxy(IWebProxy proxyWrapper) {

            PropertyInfo propertyInfo = proxyWrapper.GetType().GetProperty("WebProxy", BindingFlags.NonPublic | BindingFlags.Instance);
            WebProxy wProxy = (WebProxy)propertyInfo.GetValue(proxyWrapper, null);

            return wProxy;
        }



    }
}
