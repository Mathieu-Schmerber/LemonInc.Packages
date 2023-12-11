using System;
using LemonInc.Core.Utilities;

namespace LemonInc.Tools.Databases.Editor.Models
{
	[Serializable]
	public class SectionDictionary : SerializedDictionary<string, SectionDefinition> { }
}