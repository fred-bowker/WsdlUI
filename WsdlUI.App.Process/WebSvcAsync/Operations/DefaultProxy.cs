/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Net;

namespace WsdlUI.App.Process.WebSvcAsync.Operations {
    internal sealed class DefaultProxy {

        internal IWebProxy Proxy {
            get;
            private set;
        }

        DefaultProxy() {
            //Bug fix: WebRequest.GetSystemWebProxy throws a null reference exception on Windows 7 x64.
            //WebRequest.DefaultWebProxy uses a proxy if set in the web.config otherwise uses the system wide proxy settings from IE
            Proxy = WebRequest.DefaultWebProxy;
        }

        internal static DefaultProxy Instance {
            get {
                return Nested.instance;
            }
        }

        class Nested {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested() {
            }

            internal static readonly DefaultProxy instance = new DefaultProxy();
        }
    }
}
