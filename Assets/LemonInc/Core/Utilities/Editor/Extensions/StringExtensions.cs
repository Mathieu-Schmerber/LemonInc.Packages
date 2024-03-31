using System;
using System.IO;
using LemonInc.Core.Utilities.Extensions;

namespace LemonInc.Core.Utilities.Editor.Extensions
{
	/// <summary>
	/// String extension methods.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Converts a full path to an asset path.
		/// </summary>
		/// <param name="fullPath">The full path.</param>
		/// <returns>The asset path.</returns>
		public static string ToAssetPath(this string fullPath)
		{
			if (string.IsNullOrEmpty(fullPath))
				return string.Empty;

			var index = fullPath.IndexOf("Assets", StringComparison.Ordinal);
			return fullPath.Remove(0, index).Replace("\\", "/");
		}

		/// <summary>
		/// Converts the folder path to namespace.
		/// </summary>
		/// <param name="folderPath">The folder path.</param>
		/// <returns></returns>
		public static string ConvertFolderPathToNamespace(string folderPath)
		{
			// Remove any leading/trailing slashes and normalize the path
			folderPath = folderPath.Trim('/', '\\');

			// Split the folder path into individual parts
			var folderParts = folderPath.Split(new[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
			for (var i = 0; i < folderParts.Length; i++)
				folderParts[i] = folderParts[i].ToPascalCase();
			
			return string.Join(".", folderParts);
		}

		/// <summary>
		/// Converts to namespace.
		/// </summary>
		/// <param name="assetPath">The path.</param>
		/// <param name="fetchAsm">If true, looks for an asm definition file recursively.</param>
		/// <returns>The namespace name.</returns>
		public static string ToNamespace(this string assetPath, bool fetchAsm = true)
		{
			var directory = Path.GetDirectoryName(assetPath);
			if (string.IsNullOrEmpty(directory))
				return null;

			if (!fetchAsm)
				return ConvertFolderPathToNamespace(directory);

			var rootNamespace = GetRootNamespaceFromAsmdef(directory);
			if (rootNamespace != null)
			{
				var relativePath = Path.GetRelativePath(directory, assetPath);
				var remainingNamespace = string.Join(".", relativePath.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar));

				return string.IsNullOrEmpty(remainingNamespace) ? rootNamespace : $"{rootNamespace}.{remainingNamespace}";
			}

			return ConvertFolderPathToNamespace(directory);
		}

		/// <summary>
		/// Gets the root namespace from asmdef.
		/// </summary>
		/// <param name="directory">The directory.</param>
		/// <returns></returns>
		private static string GetRootNamespaceFromAsmdef(string directory)
		{
			var asmdefFilePath = GetClosestAsmdefFilePath(directory);

			if (asmdefFilePath != null)
			{
				var asmdefContent = File.ReadAllLines(asmdefFilePath);
				foreach (var line in asmdefContent)
				{
					if (line.Contains("\"rootNamespace\""))
					{
						return line.Trim()
							.Replace("\"rootNamespace\": \"", "")
							.Replace("\",", "");
					}
				}
			}

			return null;
		}

		/// <summary>
		/// Gets the closest asmdef file path.
		/// </summary>
		/// <param name="directory">The directory.</param>
		/// <returns></returns>
		private static string GetClosestAsmdefFilePath(string directory)
		{
			while (!string.IsNullOrEmpty(directory))
			{
				var asmdefFiles = Directory.GetFiles(directory, "*.asmdef");
				if (asmdefFiles.Length > 0)
				{
					return asmdefFiles[0];
				}

				directory = Directory.GetParent(directory)?.FullName;
			}

			return null;
		}
	}
}