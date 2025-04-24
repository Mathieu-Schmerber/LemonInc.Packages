import os
import subprocess
import sys
import json
from termcolor import colored

def get_package_version(package_path):
    """Get the version number from the package.json file"""
    json_path = os.path.join(package_path, 'package.json')
    if os.path.exists(json_path):
        try:
            with open(json_path, 'r') as f:
                package_data = json.load(f)
                return package_data.get('version')
        except (json.JSONDecodeError, IOError) as e:
            print(colored(f"Error reading package.json: {e}", "red"))
    return None

def get_last_committed_version(package_path):
    """Get the last committed version from Git"""
    package_json_path = os.path.join(package_path, 'package.json')
    cmd = ['git', 'show', 'HEAD:' + package_json_path.replace('\\', '/')]
    try:
        result = subprocess.run(cmd, capture_output=True, text=True)
        if result.returncode == 0:
            package_data = json.loads(result.stdout)
            return package_data.get('version')
    except (json.JSONDecodeError, subprocess.SubprocessError) as e:
        print(colored(f"Error getting last committed version: {e}", "red"))
    return None

def has_version_changed(package_path):
    """Check if the version number has changed compared to the last commit"""
    current_version = get_package_version(package_path)
    committed_version = get_last_committed_version(package_path)
    
    if current_version is None or committed_version is None:
        # If we can't determine versions, fall back to git status
        return has_changes(package_path), current_version, committed_version
    
    return current_version != committed_version, current_version, committed_version

def has_changes(path):
    cmd = ['git', 'status', '--porcelain', '--', path]
    result = subprocess.run(cmd, capture_output=True, text=True)
    return bool(result.stdout.strip())

def pascal_to_dashed(pascal_case):
    dashed_case = ""
    for i, char in enumerate(pascal_case):
        if i > 0 and char.isupper():
            dashed_case += "-" + char.lower()
        else:
            dashed_case += char.lower()
    return dashed_case

def dashed_to_pascal(dashed_case):
    pascal_case = ""
    capitalize_next = True
    for char in dashed_case:
        if char == "-":
            capitalize_next = True
        else:
            if capitalize_next:
                pascal_case += char.upper()
                capitalize_next = False
            else:
                pascal_case += char
    return pascal_case

def execute_git_commands(path, action, scope, feature, commit_msg = None):
    scope = pascal_to_dashed(scope)
    feature = pascal_to_dashed(feature)
    package_name = f"{scope}.{feature}"
    if has_changes(path):
        commit_message = commit_msg if commit_msg else input("Enter the commit message: ")
        subprocess.run(['git', 'add', path])
        subprocess.run(['git', 'commit', '-m', commit_message])
        subprocess.run(['git', 'push', 'origin', 'master'])
        print(colored("✅ Changes committed and pushed successfully.", "green", attrs=["bold"]))
    else:
        print(colored(f"No changes detected for {path}, forcing the update...", "grey"))

    if action == 'create':
        branch = f"{scope}.{feature}".lower()
        result = subprocess.run(['git', 'subtree', 'split', f'--prefix={path}', '--branch', branch])
        if result.returncode == 0:
            print(colored(f"Package '{package_name}' created successfully.", "green", attrs=["bold"]))
        else:
            print(result.stderr)
            print(colored(f"❌ Failed to create package '{package_name}'.", "red", attrs=["bold"]))
    else:
        remote_url = "https://github.com/Mathieu-Schmerber/LemonInc.Packages"
        branch = f"{scope}.{feature}".lower()
        subtree_command = ['git', 'subtree', 'push', f'--prefix={path}', remote_url, branch]
        result = subprocess.run(subtree_command, capture_output=True, text=True)
        if result.returncode == 0:
            print(colored(f"✅ Package '{package_name}' updated successfully.", "green", attrs=["bold"]))
        else:
            print(result.stderr)
            print(colored(f"❌ Failed to update package '{package_name}'.", "red", attrs=["bold"]))

def process_package_batch(packages_to_process):
    """Process a batch of packages at once"""
    for package_info in packages_to_process:
        path = package_info["path"]
        action = package_info["action"]
        scope = package_info["scope"]
        feature = package_info["feature"]
        commit_msg = package_info["commit_msg"]
        
        print(colored(f"Processing {scope}.{feature}...", "cyan"))
        execute_git_commands(path, action, scope, feature, commit_msg)
    
    print(colored(f"✅ All packages have been processed successfully.", "green", attrs=["bold"]))

def check_package_validity(path, scope, feature):
    # Define required files and folders
    required_items = [
        {
            'Path': os.path.join(path, 'Documentation~'),
            'Type': 'd',
            'ErrorMessage': "The 'Documentation~' folder is missing.",
            'NoFileErrorMessage': "The 'Documentation~' folder does not contain any files."
        },
        {
            'Path': os.path.join(path, 'package.json'),
            'Type': 'f',
            'ErrorMessage': "The 'package.json' file is missing."
        }
    ]

    # Check required files and folders
    is_valid_package = True

    for item in required_items:
        item_path = item['Path']
        item_type = item['Type']
        error_message = item['ErrorMessage']
        no_file_error_message = item.get('NoFileErrorMessage')

        if not os.path.exists(item_path) or (item_type == 'd' and not os.path.isdir(item_path)):
            is_valid_package = False
            print(colored(f"❌ {error_message}", "red"))

        if item_type == 'd' and (not os.path.exists(item_path) or not os.listdir(item_path)):
            is_valid_package = False
            print(colored(f"❌ {no_file_error_message}", "red"))

    # Check .meta files
    if is_valid_package:
        for item in required_items:
            item_path = item['Path']
            if item_path.endswith("~"):
                continue
            meta_file = f"{item_path}.meta"
            if not os.path.exists(meta_file) or not os.path.isfile(meta_file):
                is_valid_package = False
                print(colored(f"❌ The '{meta_file}' file is missing.", "red"))
                return is_valid_package  # Stop execution without fully exiting the CLI
    return is_valid_package

def slicer(my_str, sub):
    index = my_str.find(sub)
    if index != -1:
        return my_str[index:]
    else:
        raise Exception('Substring not found!')
    
def list_folders(root_path):
    folders_list = []
    for root, dirs, files in os.walk(root_path):
        depth = root[len(root_path):].count(os.sep)
        if depth == 2:
            folders_list.append(root)
    return folders_list

def sync_packages():
    base_path = "Assets/LemonInc"
    folders = list_folders(base_path)
    folders = [item for item in folders if "Test" not in item]
    packages_to_process = []

    print(folders)
    for folder in folders:
        package_path = folder
        _, scope, feature = package_path.split(os.sep)
        package_name = f"{scope}.{feature}"

        # First check if the package has any changes
        if has_changes(package_path):
            # Then check if the version number has changed
            version_changed, current_version, committed_version = has_version_changed(package_path)
            
            if not version_changed:
                print(colored(f"Package \"{package_name}\" has been changed but its version number has not changed, skipping...", "yellow"))
                continue
                
            # Proceed with the valid package that has a version change
            is_valid_package = check_package_validity(package_path, scope, feature)
            if is_valid_package:
                if os.path.exists('.git'):
                    os.chdir('.git')
                    repo_url = subprocess.run(['git', 'config', '--get', 'remote.origin.url'],
                                              capture_output=True, text=True).stdout.strip()
                    os.chdir('..')

                    if repo_url:
                        # Check if the package already exists in the repository
                        package_exists = subprocess.run(['git', 'ls-remote', '--heads', 'origin', f'{scope}.{feature}'],
                                                        capture_output=True, text=True).returncode == 0

                        if package_exists:
                            action = 'update'
                            package_description = f"update package '{package_name}' (version {committed_version} → {current_version})"
                        else:
                            action = 'create'
                            package_description = f"create new package '{package_name}' (version {current_version})"
                        
                        # Ask the user if they want to upload this package
                        print(colored(f"The package \"{package_name}\" has been changed (version {committed_version} → {current_version}), should it be uploaded?", "cyan"))
                        choice = input(colored("[Y] - Yes\n[N] - No\n> ", "cyan")).strip().upper()
                        
                        if choice == 'Y':
                            commit_msg = input(f"Enter commit message for {package_description}: ")
                            packages_to_process.append({
                                "path": package_path.replace("\\", "/"),
                                "action": action,
                                "scope": scope,
                                "feature": feature,
                                "commit_msg": commit_msg
                            })
                            print(colored(f"✅ Package '{package_name}' added to upload queue.", "green"))
                        else:
                            print(colored(f"⏭️  Skipping package '{package_name}'", "yellow"))
                    else:
                        print(colored("❌ Git remote URL not found.", "red"))
                else:
                    print(colored("❌ Current directory is not a valid Git repository.", "red"))
            else:
                print(colored(f"❌ The package '{package_path}' is not valid.", "red"))
        else:
            print(colored(f"No changes detected for package '{package_path}', skipping...", "grey"))
    
    # Process all packages at once after reviewing all of them
    if packages_to_process:
        print(colored(f"\nProcessing {len(packages_to_process)} package(s)...", "cyan"))
        process_package_batch(packages_to_process)
    else:
        print(colored("No packages selected for upload.", "yellow"))


def publish_package(package_name, commit_msg):
    scope, feature = package_name.split('.')
    scope = dashed_to_pascal(scope)
    feature = dashed_to_pascal(feature)
    base_path = "Assets\LemonInc"
    path = os.path.realpath(f"{base_path}\{scope}\{feature}")
    path = slicer(path, base_path).replace("\\", "/")

    if os.path.exists(path):
        # Check if version has changed before publishing
        version_changed, current_version, committed_version = has_version_changed(path)
        if not version_changed and has_changes(path):
            print(colored(f"Package \"{scope}.{feature}\" has been changed but its version number has not changed, skipping...", "yellow"))
            return
            
        is_valid_package = check_package_validity(path, scope, feature)
        if is_valid_package:
            if os.path.exists('.git'):
                os.chdir('.git')
                repo_url = subprocess.run(['git', 'config', '--get', 'remote.origin.url'], capture_output=True, text=True).stdout.strip()
                os.chdir('..')

                if repo_url:
                    # Check if the package already exists in the repository
                    package_exists = subprocess.run(['git', 'ls-remote', '--heads', 'origin', f'{scope}.{feature}'], capture_output=True, text=True).returncode == 0

                    if package_exists:
                        action = 'update'
                        print(colored(f"The package '{package_name}' already exists in the repository. Updating the package (version {committed_version} → {current_version})...", "cyan"))
                    else:
                        action = 'create'
                        print(colored(f"The package '{package_name}' does not exist in the repository. Creating the package (version {current_version})...", "cyan"))

                    execute_git_commands(path, action, scope, feature, commit_msg)

                else:
                    print(colored("❌ Git remote URL not found.", "red"))

            else:
                print(colored("❌ Current directory is not a valid Git repository.", "red"))
        else:
            print(colored(f"❌ The package '{package_name}' is not valid.", "red"))

    else:
        print(colored(f"❌ The path '{path}' does not exist.", "red"))

def handle_publish(package_name, commit_msg):
    if len(package_name) == 2 and package_name[1] == "-s":
        sync_packages()
        return

    if len(package_name) < 2 or len(package_name) > 3:
        print(colored("Usage: python app.py <package_name> [commit message]\t - \tPublishes the specified package\n"
                      "       python app.py -s \t\t\t\t - \tSynchronizes the local and the remote", "yellow"))
        sys.exit(1)

    publish_package(package_name[1], commit_msg)

if __name__ == "__main__":
    handle_publish(sys.argv, None if len(sys.argv) <= 2 else sys.argv[2])