@ECHO OFF

REM ** *************************************************************************
REM ** Run this batch file to build the NuGet packages
REM ** *************************************************************************

REM ** BuildNugetPackage.bat /LeadPipe.Net/src/LeadPipe.Net/ /LeadPipe.Net/src/LeadPipe.Net/bin/ LeadPipe.Net /LeadPipe.Net/release

SET PROJECT_DIR=%1
SET TARGET_DIR=%2
SET TARGET_NAME=%3
SET NUGET_PACKAGES_FOLDER=%4
SET NUGET_LOG_FILE=%TARGET_DIR%%TARGET_NAME%.BuildNugetPackage.log
SET NUGET_PATH="C:\Tools\NuGet.exe"

ECHO BuildNugetPackage START
ECHO BuildNugetPackage START > %NUGET_LOG_FILE%

REM ** <Exec Command="$(SolutionDir)deploy\BuildNugetPackage.bat $(ProjectDir) $(TargetDir) $(TargetName) $(SolutionDir)bin" />

ECHO. >> %NUGET_LOG_FILE%
ECHO [Variables]---------------------------------------------------------------- >> %NUGET_LOG_FILE%

ECHO Using PROJECT_DIR: %PROJECT_DIR%
ECHO Using PROJECT_DIR: %PROJECT_DIR% >> %NUGET_LOG_FILE%

ECHO Using TARGET_DIR: %TARGET_DIR%
ECHO Using TARGET_DIR: %TARGET_DIR% >> %NUGET_LOG_FILE%

ECHO Using NUGET_PACKAGES_FOLDER: %NUGET_PACKAGES_FOLDER%
ECHO Using NUGET_PACKAGES_FOLDER: %NUGET_PACKAGES_FOLDER% >> %NUGET_LOG_FILE%

ECHO. >> %NUGET_LOG_FILE%
ECHO [Environment Check]-------------------------------------------------------- >> %NUGET_LOG_FILE%

IF NOT EXIST %NUGET_PATH% GOTO NugetNotFound
ECHO %NUGET_PATH% found!

IF NOT EXIST %PROJECT_DIR%%TARGET_NAME%.csproj GOTO ProjectNotFound
ECHO %PROJECT_DIR%%TARGET_NAME%.csproj found!

IF NOT EXIST %NUGET_PACKAGES_FOLDER% MKDIR %NUGET_PACKAGES_FOLDER%

ECHO All environment checks passed! >> %NUGET_LOG_FILE%

ECHO. >> %NUGET_LOG_FILE%
ECHO [Remove Old Packages]------------------------------------------------------ >> %NUGET_LOG_FILE%

ECHO Removing old NuGet packages...
ECHO Removing old NuGet packages... >> %NUGET_LOG_FILE%

ECHO Attempting to delete these files:
DIR /B %NUGET_PACKAGES_FOLDER%\%TARGET_NAME%.?.*.nupkg >> %NUGET_LOG_FILE%

DEL %NUGET_PACKAGES_FOLDER%\%TARGET_NAME%.?.*.nupkg >> %NUGET_LOG_FILE%
DIR /B %TARGET_DIR%*.nupkg >> %NUGET_LOG_FILE%
DEL %TARGET_DIR%*.nupkg >> %NUGET_LOG_FILE%

ECHO. >> %NUGET_LOG_FILE%
ECHO [Package]------------------------------------------------------------------ >> %NUGET_LOG_FILE%

REM --- Copy the files from the TARGET_DIR to bin of the project dir
IF EXIST %PROJECT_DIR%\bin\%TARGET_NAME%.dll GOTO :CreateNugetPackage
XCOPY %TARGET_DIR%%TARGET_NAME%.* %PROJECT_DIR%\bin

:CreateNugetPackage
ECHO Creating NuGet Package...
ECHO Creating NuGet Package... >> %NUGET_LOG_FILE%
%NUGET_PATH% pack %PROJECT_DIR%%TARGET_NAME%.csproj -Verbose -Exclude **\CustomDictionary.xml;**\*.CodeAnalysisLog.xml -BasePath %TARGET_DIR% -OutputDirectory %TARGET_DIR% >> %NUGET_LOG_FILE%

ECHO. >> %NUGET_LOG_FILE%
ECHO [Copy To NuGet Packages Folder]-------------------------------------------- >> %NUGET_LOG_FILE%

ECHO Copying NuGet package to %NUGET_PACKAGES_FOLDER%...
ECHO Copying NuGet package to %NUGET_PACKAGES_FOLDER%... >> %NUGET_LOG_FILE%
XCOPY /Y %TARGET_DIR%*.nupkg %NUGET_PACKAGES_FOLDER% >> %NUGET_LOG_FILE%

GOTO Finish

:NugetNotFound
ECHO. >> %NUGET_LOG_FILE%
ECHO [ERROR]******************************************************************** >> %NUGET_LOG_FILE%

ECHO %NUGET_PATH% could not be found! Are you sure NuGet and the NuGet Command Line are installed on this computer? >> %NUGET_LOG_FILE%
GOTO Finish

:ProjectNotFound
ECHO. >> %NUGET_LOG_FILE%
ECHO [ERROR]******************************************************************** >> %NUGET_LOG_FILE%

ECHO %PROJECT_DIR%%TARGET_NAME%.csproj could not be found! >> %NUGET_LOG_FILE%
GOTO Finish

:Finish
ECHO. >> %NUGET_LOG_FILE%
ECHO [Finish]------------------------------------------------------------------- >> %NUGET_LOG_FILE%

ECHO BuildNugetPackage FINISH
ECHO BuildNugetPackage FINISH >> %NUGET_LOG_FILE%
