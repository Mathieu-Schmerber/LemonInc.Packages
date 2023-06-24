<#
Show-CLIWelcomeMessage: Displays a welcome message and the list of available commands in the CLI.
#>
function Show-CLIWelcomeMessage {
    $asciiArt = @"
  _                                  _____              
 | |                                |_   _|             
 | |     ___ _ __ ___   ___  _ __     | |  _ __   ___   
 | |    / _ \ '_ ` _ \ / _ \| '_ \    | | | '_ \ / __|  
 | |___|  __/ | | | | | (_) | | | |  _| |_| | | | (__ _ 
 |______\___|_| |_| |_|\___/|_| |_| |_____|_| |_|\___(_)
                                                        
                                                        
"@

    Write-Host $asciiArt
    Write-Host "Welcome to Lemon Inc. Package publisher CLI!"
    Write-Host ""
    Write-Host "Available commands:"
    Write-Host "c: Create package"
    Write-Host "u: Update package"
    Write-Host "s: Sync repository"
    Write-Host "q: Exit the CLI"
}

<#
Get-ValidPackagePath: Validates and retrieves the package path based on the provided scope and feature.

Parameters:
  - scope: The scope name.
  - feature: The feature name.

Returns:
  - The valid package path if it exists, otherwise $null.
#>
function Get-ValidPackagePath {
    param (
        [string]$scope,
        [string]$feature
    )

    $scope = $scope.ToLower()
    $feature = $feature.ToLower()

    $path = "Assets/LemonInc/$scope/$feature"

    if (Test-Path -Path $path) {
        return $path
    } else {
        return $null
    }
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
            Path = Join-Path -Path $path -ChildPath "Scripts"
            Type = "Container"
            ErrorMessage = "The 'Scripts' folder is missing."
            NoFileErrorMessage = "The 'Scripts' folder does not contain any files."
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

<#
Process-CLICommand: Processes the user input command.

Parameters:
  - command: The command entered by the user.
  - action: The action to perform ('Create' or 'Update').
#>
function Process-CLICommand {
    param (
        [string]$command,
        [string]$action
    )
    
    $scope = Read-Host "Enter the scope name"
    $feature = Read-Host "Enter the feature name"
    $path = "Assets/LemonInc/$scope/$feature"

    $path = Get-ValidPackagePath $scope $feature

    if ($path) {

        $validPackage = Check-PackageValidity -path $path 
        if (!$validPackage) {
            return
        }

        # Check if there are changes to commit
        $changesExist = git diff
        if ($changesExist) {
            $commitMessage = Read-Host "Enter the commit message"

            Write-Host "Executing git command: git add $path"
            #git add $path

            Write-Host "Executing git command: git commit -m '$commitMessage'"
            #git commit -m "$commitMessage"

            Write-Host "Executing git command: git push origin master"
            #git push origin master
        }

        if ($action -eq 'Create') {
            # Logic for creating the package

            # Check if the subtree branch exists
            $subtreeBranch = "$scope.$feature"
            $subtreeBranchExists = git ls-remote --heads origin $subtreeBranch

            if (-not $subtreeBranchExists) {
                $createPackage = Read-Host "The package '$scope.$feature' does not exist. Do you want to create it? (y/n)"
                if ($createPackage -eq 'y') {
                    Write-Host "Creating package '$scope.$feature'..."

                    # Execute git subtree split command
                    Write-Host "Executing git command: git subtree split --prefix=$path --branch $subtreeBranch"
                    #git subtree split --prefix=$path --branch $subtreeBranch
                }
                else {
                    Write-Host "Package creation aborted."
                    return
                }
            }
            else {
                Write-Host "Error: The package '$scope.$feature' already exists."
                return
            }
        }

        if ($action -eq 'Update') {
            # Logic for updating the package

            # Check if the subtree branch exists
            $subtreeBranch = "$scope.$feature"
            $subtreeBranchExists = git ls-remote --heads origin $subtreeBranch

            if ($subtreeBranchExists) {
                Write-Host "Updating package '$scope.$feature'..."

                # Execute git subtree push command
                $remoteURL = "https://github.com/Mathieu-Schmerber/LemonInc.Packages"
                Write-Host "Executing git command: git subtree push --prefix=$path $remoteURL $subtreeBranch"
                #git subtree push --prefix=$path $remoteURL $subtreeBranch
            }
            else {
                Write-Host "Error: The package '$scope.$feature' does not exist."
            }
        }
    }
}

<#
Sync-Repository: Syncs the entire repository by iterating over each valid package and checking for changes.
#>
function Sync-Repository {
    Write-Host "Syncing the entire repository..."

    $packagesPath = "Assets/LemonInc"
    $packages = Get-ChildItem -Path $packagesPath -Directory -Recurse

    foreach ($package in $packages) {
        $scope = $package.Name

        $features = Get-ChildItem -Path $package.FullName -Directory
        foreach ($feature in $features) {
            $feature = $feature.Name
            $path = Get-ValidPackagePath $scope $feature

            if ($path) {
                Write-Host "Checking changes for package '$scope.$feature'..."

                # Check if there are changes to commit
                $changesExist = git diff

                if ($changesExist) {
                    $updatePackage = Read-Host "Changes detected in package '$scope.$feature'. Do you want to sync it? (y/n)"
                    if ($updatePackage -eq 'y') {

                        $validPackage = Check-PackageValidity -path $path 
                        if (!$validPackage) {
                            return
                        }

                        $commitMessage = Read-Host "Enter the commit message"
                        Write-Host "Executing git command: git add $path"
                        #git add $path
                        Write-Host "Executing git command: git commit -m '$commitMessage'"
                        #git commit -m "$commitMessage"
                        Write-Host "Executing git command: git push origin master"
                        #git push origin master

                        # Logic for updating the package
                        # Check if the subtree branch exists
                        $subtreeBranch = "$scope.$feature"
                        $subtreeBranchExists = git ls-remote --heads origin $subtreeBranch

                        if ($subtreeBranchExists) {
                            # Logic for updating the package
                                Write-Host "Updating package '$scope.$feature'..."

                                # Execute git subtree push command
                                $remoteURL = "https://github.com/Mathieu-Schmerber/LemonInc.Packages"
                                Write-Host "Executing git command: git subtree push --prefix=$path $remoteURL $subtreeBranch"
                                #git subtree push --prefix=$path $remoteURL $subtreeBranch
                        } else {
                            # Logic for creating the package
                            $createPackage = Read-Host "The package '$scope.$feature' does not exist. Do you want to create it? (y/n)"
                            if ($createPackage -eq 'y') {
                                Write-Host "Creating package '$scope.$feature'..."
                                # Execute git subtree split command
                                Write-Host "Executing git command: git subtree split --prefix=$path --branch $subtreeBranch"
                                #git subtree split --prefix=$path --branch $subtreeBranch
                            }
                            else {
                                Write-Host "Package creation aborted."
                                return
                            }
                        }
                    }
                }
            }
        }
    }
}

<#
Main loop: Executes the interactive CLI.
#>
while ($true) {
    Show-CLIWelcomeMessage
    $input = Read-Host "Enter a command"
    switch ($input) {
        'c' {
            Process-CLICommand -command $input -action "Create"
        }
        'u' {
            Process-CLICommand -command $input -action "Update"
        }
        's' {
            Sync-Repository
        }
        'q' {
            exit
        }
        default {
            Write-Host "Invalid command: $input"
        }
    }

    Write-Host "`nPress Enter to continue..."
    $null = Read-Host
    Write-Host "`n"
}