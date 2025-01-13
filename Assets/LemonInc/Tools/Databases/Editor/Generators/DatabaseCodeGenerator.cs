using System.IO;
using System.Linq;
using System.Text;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Core.Utilities.Editor.Extensions;
using LemonInc.Tools.Databases.Editor.Ui;
using LemonInc.Tools.Databases.Models;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Tools.Databases.Editor.Generators
{
	/// <summary>
	/// Database code generator.
	/// </summary>
	public static class DatabaseCodeGenerator
	{
		/// <summary>
		/// Gets the class.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <returns></returns>
		public static string GetClass(DatabaseData database) => $"{database.Name.ToPascalCase()}Database";

		/// <summary>
		/// Generates the script.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="outputPath">The output path.</param>
		/// <param name="createFolders">if set to <c>true</c> [create folders].</param>
		public static void GenerateScript(DatabaseData database, string outputPath, bool createFolders = true)
		{
			var template = Resources.Load("Databases.Template") as TextAsset;
			var code = GenerateDatabaseClass(template.text, database);

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
		/// Generates the database classe.
		/// </summary>
		/// <param name="code">The code.</param>
		/// <param name="database">The database.</param>
		/// <returns></returns>
		private static string GenerateDatabaseClass(string code, DatabaseData database)
		{
			var builder = new StringBuilder();

			GenerateDatabase(database, builder);
			builder.AppendLine();

			return code.Replace("{@databases}", builder.ToString());
		}

		/// <summary>
		/// Generates the database.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateDatabase(DatabaseData database, StringBuilder builder)
		{
			builder.AppendLine($"public class {GetClass(database)} : Singleton<{GetClass(database)}>");
			builder.AppendLine($"{{");
			builder.AppendLine($"private {nameof(DatabaseData)} _data;");
			builder.AppendLine("#if UNITY_EDITOR");
			builder.AppendLine($"public {nameof(DatabaseData)} {GetClass(database)}Data => _data ??= AssetDatabase.LoadAllAssetsAtPath(\"{database.GetPath()}\").FirstOrDefault() as {nameof(DatabaseData)};");
			builder.AppendLine("#else");
			builder.AppendLine($"public {nameof(DatabaseData)} {GetClass(database)} => _data ??= Resources.Load<{nameof(DatabaseData)}>(\"{database.Name}\");");
			builder.AppendLine("#endif");
			foreach (var section in DatabaseEditorWindow.GetRoots(database))
			{
				GenerateSection(database, section, builder);
				builder.AppendLine();
			}

			builder.AppendLine($"}}");
		}

		/// <summary>
		/// Generates the section.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="section">The section.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateSection(DatabaseData database, SectionDescription section, StringBuilder builder)
		{
			builder.AppendLine($"public static class {section.Name.ToPascalCase()}");
			builder.AppendLine($"{{");

			GenerateAssets(database, section, builder);
			if (section.Sections != null)
			{
				foreach (var sectionId in section.Sections)
				{
					var childSection = database.SectionDefinitions[sectionId];
					GenerateSection(database, childSection, builder);
				}
			}

			builder.AppendLine($"}}");
		}

		/// <summary>
		/// Generates the assets.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="section">The section.</param>
		/// <param name="builder">The builder.</param>
		private static void GenerateAssets(DatabaseData database, SectionDescription section, StringBuilder builder)
		{
			var all = string.Empty;

			foreach (var assetId in section.Assets)
			{
				var asset = database.AssetDefinitions[assetId];
				var template = $"public static [type] [name] = ([type]){GetClass(database)}.Instance.{GetClass(database)}Data.AssetDefinitions[\"[id]\"].Data;"
					.Replace("[type]", asset.Data.GetType().FullName)
					.Replace("[name]", asset.Name.ToPascalCase())
					.Replace("[id]", assetId);

				var coma = section.Assets.Last() == assetId ? "" : ", ";
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
			builder.AppendLine($"   var all = new UnityEngine.Object[{section.Assets.Count}] {{ {all} }};");
			builder.AppendLine("   return all.OfType<T>();");
			builder.AppendLine("}");
		}
	}
}
