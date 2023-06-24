# LemonInc.Packages

This repository hosts all custom Unity packages that LemonInc uses for its projects.

- [LemonInc.Packages](#lemonincpackages)
- [Import a LemonInc package to your project](#import-a-lemoninc-package-to-your-project)
  - [Dependencies](#dependencies)
  - [Importing](#importing)
- [Developing packages](#developing-packages)
  - [Creating a new packkage](#creating-a-new-packkage)
  - [Publishing a new package](#publishing-a-new-package)
  - [Updating an existing package](#updating-an-existing-package)
- [Coming up...](#coming-up)

# Import a LemonInc package to your project

## Dependencies

Before importing any package from LemonInc, please make sure to install the following dependencies:
- [GitDependenciesResolver For Unity](https://github.com/mob-sakai/GitDependencyResolverForUnity)
  1. Open the Unity Package Manager Window
  1. At the top click the `+` icon > `Add package from git URL...`
  2. Input `https://github.com/mob-sakai/GitDependencyResolverForUnity`
  3. For any futur dependency issue, checkout the Github linked above
- [Sirenix.Odin](https://odininspector.com/)
    1. Buy from the asset store
    2. Import it using the Unity Package Manager Window
  

## Importing

1. Open the Unity Package Manager window.
1. At the top click the `+` icon > `Add package from git URL...`
1. Input `https://github.com/Mathieu-Schmerber/LemonInc.Packages.git#<scope>.<feature>`

    The scope corresponds to the global perimeter (core, gameplay, ...)
    > Example: https://github.com/Mathieu-Schmerber/LemonInc.Packages.git#core.pooling

# Developing packages

## Creating a new packkage

On the `master` branch, create the package structure within the `Assets/LemonInc/<Scope>/<new feature>` folder.

The package structure requires:
- `package.json`: sumarize the package details (name, description, dependencies, ...).
- `asmdef` file: the assembly definition asset.
- `Scripts/`: feature code.
- `Documentation/`: documentation folder with **at least** a `classes.puml` file.
- `Editor/`: optional editor scripts.
- `Tests/`: optional unit tests.

> The .meta files must not be deleted

## Publishing a new package

Publishing your feature requires you to create a subtree branch.
``` shell
git add -A
git commit -m "feat(<scope>.<feature>): whatever you did"
git subtree split --prefix=Assets/LemonInc/<scope>/<feature> --branch <scope>.<feature>
git subtree push --prefix=Assets/LemonInc/<scope>/<feature> https://github.com/Mathieu-Schmerber/LemonInc.Packages <scope>.<feature>
git push origin master
```
Your package is now ready to be imported on other projects !

## Updating an existing package

``` shell
git add -A
git commit -m "feat(<scope>.<feature>): whatever you did"
git push origin master
git subtree push --prefix=Assets/LemonInc/<scope>/<feature> https://github.com/Mathieu-Schmerber/LemonInc.Packages <scope>.<feature>
```

# Coming up...

- Some kind of script to make the publish process even easier.
- Some pipeline work to:
  - Ensure some % coverage
  - Make package.json configuration easier by using keyword such as $P{REPOSITORY_URL}
