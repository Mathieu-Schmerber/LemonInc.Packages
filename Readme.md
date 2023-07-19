# LemonInc.Packages

This repository hosts all custom Unity packages that LemonInc uses for its projects.

- [LemonInc.Packages](#lemonincpackages)
- [Import a LemonInc package to your project](#import-a-lemoninc-package-to-your-project)
  - [Dependencies](#dependencies)
  - [Importing](#importing)
- [Developing packages](#developing-packages)
- [Coming up...](#coming-up)

# Import a LemonInc package to your project

## Dependencies (Soon to be deprecated)

Before importing any package from LemonInc, please make sure to install the following dependencies:
- [GitDependenciesResolver For Unity](https://github.com/mob-sakai/GitDependencyResolverForUnity)
  1. Open the Unity Package Manager Window
  1. At the top click the `+` icon > `Add package from git URL...`
  2. Input `https://github.com/mob-sakai/GitDependencyResolverForUnity.git`
  3. For any futur dependency issue, checkout the Github linked above
- [Sirenix.Odin](https://odininspector.com/)
    1. Buy from the asset store
    2. Import it using the Unity Package Manager Window
- [Surge](https://surge.pixelplacement.com/index.html)
  1. Import it using the Unity Package Manager Window
  

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

# Coming up...

- LemonInc Package Handler:
  - Install external dependencies
- Some pipeline work to:
  - Ensure some % coverage
  - Make package.json configuration easier by using keyword such as $P{REPOSITORY_URL}
