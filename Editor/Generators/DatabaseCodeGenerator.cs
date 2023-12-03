using System.Collections.Generic;
using LemonInc.Tools.Databases.Models;
using System.IO;
using System.Text;
using LemonInc.Core.Utilities.Extensions;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Tools.Databases.Generators
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
			var code = GenerateDatabaseClasses(template.text, databases.Databases); ;

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
		/// <param name="databasesDatabases">The databases databases.</param>
		/// <returns></returns>
		private static string GenerateDatabaseClasses(string code, SectionDictionary databasesDatabases)
		{
			var builder = new StringBuilder();

			foreach (var (id, database) in databasesDatabases)
			{
				GenerateDatabase(database, builder);
				builder.AppendLine();
			}

			return code.Replace("{@databases}", builder.ToString());
		}

		/// <summary>
		/// Generates the database.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateDatabase(SectionDefinition database, StringBuilder builder)
		{
			builder.AppendLine($"public class {database.Name.ToPascalCase()} : Singleton<{database.Name.ToPascalCase()}>");
			builder.AppendLine($"{{");
			builder.AppendLine($"private {nameof(DatabaseConfiguration)} _configInstance;");
			builder.AppendLine($"private {nameof(DatabaseConfiguration)} Configuration => _configInstance ??= {nameof(DatabaseConfiguration)}.{nameof(DatabaseConfiguration.Instance)};");

			foreach (var (id, section) in database.Sections)
			{
				GenerateSection(section, builder);
				builder.AppendLine();
			}

			builder.AppendLine($"}}");
		}

		/// <summary>
		/// Generates the section.
		/// </summary>
		/// <param name="section">The section.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateSection(SectionDefinition section, StringBuilder builder)
		{
			builder.AppendLine($"public class {section.Name.ToPascalCase()}");
			builder.AppendLine($"{{");

			GenerateAssets(section, builder);
			if (section.Sections != null)
			{
				foreach (var (id, childSection) in section.Sections)
				{
					GenerateSection(childSection, builder);
				}
			}
			
			builder.AppendLine($"}}");
		}

		/// <summary>
		/// Generates the assets.
		/// </summary>
		/// <param name="section">The section.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateAssets(SectionDefinition section, StringBuilder builder)
		{
			string all = "";
			var path = new Stack<string>();
			var current = section;
			while (current != null)
			{
				path.Push(current.Id);
				current = current.Parent;
			}

			var codePath = $"Instance.Configuration.Databases[\"{path.Pop()}\"]";
			for (var i = 0; i < path.Count; i++)
				codePath += $".Sections[\"{path.Pop()}\"]";

			for (var i = 0; i < section.Assets.Count; i++)
			{
				var asset = section.Assets[i];
				var template = "public static {type} {name} = ({type}){path}.Assets[{index}].Data;"
					.Replace("{type}", asset.Data.GetType().FullName)
					.Replace("{name}", asset.Name.ToPascalCase())
					.Replace("{path}", codePath)
					.Replace("{index}", i.ToString());

				var coma = i == section.Assets.Count - 1 ? "" : ", ";
				all += $"{asset.Name.ToPascalCase()}{coma}";

				builder.AppendLine(template);
			}

			builder.AppendLine();
			builder.AppendLine("/// <summary>");
			builder.AppendLine("/// Gets all assets from this section.");
			builder.AppendLine("/// </summary>");
			builder.AppendLine("/// <returns>An <see cref=\"IEnumerable{T}\"/> of all assets.</returns>");
			builder.AppendLine("public static IEnumerable<T> All<T>()");
			builder.AppendLine("   where T : UnityEngine.Object");
			builder.AppendLine("{");
			builder.AppendLine($"var all = new UnityEngine.Object[{section.Assets.Count}] {{ {all} }};");
			builder.AppendLine("return all.OfType<T>();");
			builder.AppendLine("}");

		}
	}
}
