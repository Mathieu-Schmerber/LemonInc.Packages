# LemonInc.Packages

This repository hosts all custom Unity packages that LemonInc uses for its projects.

- [LemonInc.Packages](#lemonincpackages)
- [Import a LemonInc package to your project](#import-a-lemoninc-package-to-your-project)
  - [Importing](#importing)
- [Developing packages](#developing-packages)
- [Coming up...](#coming-up)

# Import a LemonInc package to your project
## Importing

1. Open the Unity Package Manager window.
1. At the top click the `+` icon > `Add package from git URL...`
1. Input `https://github.com/Mathieu-Schmerber/LemonInc.Packages.git#tools.packager`
1. Open the menu item `Tools/LemonInc/Package Handler Window`
1. You can then select whichever package you want to import. 

# Developing packages

Creating a package is pretty straight forward, just create the correct package structure within the "Assets/LemonInc/\<Scope>/\<Feature>" folder.

To publish or update your package, run
``` html
./publish.exe -s
```
