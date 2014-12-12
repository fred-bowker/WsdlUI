# WsdlUI

WsdlUI is a program for quickly viewing and testing web services generated from a .wsdl file.

The program is designed to be fast and responsive implementing a small number of features needed for testing web services.

There are other .Net tools that have similar functionality including WebServiceStudio and Storm both hosted on Codeplex. These projects have both been inactive for a couple of years so I decided to code a new tool.

The project is written in .Net and uses WinForms, it runs on Windows and Linux using the Mono runtime.

## Requirements

### Windows

.NET v3.5

Windows XP SP2 (and above Windows 7, Windows 8)

Uses the Microsoft Consolas font if installed otherwise the program defaults to Courier New.

### Linux

Mono 2.10.X or higher, Mono WinForms library.

```
sudo apt-get install libmono-winforms2.0-cil
```
Install mono on Debian based systems (Ubuntu, Mint)

```
sudo yum install mono-winforms.x86_64
```
Install mono on RedHat based systems (Fedora)

Uses the open source Inconsolata font if installed otherwise the program defaults to Courier New.


## Installing

### Windows

Either build the source or download the latest release from https://github.com/drexyia/WsdlUI/releases

Install using the Windows installer WsdlUI.msi

#### Visual Studio

WsdlUI can be used as a replacement for WcfTestClient when running WCF Service Library projects from within Visual Studio. From within a WCF Service Library Project make the following changes

1. Go to project properies -> Debug page
2. Change Command Line Arguments

     From: /client:"WcfTestClient.exe"

     To: /client:"[PATH]WsdlUI.exe"

### Linux

Download the latest linux relase from https://github.com/drexyia/WsdlUI/releases

Extract the tar file, change to the release folder

```
mono WsdlUI.exe
```

## Building

Running the build scripts will clean solution folders by deleting previous bin/obj folders then copy the executables to a new folder Release.

### Windows

#### Microsoft MSBuild

```
build.bat
```
deletes output folders and builds solution

```
build.bat -v
```
deletes output folders and builds solution displaying compiler output

```
build.bat -l
```
deletes output folders and builds solution, creates the windows installer

```
build.bat -l -v
```
deletes output folders and builds solution, creates the windows installer displaying compiler output

```
build.bat -c
```
deletes output folders does not build solution

### Linux

#### Mono XBuild

```
./build.sh
```
deletes output folders and builds solution


The solution file has been tested and builds with all versions of VS2012 including the express edition.
The solution file can also be used with MonoDevelop on Linux.

## Debugging

The application writes trace information to any log4net appenders that are configured. Modify WsdlUI.exe.config to configure log4net.

### Console

The application can be run from the cmd prompt, this will output all tracing information to the command prompt.

```
WsdlUI-Console.exe --help               Displays help info
WsdlUI-Console.exe --debug              Start with debug info written to the console
WsdlUI-Console.exe --request-uri="uri"  Start in single request mode
```

## Contributing

Use Unix (LF) line endings not windows (CR+LF), search and replace with regular expressions \r\n (CR+LF) windows \n   (LF) unix.

set git config --global core.autocrlf false to stop git auto fomatting line endings

Use spaces instead of tabs regular expression search \t

## Contributors

Here's a [list](https://github.com/drexyia/WsdlUI/contributors) of all the people who have contributed to the
development of WsdlUI.

## Bugs & Improvements

Bug reports and suggestions for improvements are always welcome.
