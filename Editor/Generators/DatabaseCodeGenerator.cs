using System.IO;
using System.Linq;
using System.Text;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Tools.Databases.Models;
using UnityEditor;
using UnityEngine;
using DatabaseConfiguration = LemonInc.Tools.Databases.Editor.Models.DatabaseConfiguration;

namespace LemonInc.Tools.Databases.Editor.Generators
{
	/// <summary>
	/// Database code generator.
	/// </summary>
	public static class DatabaseCodeGenerator
	{
		/// <summary>
		/// Generates the script.
		/// </summary>
		/// <param name="databases">The databases.</param>
		/// <param name="outputPath">The output path.</param>
		/// <param name="createFolders">if set to <c>true</c> [create folders].</param>
		public static void GenerateScript(DatabaseConfiguration databases, string outputPath, bool createFolders = true)
		{
			var template = Resources.Load("Databases.Template") as TextAsset;
			var code = GenerateDatabaseClasses(template.text, databases);

			if (createFolders)
			{
				var directory = Path.GetDirectoryName(outputPath);
				Directory.CreateDirectory(directory);
			}

			using (var stream = new StreamWriter(Path.GetFullPath(outputPath)))
				stream.WriteLine(code);
			AssetDatabase.Refresh();
		}

		/// <summary>
		/// Generates the database classes.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="databases">The databases.</param>
		/// <returns></returns>
		private static string GenerateDatabaseClasses(string code, DatabaseConfiguration databases)
		{
			//var builder = new StringBuilder();

			//foreach (var id in databases.DatabaseIds)
			//{
			//	var database = databases.SectionDefinitions[id];
			//	GenerateDatabase(databases, database, builder);
			//	builder.AppendLine();
			//}

			//return code.Replace("{@databases}", builder.ToString());
			return "";
		}

		/// <summary>
		/// Generates the database.
		/// </summary>
		/// <param name="databases">The databases.</param>
		/// <param name="database">The database.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateDatabase(DatabaseConfiguration databases, SectionDescription database, StringBuilder builder)
		{
			builder.AppendLine($"public static class {database.Name.ToPascalCase()}");
			builder.AppendLine($"{{");

			//foreach (var sectionId in database.Sections)
			//{
			//	var section = databases.SectionDefinitions[sectionId];
			//	GenerateSection(databases, section, builder);
			//	builder.AppendLine();
			//}

			builder.AppendLine($"}}");
		}

		/// <summary>
		/// Generates the section.
		/// </summary>
		/// <param name="databases">The databases.</param>
		/// <param name="section">The section.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateSection(DatabaseConfiguration databases, SectionDescription section, StringBuilder builder)
		{
			builder.AppendLine($"public static class {section.Name.ToPascalCase()}");
			builder.AppendLine($"{{");

			//GenerateAssets(databases, section, builder);
			//if (section.Sections != null)
			//{
			//	foreach (var sectionId in section.Sections)
			//	{
			//		var childSection = databases.SectionDefinitions[sectionId];
			//		GenerateSection(databases, childSection, builder);
			//	}
			//}
			
			builder.AppendLine($"}}");
		}

		/// <summary>
		/// Generates the assets.
		/// </summary>
		/// <param name="databases">The databases.</param>
		/// <param name="section">The section.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateAssets(DatabaseConfiguration databases, SectionDescription section, StringBuilder builder)
		{
			var all = string.Empty;

			//foreach (var assetId in section.Assets)
			//{
			//	var asset = databases.AssetDefinitions[assetId];
			//	var template = "public static {type} {name} = Resources.Load<{type}>(\"{path}\");"
			//		.Replace("{type}", asset.Data.GetType().FullName)
			//		.Replace("{name}", asset.Name.ToPascalCase())
			//		.Replace("{path}", asset.Path);

			//	Debug.Log(asset.Path);
			//	var coma = section.Assets.Last() == assetId ? "" : ", ";
			//	all += $"{asset.Name.ToPascalCase()}{coma}";

			//	builder.AppendLine(template);
			//}

			builder.AppendLine();
			builder.AppendLine("/// <summary>");
			builder.AppendLine("/// Gets all assets from this section.");
			builder.AppendLine("/// </summary>");
			builder.AppendLine("/// <returns>An <see cref=\"IEnumerable{T}\"/> of all assets.</returns>");
			builder.AppendLine("public static IEnumerable<T> All<T>()");
			builder.AppendLine("   where T : UnityEngine.Object");
			builder.AppendLine("{");
			builder.AppendLine($"   var all = new UnityEngine.Object[{section.Assets.Count}] {{ {all} }};");
			builder.AppendLine("   return all.OfType<T>();");
			builder.AppendLine("}");
		}
	}
}
