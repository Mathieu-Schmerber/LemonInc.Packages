using System.IO;
using System.Linq;
using LemonInc.Core.Pooling.Providers;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Pooling.Editor
{
	/// <summary>
	/// Generates a static pooling access to the <see cref="NamedObjectPoolProvider"/>.
	/// </summary>
	public static class NamedPoolingCodeGenerator
	{
		/// <summary>
		/// Generates the script.
		/// </summary>
		public static void GenerateScript(NamedObjectPoolProvider provider, string outputPath, bool generateFolders = true)
		{
			var template = Resources.Load("Template") as TextAsset;
			var code = template.text;
			var pools = provider.GetPools();
			var enumPools = string.Join(',', pools.Keys);

			code = code.Replace("{@Pools}", enumPools);

			if (generateFolders)
			{
				var directory = Path.GetDirectoryName(outputPath);
				Directory.CreateDirectory(directory);
			}

			File.WriteAllText(outputPath, code);
			AssetDatabase.Refresh();
		}
	}
}
