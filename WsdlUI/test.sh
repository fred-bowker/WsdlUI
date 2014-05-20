#!/bin/bash

# test.sh                    inorder to run all of the tests the test web server should be running, use start-test-server.sh

mono nunit-console.exe Drexyia.WebSvc.Wsdl.Tests.dll WsdlUI.App.Model.Tests.dll Drexyia.WebSvc.Process.Tests.dll Drexyia.Utils.Tests.dll
