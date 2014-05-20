/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System.IO;
using System.Web.Services.Description;

namespace Drexyia.WebSvc.Wsdl {
    public class GenWsdlData {
        ServiceDescription _serviceDescription;

        public GenWsdlData(ServiceDescription serviceDescription) {
            _serviceDescription = serviceDescription;
        }

        public string Generate() {
            string wsdlContent;
            using (MemoryStream ms = new MemoryStream()) {
                _serviceDescription.Write(ms);

                ms.Seek(0L, SeekOrigin.Begin);
                wsdlContent = (new StreamReader(ms)).ReadToEnd();
            }

            return wsdlContent;
        }
    }
}
