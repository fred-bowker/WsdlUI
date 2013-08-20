/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Net;
using System.Net.Sockets;

namespace WsdlUI.App.Process.WebSvcAsync.EventParams {
    public class ExceptionAsyncArgs : AsyncArgs {

        public Exception Ex {
            get;
            private set;
        }

        public string Message {
            get {

                Exception innerEx = Ex.InnerException as SocketException;
                if (innerEx == null) {
                    innerEx = Ex.InnerException as WebException;
                }
                if (innerEx != null) {
                    return Ex.Message.ToString() + " - " + innerEx.Message.ToString();
                }

                return Ex.Message.ToString();

            }

        }

        public ExceptionAsyncArgs(string name, Exception ex)
            : base(name) {
            Ex = ex;
        }
    }
}
