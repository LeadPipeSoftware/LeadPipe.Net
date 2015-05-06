# This script will migrate to the new style NuGet package restore.

[string] $scriptDirectory = Split-Path $MyInvocation.MyCommand.Path

Push-Location

Set-Location $scriptDirectory\..

# Set up the regex patterns for Really Bad Things!
$listOfBadStuff = @(
    #sln regex
    "\s*(\.nuget\\NuGet\.(exe|targets)) = \1",
    #*proj regexes
    "\s*<Import Project=""\$\(SolutionDir\)\\\.nuget\\NuGet\.targets"".*?/>",
    "\s*<Target Name=""EnsureNuGetPackageBuildImports"" BeforeTargets=""PrepareForBuild"">(.|\n)*?</Target>"
)

# Delete all of the NuGet.targets and NuGet.exe files
#ls -Recurse -include 'NuGet.exe','NuGet.targets' |
ls -Recurse -include 'NuGet.targets' |
    foreach {

        remove-item $_ -recurse -force

        write-host Deleted $_
    }

# Fix project and solution files to reverse damage done by "Enable NuGet Package Restore"
ls -Recurse -include *.csproj, *.sln, *.fsproj, *.vbproj |
    foreach {

        $content = cat $_.FullName | Out-String

        $origContent = $content

        foreach($badStuff in $listOfBadStuff){

            $content = $content -replace $badStuff, ""
        }

        if ($origContent -ne $content)
        {
            $content | out-file -encoding "UTF8" $_.FullName

            write-host Fixed problems in $_.Name
        }
    }

Pop-Location
