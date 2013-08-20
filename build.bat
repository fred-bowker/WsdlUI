:: build.bat                    deletes output folders and builds solution
:: build.bat -v                 deletes output folders and builds solution displaying compiler output
:: build.bat -c                 deletes output folders does not build solution

@echo off

echo.
echo DELETE output release folder
echo.

RMDIR Release /S /Q 2>NUL 

echo CLEAN solution deleting bin and obj files
echo.

RMDIR "WsdlUI.App.UI\bin\" /s /q 2>NUL
RMDIR "WsdlUI.App.Process\bin\" /s /q 2>NUL
RMDIR "WsdlUI.App.Model\bin\" /s /q 2>NUL
RMDIR "WsdlUI.App.UI\obj\" /s /q 2>NUL
RMDIR "WsdlUI.App.Process\obj\" /s /q 2>NUL
RMDIR "WsdlUI.App.Model\obj\" /s /q 2>NUL

IF "%1"=="-c" GOTO end

   echo BUILD solution file
   echo.

   IF "%1"=="-v" msbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild /p:DebugType=None
   IF NOT "%1"=="-v" msbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild /p:DebugType=None /verbosity:minimal
 
   echo.
   echo COPY to release folder
   echo.

   xcopy WsdlUI.App.UI\bin\Release Release /s /e /i /h 2>NUL >NUL

:end