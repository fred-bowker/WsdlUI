:: build.bat                    deletes output folders and builds solution
:: build.bat -v                 deletes output folders and builds solution, verbose
:: build.bat -l                 deletes output folders, builds solution builds installer
:: build.bat -l -v              deletes output folders, builds solution builds installer, verbose
:: build.bat -c                 deletes output folders does not build solution

:: msiexec /i WsdlUI.msi installer installer from the command line
:: msiexec /x Product.msi uninstall installer from the command line

@echo off

echo.
echo DELETE output release folder
echo.

RMDIR Release /S /Q 2>NUL 

echo DELETE wix installer output files
echo.

RM "WsdlUI.Installer\WsdlUI.msi" /s /q 2>NUL
RM "WsdlUI.Installer\WsdlUI.wixobj" /s /q 2>NUL
RM "WsdlUI.Installer\WsdlUI.wixpdb" /s /q 2>NUL

echo CLEAN solution deleting bin and obj files
echo.

RMDIR "WsdlUI.App.UI\bin\" /s /q 2>NUL
RMDIR "WsdlUI.App.Process\bin\" /s /q 2>NUL
RMDIR "WsdlUI.App.Model\bin\" /s /q 2>NUL
RMDIR "WsdlUI.App.UI\obj\" /s /q 2>NUL
RMDIR "WsdlUI.App.Process\obj\" /s /q 2>NUL
RMDIR "WsdlUI.App.Model\obj\" /s /q 2>NUL

IF NOT "%1"=="-c" (

   echo BUILD solution file
   echo.

   :: if any argument is -v
   IF "%1"=="-v" (
      msbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild /p:DebugType=None
   )
   :: ELSE
   IF NOT "%1"=="-v" (

      IF "%2"=="-v" (
          msbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild /p:DebugType=None
      )
      ::ELSE
      IF NOT "%2"=="-v" (
         msbuild WsdlUI.sln /p:Platform="Any CPU" /p:Configuration="Release" /t:Rebuild /p:DebugType=None /verbosity:minimal
      )
   )

   IF "%1"=="-l" (

		echo.
   	echo BUILD installer

      IF "%2"=="-v" (
         candle WsdlUI.Installer\WsdlUI.wxs -out "WsdlUI.Installer\WsdlUI.wixobj" -v -nologo 
         light WsdlUI.Installer\WsdlUI.wixobj -out "WsdlUI.Installer\WsdlUI.msi" -v -nologo -ext WixUIExtension 
      )
      :: ELSE
      IF NOT "%2"=="-v" (
         candle WsdlUI.Installer\WsdlUI.wxs -out "WsdlUI.Installer\WsdlUI.wixobj" -nologo 2>NUL >NUL
         light WsdlUI.Installer\WsdlUI.wixobj -out "WsdlUI.Installer\WsdlUI.msi" -nologo -ext WixUIExtension 2>NUL >NUL 
      )

   )

   echo.
   echo COPY to release folder
   echo.

   xcopy WsdlUI.App.UI\bin\Release Release\Binary /s /e /i /h 2>NUL >NUL
   IF "%1"=="-l" (
      xcopy WsdlUI.Installer\WsdlUI.msi Release /s /e /i /h 2>NUL >NUL
   )

)
