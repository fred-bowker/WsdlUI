/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Net;
using System.ServiceModel;

using model = Drexyia.WebSvc.Model;

namespace Drexyia.Utils {
    public class BindingWrapper {

        public static WSHttpBinding GetMexBinding(model.IProxy proxy) {

            WSHttpBinding binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.None;

            if (proxy.ProxyType == model.Proxy.EProxyType.System) {
                binding.UseDefaultWebProxy = true;
            }
            else {
                WebProxy webProxy = ProxyWrapper.GetWebProxy(proxy);

                binding.UseDefaultWebProxy = false;
                if (proxy.ProxyType == model.Proxy.EProxyType.Enabled) {
                    binding.ProxyAddress = webProxy.Address;
                }
            }

            return binding;
        }

        public static BasicHttpBinding GetWsdlBinding(model.IProxy proxy) {
            BasicHttpBinding binding = new BasicHttpBinding();

            if (proxy.ProxyType == model.Proxy.EProxyType.System) {
                binding.UseDefaultWebProxy = true;
            }
            else {
                WebProxy webProxy = ProxyWrapper.GetWebProxy(proxy);

                binding.UseDefaultWebProxy = false;
                if (proxy.ProxyType == model.Proxy.EProxyType.Enabled) {
                    binding.ProxyAddress = webProxy.Address;
                }
            }

            return binding;
        }

    }
}
