// 
// SampleGenerator.cs
//
// Author:
//   Lluis Sanchez Gual (lluis@ximian.com)
//
// Copyright (C) 2004 Novel Inc.
//

using System;
using System.Web.Services.Description;
using System.Xml.Serialization;

namespace WsdlUI.App.Process.WebSvcGenerate.Sample {
    public class SampleGeneratorWebSvc : SampleGenerator {
        public SampleGeneratorWebSvc(ServiceDescriptionCollection services, XmlSchemas schemas)
            : base(services, schemas) {
        }

        public void GenerateMessages(string operation, string bindingName, string protocol, out string req) {
            Port port = FindPort(bindingName, protocol);
            Binding binding = descriptions.GetBinding(port.Binding);
            if (binding == null) throw new InvalidOperationException("Binding " + bindingName + " not found");

            PortType portType = descriptions.GetPortType(binding.Type);
            Operation oper = FindOperation(portType, operation);
            if (oper == null) throw new InvalidOperationException("Operation " + operation + " not found");
            OperationBinding obin = FindOperation(binding, operation);

            req = GenerateMessage(port, obin, oper, protocol, true);
        }

        Port FindPort(string portName, string protocol) {
            Service service = descriptions[0].Services[0];
            foreach (Port port in service.Ports) {
                if (portName == null) {
                    Binding binding = descriptions.GetBinding(port.Binding);
                    if (GetProtocol(binding) == protocol) return port;
                }
                else if (port.Name == portName)
                    return port;
            }
            return null;
        }

        string GetProtocol(Binding binding) {
            if (binding.Extensions.Find(typeof(SoapBinding)) != null) return "Soap";
            HttpBinding hb = (HttpBinding)binding.Extensions.Find(typeof(HttpBinding));
            if (hb == null) return "";
            if (hb.Verb == "POST") return "HttpPost";
            if (hb.Verb == "GET") return "HttpGet";
            return "";
        }

        Operation FindOperation(PortType portType, string name) {
            foreach (Operation oper in portType.Operations) {
                if (oper.Messages.Input.Name != null) {
                    if (oper.Messages.Input.Name == name) return oper;
                }
                else
                    if (oper.Name == name) return oper;
            }

            return null;
        }

        OperationBinding FindOperation(Binding binding, string name) {
            foreach (OperationBinding oper in binding.Operations) {
                if (oper.Input.Name != null) {
                    if (oper.Input.Name == name) return oper;
                }
                else
                    if (oper.Name == name) return oper;
            }

            return null;
        }
    }


}

