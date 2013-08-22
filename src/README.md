# WsdlUI 

WsdlUI is a program for quickly viewing and testing web services generated from a .wsdl file. 

The program is designed to be fast and responsive implementing a small number of features needed for testing web services. 

There are other .Net tools that have similar functionality including WebServiceStudio and Storm both hosted on Codeplex. These projects have both been inactive for a couple of years so I decided to code a new tool. 

The current release only runs on Windows however the next release will run on Linux with mono, hopefully this will be ready soon.

## Requirements

.NET v3.5

Windows XP SP2 (and above Windows 7, Windows 8)
 
## Installing

Either build the source or download the latest release from https://github.com/drexyia/WsdlUI/releases

The program does not currently include an installer for Windows.

Simply run WsdlUI.exe from the Release folder.

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
build.bat -c  
``` 
deletes output folders does not build solution

The solution file has been tested and builds with all versions of VS2012 including the express edition.

## Contributing

Use Unix (LF) line endings not windows (CR+LF), search and replace with regular expressions \r\n (CR+LF) windows \n   (LF) unix.

set git config --global core.autocrlf false to stop git auto fomatting line endings

Use spaces instead of tabs regular expression search \t

## Contributors

Here's a [list](https://github.com/drexyia/WsdlUI/contributors) of all the people who have contributed to the
development of WsdlUI.

## Bugs & Improvements

Bug reports and suggestions for improvements are always welcome.
