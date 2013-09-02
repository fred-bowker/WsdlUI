/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.Web.Services.Description;

namespace WsdlUI.App.Process.WebSvcGenerate {
    public class GenMetaData {
        ServiceDescription _description;
        
        public string Name {
            get;
            private set;
        }

        public string ServiceURI {
            get;
            private set;
        }

        
        public GenMetaData(ServiceDescription description) {
            _description = description;
        }

        //HACK: FB instead of correctly showing the list of bindings we are simply picking the first this is incorrect howerver will do for the moment
        //I think we should be matching it to the binding
        public void Parse() {
            Name = _description.Name;

            foreach (Service service in _description.Services) {
                foreach (Port port in service.Ports) {
                    foreach (var extension in port.Extensions) {
                        SoapAddressBinding soapBinding = extension as SoapAddressBinding;
                        if (soapBinding != null) {
                            ServiceURI = soapBinding.Location;
                            goto finished;
                        }
                    }
                }

            finished:
                break;
            }
        }

    }
}
