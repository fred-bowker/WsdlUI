#!/bin/bash

# test.sh                    inorder to run all of the tests the test web server should be running, use start-test-server.sh

mono nunit-console.exe WsdlUI.App.Model.Tests.dll Drexyia.Utils.Tests.dll WsdlUI.App.UI.Tests.dll
