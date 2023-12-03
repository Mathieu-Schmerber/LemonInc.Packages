using System;
using LemonInc.Core.Utilities;

namespace LemonInc.Tools.Databases.Models
{
	[Serializable]
	public class SectionDictionary : SerializedDictionary<string, SectionDefinition> { }
}