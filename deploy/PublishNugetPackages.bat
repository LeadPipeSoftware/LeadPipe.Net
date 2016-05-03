@ECHO OFF

REM ** *************************************************************************
REM ** Run this batch file to publish (push) the NuGet packages
REM ** *************************************************************************

SET NUGET_SOURCE_FOLDER=..\release\
SET NUGET_PATH="NuGet.exe"

ECHO BuildNugetPackage START

ECHO [Variables]----------------------------------------------------------------

ECHO Using NUGET_SOURCE_FOLDER: %NUGET_SOURCE_FOLDER%
ECHO Using NUGET_PATH: %NUGET_PATH%

ECHO [Safety Check]-------------------------------------------------------------

set /p DUMMY=Did you remember to update the CommonAssemblyInfo file? Hit ENTER if you did...

ECHO [Environment Check]--------------------------------------------------------

IF NOT EXIST %NUGET_PATH% GOTO NugetNotFound
ECHO %NUGET_PATH% found!

ECHO All environment checks passed!

ECHO [Publish]------------------------------------------------------------------

%NUGET_PATH% push %NUGET_SOURCE_FOLDER%*.nupkg

GOTO Finish

:NugetNotFound
ECHO [ERROR]********************************************************************

ECHO %NUGET_PATH% could not be found! Are you sure NuGet and the NuGet Command Line are installed on this computer?
GOTO Finish

:Finish
ECHO [Finish]-------------------------------------------------------------------
