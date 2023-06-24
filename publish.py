import os
import subprocess
import sys
from termcolor import colored

def has_changes(path):
    cmd = ['git', 'status', '--porcelain', '--', path]
    result = subprocess.run(cmd, capture_output=True, text=True)
    return bool(result.stdout.strip())

def execute_git_commands(path, action, scope, feature, commit_msg):
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

def check_package_validity(path, scope, feature):
    # Define required files and folders
    required_items = [
        {
            'Path': os.path.join(path, 'Documentation'),
            'Type': 'd',
            'ErrorMessage': "The 'Documentation' folder is missing.",
            'NoFileErrorMessage': "The 'Documentation' folder does not contain any files."
        },
        {
            'Path': os.path.join(path, 'package.json'),
            'Type': 'f',
            'ErrorMessage': "The 'package.json' file is missing."
        },
        {
            'Path': os.path.join(path, f"LemonInc.{scope}.{feature}.asmdef"),
            'Type': 'f',
            'ErrorMessage': f"The 'LemonInc.{scope}.{feature}.asmdef' file is missing."
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
    
def publish_package(package_name, commit_msg):
    scope, feature = package_name.split('.')
    base_path = "Assets\LemonInc"
    path = os.path.realpath(f"{base_path}\{scope}\{feature}")
    path = slicer(path, base_path)

    if os.path.exists(path):
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
                        print(colored(f"The package '{package_name}' already exists in the repository. Updating the package...", "cyan"))
                    else:
                        action = 'create'
                        print(colored(f"The package '{package_name}' does not exist in the repository. Creating the package...", "cyan"))

                    execute_git_commands(path, action, scope, feature, commit_msg)

                else:
                    print(colored("❌ Git remote URL not found.", "red"))

            else:
                print(colored("❌ Current directory is not a valid Git repository.", "red"))
        else:
            print(colored(f"❌ The package '{package_name}' is not valid.", "red"))

    else:
        print(colored(f"❌ The path '{path}' does not exist.", "red"))

if __name__ == "__main__":
    if len(sys.argv) < 2 or len(sys.argv) > 3:
        print(colored("Usage: python app.py <package_name> [commit message]", "yellow"))
        sys.exit(1)
    package_name = sys.argv[1]
    commit_msg = sys.argv[2] if len(sys.argv) > 2 else None
    publish_package(package_name, commit_msg)