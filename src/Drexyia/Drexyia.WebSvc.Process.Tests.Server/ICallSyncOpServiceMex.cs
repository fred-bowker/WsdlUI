/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

//The test host server should be run on a windows platform running on the clr not Mono
#if !__MonoCS__

using System.Runtime.Serialization;
using System.ServiceModel;

namespace Drexyia.WebSvc.Process.Tests.Server {
    [ServiceContract]
    public interface ICallSyncOpServiceMex {
        [OperationContract]
        string HelloWorld();

        [OperationContract]
        CompositeType HelloWorldUsingDataContract(CompositeType composite);
    }

    [DataContract]
    public class CompositeType {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue {
            get {
                return boolValue;
            }
            set {
                boolValue = value;
            }
        }

        [DataMember]
        public string StringValue {
            get {
                return stringValue;
            }
            set {
                stringValue = value;
            }
        }
    }
}

#endif
