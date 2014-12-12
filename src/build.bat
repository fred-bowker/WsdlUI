:: build.bat                    deletes output folders and builds solution
:: build.bat -v                 deletes output folders and builds solution, verbose
:: build.bat -l                 deletes output folders, builds solution builds installer
:: build.bat -l -v              deletes output folders, builds solution builds installer, verbose
:: build.bat -c                 deletes output folders does not build solution

:: msiexec /i WsdlUI.msi installer installer from the command line
:: msiexec /x WsdlUI.msi uninstall installer from the command line

@echo off

echo.
echo DELETE output release folder
echo.

RMDIR Release /S /Q 2>NUL 

echo DELETE wix installer output files
echo.

RM "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.msi" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wixobj" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wixpdb" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\Microsoft.Deployment.WindowsInstaller.dll" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\WixCustomActions.CA.dll" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\WixCustomActions.dll" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\WixCustomActions.pdb" /s /q 2>NUL
RM "WsdlUI\WsdlUI.Windows.Installer\Microsoft.Deployment.WindowsInstaller.xml" /s /q 2>NUL

echo CLEAN solution deleting bin and obj files
echo.

RMDIR "Drexyia\Drexyia.Utils\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.Utils.Tests\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Model\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process.Tests\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process.Tests.Server\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process.Tests.Server.Host\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Wsdl\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Wsdl.Tests\bin\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.Utils\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.Utils.Tests\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Model\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process.Tests\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process.Tests.Server\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Process.Tests.Server.Host\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Wsdl\obj\" /s /q 2>NUL
RMDIR "Drexyia\Drexyia.WebSvc.Wsdl.Tests\obj\" /s /q 2>NUL

RMDIR "WsdlUI\WsdlUI.App.UI\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.Process\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.Model\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.Model.Tests\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI.Tests\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI.Console\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI.Windows\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.TextEditor\bin\" /s /q 2>NUL
RMDIR "WsdlUI\ICSharpCode.TextEditor\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.Windows.Installer\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.Windows.Installer\CustomActions\bin\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.Process\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.Model\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.Model.Tests\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI.Tests\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI.Console\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.App.UI.Windows\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.TextEditor\obj\" /s /q 2>NUL
RMDIR "WsdlUI\ICSharpCode.TextEditor\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.Windows.Installer\obj\" /s /q 2>NUL
RMDIR "WsdlUI\WsdlUI.Windows.Installer\CustomActions\obj\" /s /q 2>NUL

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

      IF "%2"=="-v" (

		echo.
   		echo BUILD installer cutom actions

		msbuild WsdlUI.Windows.Installer.sln /p:Platform="x86" /p:Configuration="Release" /t:Rebuild /p:DebugType=None

		echo.
   		echo BUILD installer wix

        candle WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wxs -out "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wixobj" -v -nologo 
        light WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wixobj -out "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.msi" -v -nologo -ext WixUIExtension 
      )
      :: ELSE
      IF NOT "%2"=="-v" (

		echo.
   		echo BUILD installer cutom actions

		msbuild WsdlUI.Windows.Installer.sln /p:Platform="x86" /p:Configuration="Release" /t:Rebuild /p:DebugType=None /verbosity:minimal

		echo.
   		echo BUILD installer wix

        candle WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wxs -out "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wixobj" -nologo 2>NUL >NUL
        light WsdlUI\WsdlUI.Windows.Installer\WsdlUI.wixobj -out "WsdlUI\WsdlUI.Windows.Installer\WsdlUI.msi" -nologo -ext WixUIExtension 2>NUL >NUL 
      )

   )

   echo.
   echo COPY to release folder
   echo.

   xcopy WsdlUI\WsdlUI.App.UI.Windows\bin\Release Release\Binary /s /e /i /h 2>NUL >NUL
   xcopy WsdlUI\WsdlUI.App.UI.Console\bin\Release\CommandLine.dll Release\Binary 2>NUL >NUL
   xcopy WsdlUI\WsdlUI.App.UI.Console\bin\Release\WsdlUI-Console.exe Release\Binary 2>NUL >NUL
   xcopy WsdlUI\WsdlUI.App.UI.Console\bin\Release\WsdlUI-Console.exe.config Release\Binary 2>NUL >NUL
 
   IF "%1"=="-l" (
      xcopy WsdlUI\WsdlUI.Windows.Installer\WsdlUI.msi Release 2>NUL >NUL
   )

   :: Copy accross the test data
   xcopy Drexyia\Drexyia.WebSvc.Process.Tests\bin\Release\TestData Release\Binary\TestData /s /e /i /h 2>NUL >NUL
   xcopy Drexyia\Drexyia.WebSvc.Wsdl.Tests\bin\Release\TestData Release\Binary\TestData /s /e /i /h 2>NUL >NUL
   xcopy WsdlUI\WsdlUI.App.Model.Tests\TestData Release\Binary\TestData /s /e /i /h 2>NUL >NUL

   :: Copy accross the test assemblies
   xcopy Drexyia\Drexyia.Utils.Tests\bin\Release\Drexyia.Utils.Tests.dll Release\Binary 2>NUL >NUL
   xcopy Drexyia\Drexyia.WebSvc.Process.Tests\bin\Release\Drexyia.WebSvc.Process.Tests.dll Release\Binary 2>NUL >NUL
   xcopy Drexyia\Drexyia.WebSvc.Process.Tests\bin\Release\Drexyia.WebSvc.Process.Tests.dll.config Release\Binary 2>NUL >NUL
   xcopy Drexyia\Drexyia.WebSvc.Wsdl.Tests\bin\Release\Drexyia.WebSvc.Wsdl.Tests.dll Release\Binary 2>NUL >NUL
   xcopy WsdlUI\WsdlUI.App.Model.Tests\bin\Release\WsdlUI.App.Model.Tests.dll Release\Binary 2>NUL >NUL
   xcopy WsdlUI\WsdlUI.App.UI.Tests\bin\Release\WsdlUI.App.UI.Tests.dll Release\Binary 2>NUL >NUL

   :: Copy accross the test web services and host
   xcopy Drexyia\Drexyia.WebSvc.Process.Tests.Server.Host\bin\Release\Drexyia.WebSvc.Process.Tests.Server.Host.exe Release\Binary 2>NUL >NUL
   xcopy Drexyia\Drexyia.WebSvc.Process.Tests.Server.Host\bin\Release\Drexyia.WebSvc.Process.Tests.Server.Host.exe.config Release\Binary 2>NUL >NUL
   xcopy Drexyia\Drexyia.WebSvc.Process.Tests.Server.Host\bin\Release\Drexyia.WebSvc.Process.Tests.Server.dll Release\Binary 2>NUL >NUL

   :: Copy accross nunit console needed for running tests
   xcopy External\nunit\nunit-console.exe Release\Binary 2>NUL >NUL
   xcopy External\nunit\nunit-console-runner.dll Release\Binary 2>NUL >NUL
   xcopy External\nunit\nunit.core.dll Release\Binary 2>NUL >NUL
   xcopy External\nunit\nunit.util.dll Release\Binary 2>NUL >NUL
   xcopy External\nunit\nunit.core.interfaces.dll Release\Binary 2>NUL >NUL
   xcopy External\nunit\nunit.framework.dll Release\Binary 2>NUL >NUL

   xcopy WsdlUI\test.bat Release\Binary 2>NUL >NUL
   xcopy WsdlUI\start-test-server.bat Release\Binary 2>NUL >NUL

)
