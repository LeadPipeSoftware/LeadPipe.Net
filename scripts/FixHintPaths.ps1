# This script will fix messed up hint paths in solution and project files.

[string] $scriptDirectory = Split-Path $MyInvocation.MyCommand.Path

Push-Location

Set-Location $scriptDirectory\..

$hintPathPattern = @"
<HintPath>(\d|\w|\s|\.|\\)*packages
"@

write-host Looking for $hintPathPattern

ls -Recurse -include *.csproj, *.sln, *.fsproj, *.vbproj |
  foreach {

    $content = cat $_.FullName | Out-String

    $originalContent = $content

    $content = $content -replace $hintPathPattern, "<HintPath>`$(SolutionDir)packages"

    if ($originalContent -ne $content)
    {
        $content | out-file -encoding "UTF8" $_.FullName

        write-host Fixed hint paths in $_.Name
    }
}

Pop-Location
