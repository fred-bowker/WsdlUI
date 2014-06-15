#!/bin/bash

# ./build.sh                    deletes output folders and builds solution
# ./build.sh -v                 deletes output folders and builds solution displaying compiler output
# ./build.sh -c                 deletes output folders does not build solution

echo
echo DELETE output release folder
echo

rm -rf Release

echo CLEAN solution deleting bin and obj files
echo

rm -rf "Drexyia/Drexyia.Utils/bin/"
rm -rf "Drexyia/Drexyia.Utils.Tests/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Model/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Process/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Process.Tests/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Process.Tests.Server/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Process.Tests.Server.Host/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Wsdl/bin/"
rm -rf "Drexyia/Drexyia.WebSvc.Wsdl.Tests/bin/"
rm -rf "Drexyia/Drexyia.Utils/obj/"
rm -rf "Drexyia/Drexyia.Utils.Tests/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Model/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Process/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Process.Tests/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Process.Tests.Server/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Process.Tests.Server.Host/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Wsdl/obj/"
rm -rf "Drexyia/Drexyia.WebSvc.Wsdl.Tests/obj/"
rm -rf "WsdlUI/WsdlUI.App.UI/bin/"
rm -rf "WsdlUI/WsdlUI.App.Process/bin/"
rm -rf "WsdlUI/WsdlUI.App.Model/bin/"
rm -rf "WsdlUI/WsdlUI.App.Model.Tests/bin/"
rm -rf "WsdlUI/WsdlUI.App.UI/bin/"
rm -rf "WsdlUI/WsdlUI.App.UI.Console/bin/"
rm -rf "WsdlUI/WsdlUI.App.UI.Windows/bin/"
rm -rf "WsdlUI/WsdlUI.TextEditor/bin/"
rm -rf "WsdlUI/ICSharpCode.TextEditor/bin/"
rm -rf "WsdlUI/WsdlUI.Windows.Installer/CustomActions/bin/"
rm -rf "WsdlUI/WsdlUI.App.UI/obj/"
rm -rf "WsdlUI/WsdlUI.App.Process/obj/"
rm -rf "WsdlUI/WsdlUI.App.Model/obj/"
rm -rf "WsdlUI/WsdlUI.App.Model.Tests/obj/"
rm -rf "WsdlUI/WsdlUI.App.UI/obj/"
rm -rf "WsdlUI/WsdlUI.App.UI.Console/obj/"
rm -rf "WsdlUI/WsdlUI.App.UI.Windows/obj/"
rm -rf "WsdlUI/WsdlUI.TextEditor/obj/"
rm -rf "WsdlUI/ICSharpCode.TextEditor/obj/"
rm -rf "WsdlUI/WsdlUI.Windows.Installer/CustomActions/obj/"

if [ "$1" != "-c" ]; then
	
	echo BUILD solution file
	echo

	if [ "$1" != "-v" ]; then
	    xbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild /verbosity:minimal
	else
		xbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild
	fi

	echo
	echo COPY to release folder
	echo

	mkdir -p Release/Binary
	mkdir -p Release/Binary/TestData

	cp -r WsdlUI/WsdlUI.App.UI.Windows/bin/Release/* Release/Binary
	cp -r WsdlUI/WsdlUI.App.UI.Console/bin/Release/CommandLine.dll Release/Binary
	cp -r WsdlUI/WsdlUI.App.UI.Console/bin/Release/WsdlUI-Console.exe Release/Binary
	cp -r WsdlUI/WsdlUI.App.UI.Console/bin/Release/WsdlUI-Console.exe.config Release/Binary

	# Copy accross the test data
	cp -r Drexyia/Drexyia.WebSvc.Process.Tests/bin/Release/TestData/* Release/Binary/TestData
	cp -r Drexyia/Drexyia.WebSvc.Wsdl.Tests/bin/Release/TestData/* Release/Binary/TestData
	cp -r WsdlUI/WsdlUI.App.Model.Tests/TestData/* Release/Binary/TestData

	# Copy accross the test assemblies
	cp Drexyia/Drexyia.Utils.Tests/bin/Release/Drexyia.Utils.Tests.dll Release/Binary
	cp Drexyia/Drexyia.WebSvc.Process.Tests/bin/Release/Drexyia.WebSvc.Process.Tests.dll Release/Binary
	cp Drexyia/Drexyia.WebSvc.Process.Tests/bin/Release/Drexyia.WebSvc.Process.Tests.dll.config Release/Binary
	cp Drexyia/Drexyia.WebSvc.Wsdl.Tests/bin/Release/Drexyia.WebSvc.Wsdl.Tests.dll Release/Binary
	cp WsdlUI/WsdlUI.App.Model.Tests/bin/Release/WsdlUI.App.Model.Tests.dll Release/Binary

	# Copy accross nunit console needed for running tests
	cp External/nunit/nunit-console.exe Release/Binary
	cp External/nunit/nunit-console-runner.dll Release/Binary
	cp External/nunit/nunit.core.dll Release/Binary
	cp External/nunit/nunit.util.dll Release/Binary
	cp External/nunit/nunit.core.interfaces.dll Release/Binary
	cp External/nunit/nunit.framework.dll Release/Binary

	cp WsdlUI/test.sh Release/Binary

	# /p:DebugType=None argument can not be used with xbuild, this step deletes the mdb (pdb) files manually
	rm -f Release/*.mdb

fi

