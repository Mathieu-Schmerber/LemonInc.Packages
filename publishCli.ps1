function Show-CLIWelcomeMessage {
    $asciiArt = @"
  _                                  _____              
 | |                                |_   _|             
 | |     ___ _ __ ___   ___  _ __     | |  _ __   ___   
 | |    / _ \ '_ ` _ \ / _ \| '_ \    | | | '_ \ / __|  
 | |___|  __/ | | | | | (_) | | | |  _| |_| | | | (__ _ 
 |______\___|_| |_| |_|\___/|_| |_| |_____|_| |_|\___(_)
                                                        
                                                        
"@

    $asciiArt = $asciiArt | Out-String
    Write-Host $asciiArt
    Write-Host "Welcome to Lemon Inc. Package publisher CLI!"
    Write-Host ""
    Write-Host "Available commands:"
    Write-Host "c: Create package"
    Write-Host "u: Update package"
    Write-Host "q: Exit the CLI"
}

function ExecuteGitCommands {
    param (
        [string]$path,
        [string]$action
    )

    # Check if there are changes to commit
    $changesExist = git diff

    if ($changesExist) {
        $commitMessage = Read-Host "Enter the commit message"

        Write-Host "Executing git command: git add $path"
        git add $path

        Write-Host "Executing git command: git commit -m '$commitMessage'"
        git commit -m "$commitMessage"

        Write-Host "Executing git command: git push origin master"
        git push origin master
    }

    if ($action -eq 'Create') {
        $branch = ("$scope.$feature").toLower()
        Write-Host "Executing git command: git subtree split --prefix=$path --branch $branch"
        git subtree split --prefix=$path --branch $branch
    }

    $remoteURL = "https://github.com/Mathieu-Schmerber/LemonInc.Packages"
    $branch = ("$scope.$feature").toLower()

    Write-Host "Executing git command: git subtree push --prefix=$path $remoteURL $branch"
    git subtree push --prefix=$path $remoteURL $branch
}

function Check-PackageValidity {
    param (
        [string]$path
    )
    
    # Define required files and folders
    $requiredItems = @(
        @{
            Path = Join-Path -Path $path -ChildPath "Documentation"
            Type = "Container"
            ErrorMessage = "The 'Documentation' folder is missing."
            NoFileErrorMessage = "The 'Documentation' folder does not contain any files."
        },
        @{
            Path = Join-Path -Path $path -ChildPath "package.json"
            Type = "Leaf"
            ErrorMessage = "The 'package.json' file is missing."
        },
        @{
            Path = Join-Path -Path $path -ChildPath "LemonInc.$scope.$feature.asmdef"
            Type = "Leaf"
            ErrorMessage = "The 'LemonInc.$scope.$feature.asmdef' file is missing."
        }
    )
    
    # Check required files and folders
    $isValidPackage = $true
    
    foreach ($item in $requiredItems) {
        $itemPath = $item.Path
        $itemType = $item.Type
        $errorMessage = $item.ErrorMessage
        $noFileErrorMessage = $item.NoFileErrorMessage
        
        if (-not (Test-Path -Path $itemPath -Type $itemType)) {
            $isValidPackage = $false
            Write-Host "Error: $errorMessage"
            
            if ($itemType -eq "Container" -and -not (Get-ChildItem -Path $itemPath -File)) {
                $isValidPackage = $false
                Write-Host "Error: $noFileErrorMessage"
            }
        }
    }
    
    # Check .meta files
    if ($isValidPackage) {
        foreach ($item in $requiredItems) {
            $itemPath = $item.Path
            $metaFile = "$itemPath.meta"
            
            if (-not (Test-Path -Path $metaFile -Type Leaf)) {
                $isValidPackage = $false
                Write-Host "Error: The '$metaFile' file is missing."
                return  # Stop execution without fully exiting the CLI
            }
        }
    }
    
    return $isValidPackage
}

function Process-CLICommand {
    param (
        [string]$command,
        [string]$action
    )
    
    $scope = Read-Host "Enter the scope name"
    $feature = Read-Host "Enter the feature name"
    $path = "Assets/LemonInc/$scope/$feature"
    
    if (Test-Path -Path $path) {
        $isValidPackage = Check-PackageValidity -path $path
        
        if ($isValidPackage) {
            ExecuteGitCommands -path $path -action $action
        }
    }
    else {
        Write-Host "Error: The path '$path' does not exist."
    }
}

# Main loop
while ($true) {
    Show-CLIWelcomeMessage

    $command = Read-Host "Enter a command"

    if ($command -eq "q") {
        break
    }
    else {
        Process-CLICommand -command $command
    }
}