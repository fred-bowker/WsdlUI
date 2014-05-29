/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Threading;
using System.ServiceModel.Web;

namespace Drexyia.WebSvc.Process.Tests.Server {
    public class CallSyncOpService : ICallSyncOpService {

        public string HelloWorld() {
            return "Hello World";
        }

        public string HelloWorldStatus201()
        {
            WebOperationContext.Current.OutgoingResponse.StatusCode = System.Net.HttpStatusCode.Created;

            return "Hello World";
        }

        //pass in the number of seconds that the operation pauses, this can be used to simulate a timeout
        public string HelloWorldTimeout(int pausePeriod) {

            Thread.Sleep(pausePeriod * 1000);

            return "Hello World";
        }

        public CompositeType HelloWorldUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    }
}
