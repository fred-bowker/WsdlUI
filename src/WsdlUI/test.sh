#!/bin/bash

# test.sh                    inorder to run all of the tests the web services should be running on a windows machine and the app.config should be pointing
#                            to the correct uris

mono nunit-console.exe Drexyia.WebSvc.Wsdl.Tests.dll WsdlUI.App.Model.Tests.dll Drexyia.WebSvc.Process.Tests.dll Drexyia.Utils.Tests.dll WsdlUI.App.UI.Tests.dll
