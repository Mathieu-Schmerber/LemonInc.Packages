[~] Edit Core.Utilities.Timer: make use of coroutines if possible
[~] Tools.Tilemap is a wip:
    - There are bugs (find them and fix them)
[+] Write documentation for everything

[+] Have a utility class that can store data such as scriptable objects in /Plugins/LemonInc/(...)
    This will provide LemonInc with a way to instantiate project data (whether for editor or gameplay purposes).
    Features needed:
    - Get data per key
    - Get data per type
    - Store data with key
    - Keys may be folders this way Editor/ folders can be created as well for settings related data.
    Example usages:
    - The resource panel can be made generic by switching its root path dynamically from within the editor, changing it will store the path within the LemonInc plugin storage.
    - Could even create a "Controls" Input action map (new input system) there for core.input to use, this way even if the package is updated, the controls asset is not cleared.