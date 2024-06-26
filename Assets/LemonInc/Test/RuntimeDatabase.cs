///
/// This code has been auto-generated by LemonInc.Tools.Databases
///

using LemonInc.Core.Utilities;
using LemonInc.Tools.Databases.Models;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Databases
{
	public class RuntimeDatabase : Singleton<RuntimeDatabase>
{
private DatabaseData _data;
#if UNITY_EDITOR
public DatabaseData Data => _data ??= AssetDatabase.LoadAllAssetsAtPath("Assets/LemonInc/Test/Resources/Runtime.asset").FirstOrDefault() as DatabaseData;
#else
public DatabaseData Data => _data ??= Resources.Load<DatabaseData>("Runtime");
#endif
public static class Section
{
public static UnityEngine.Texture2D NewAsset = (UnityEngine.Texture2D)RuntimeDatabase.Instance.Data.AssetDefinitions["d1d47d82-f601-45f7-b886-47108090c4e2"].Data;

/// <summary>
/// Gets all assets from this section.
/// </summary>
/// <returns>An <see cref="IEnumerable{T}"/> of all assets.</returns>
public static IEnumerable<T> All<T>()
   where T : UnityEngine.Object
{
   var all = new UnityEngine.Object[1] { NewAsset };
   return all.OfType<T>();
}
}

}


}

