# LemonInc.Packages

This repository hosts all custom Unity packages that LemonInc uses for its projects.

## Import a package to your project

1. Open the Unity Package Manager window.
1. At the top click the `+` icon > `Add package from git URL...`
1. Input `https://github.com/Mathieu-Schmerber/LemonInc.Packages.git#<scope>.<feature>`

    The scope corresponds to the global perimeter (core, gameplay, ...)
    > Example: https://github.com/Mathieu-Schmerber/LemonInc.Packages.git#core.pooling

## Creating a new package

### Initialize

On the `master` branch, create the package structure within the `Assets/LemonInc/<Scope>/<new feature>` folder.

The package structure requires:
- `package.json`: sumarize the package details (name, description, dependencies, ...).
- `asmdef` file: the assembly definition asset.
- `Scripts/`: feature code.
- `Documentation/`: documentation folder with **at least** a `classes.puml` file.
- `Editor/`: optional editor scripts.
- `Tests/`: optional unit tests.

> The .meta files must not be deleted

### Publish

Publishing your feature requires you to create a subtree branch.
> git add -A

> git commit -m "feat(\<scope>.\<feature>): whatever you did"

> git subtree split --prefix=Assets/LemonInc/\<scope>/\<feature>

> git push origin \<scope>.\<feature>

> git push origin master

Your package is now ready to be imported on other projects !

### Coming up...

- Some kind of script to make the publish process even easier.
- Some pipeline work to ensure a unit testing coverage % before publishing a feature
