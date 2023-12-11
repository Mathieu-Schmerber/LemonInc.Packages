using System;
using LemonInc.Core.Utilities;

namespace LemonInc.Tools.Databases.Models
{
	[Serializable] public class AssetDictionary : SerializedDictionary<string, AssetDefinition> { }
}