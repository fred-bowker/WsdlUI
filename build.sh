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

rm -rf "WsdlUI.App.UI/bin/"
rm -rf "WsdlUI.App.Process/bin/" 
rm -rf "WsdlUI.App.Model/bin/" 
rm -rf "WsdlUI.App.UI/obj/"
rm -rf "WsdlUI.App.Process/obj/"
rm -rf "WsdlUI.App.Model/obj/"

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

	cp -r WsdlUI.App.UI/bin/Release Release

	# /p:DebugType=None argument can not be used with xbuild, this step deletes the mdb (pdb) files manually
	rm -f Release/*.mdb

fi

