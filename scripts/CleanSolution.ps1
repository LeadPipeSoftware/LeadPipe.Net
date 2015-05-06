# This script will fix messed up hint paths in solution and project files.

[string] $scriptDirectory = Split-Path $MyInvocation.MyCommand.Path

Push-Location

Set-Location $scriptDirectory\..

Get-ChildItem src\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }

Pop-Location