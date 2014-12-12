/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.ServiceModel;

namespace Drexyia.WebSvc.Process.Tests.Server.Host
{
    class Program
    {
        static void Main(string[] args)
        {
//The test host server should be run on a windows platform running on the clr not Mono
//The reason for this is that if we are testing the responses from the server we want the server to return the same result whether testing on linux or windows.
//To run the tests on linux run the test server on a seperate or virtual windows machine, then call test.bat
#if !__MonoCS__

            ServiceHost mexHost = null;
            ServiceHost wsdlHost = null;

            try {

                wsdlHost = new ServiceHost(typeof(CallSyncOpService), new Uri[] { });
                mexHost = new ServiceHost(typeof(CallSyncOpServiceMex), new Uri[] { });

                mexHost.Open();
                wsdlHost.Open();

                Console.WriteLine("The wsdl service is ready at {0}", wsdlHost.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine("The mex service is ready at {0}", mexHost.BaseAddresses[0].AbsoluteUri);

                Console.WriteLine("Press <Enter> to stop the service.");
                Console.ReadLine();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            finally {
                if (mexHost != null) {
                    mexHost.Close();
                }
                if (wsdlHost != null) {
                    wsdlHost.Close();
                }
            }
#endif
        }
    }
}



