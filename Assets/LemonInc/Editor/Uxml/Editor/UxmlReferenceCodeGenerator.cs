using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Editor.Utilities.Extensions;
using UnityEditor;

namespace LemonInc.Editor.Uxml
{
	/// <summary>
	/// Uxml reference code generator.
	/// </summary>
	internal static class UxmlReferenceCodeGenerator
	{
		internal class Property
		{
			public string CodeName { get; set; }
			public string UxmlName { get; set; }
			public string Type { get; set; }
		}

		/// <summary>
		/// The type blacklist.
		/// </summary>
		private static readonly string[] TYPE_BLACKLIST = { "UXML", "Instance" };

		/// <summary>
		/// The translation list.
		/// </summary>
		private static readonly IDictionary<string, string> TYPE_TRANSLATION = new Dictionary<string, string>
		{
			{"Template", "TemplateContainer"}
		};

		/// <summary>
		/// Generates the code.
		/// </summary>
		/// <param name="assetDefinition">The asset definition.</param>
		/// <param name="createDirectory">If true, create the directory if not exist.</param>
		public static void GenerateCode(UxmlAssetDefinition assetDefinition, bool createDirectory = true)
		{
			var folder = Path.GetDirectoryName(assetDefinition.ReferenceClass);
			var @namespace = folder.ToNamespace();
			var classname = Path.GetFileNameWithoutExtension(assetDefinition.ReferenceClass);
			var elements = ParseNamedElements(assetDefinition.AssetPath);

			var properties = GeneratePropertiesCode(elements);
			var ctor = GetConstructorCode(classname);
			var finalCode = EncapsulateCode(@namespace, classname, properties, ctor);

			if (createDirectory)
				Directory.CreateDirectory(folder);

			try
			{
				File.WriteAllText(assetDefinition.ReferenceClass, finalCode);
			}
			catch (Exception e)
			{
				UxmlLogger.LogError(e);
				throw;
			}

			AssetDatabase.Refresh();
		}

		/// <summary>
		/// Parse named properties.
		/// </summary>
		/// <param name="path">The asset path.</param>
		/// <returns>The named properties.</returns>
		private static IDictionary<string, Property> ParseNamedElements(string path)
		{
			var content = File.ReadAllText(path);
			var result = new Dictionary<string, Property>();

			foreach (var line in content.Split(Environment.NewLine))
			{
				var uxmlLine = line.Trim();
				if (uxmlLine.Contains("<ui:"))
					uxmlLine = uxmlLine.Substring("<ui:".Length);
				else if (uxmlLine.Contains("<"))
					uxmlLine = uxmlLine.Substring("<".Length);
				else
					continue;

				var uxmlProps = uxmlLine.Split(' ');
				var type = uxmlProps[0];
				if (TYPE_BLACKLIST.Contains(type))
					continue;
				if (TYPE_TRANSLATION.ContainsKey(type))
					type = type.Replace(type, TYPE_TRANSLATION[type]);

				var nameProp = uxmlProps.FirstOrDefault(x => x.StartsWith("name="));
				if (nameProp == null)
					continue;
				var property = ComputeUniqueProperty(nameProp, type, result);
				UxmlLogger.Log($"Generating property {property.CodeName}, {property.Type}");
				result.Add(property.CodeName, property);
			}

			return result;
		}

		/// <summary>
		/// Computes a unique name.
		/// </summary>
		/// <param name="nameProp">The name property.</param>
		/// <param name="type">The type.</param>
		/// <param name="properties">The result.</param>
		/// <returns></returns>
		private static Property ComputeUniqueProperty(string nameProp, string type, Dictionary<string, Property> properties)
		{
			var result = new Property
			{
				UxmlName = nameProp.Substring("name=\"".Length, nameProp.Length - ("name=\"".Length) - ("\"".Length)),
				Type = type
			};

			result.CodeName = result.UxmlName.ToPascalCase();

			// Remove any mention of the type already existing within the name
			var usableType = type.Split('.').Last();
			var start = result.UxmlName.IndexOf(usableType, StringComparison.CurrentCultureIgnoreCase);
			if (start >= 0)
			{
				var typePart = result.UxmlName.Substring(start, usableType.Length);
				result.CodeName = result.UxmlName.Replace(typePart, "");
			}

			// Append type properly
			result.CodeName = $"{result.CodeName}{usableType}".ToPascalCase();

			// Append numbers if duplicates found
			var it = 0;
			var baseName = result.CodeName;
			while (properties.ContainsKey(result.CodeName)) result.CodeName = $"{baseName}{++it}";

			return result;
		}

		/// <summary>
		/// Encapsulates the final code.
		/// </summary>
		/// <param name="namespace"></param>
		/// <param name="classname"></param>
		/// <param name="properties"></param>
		/// <param name="ctor"></param>
		/// <returns></returns>
		private static string EncapsulateCode(string @namespace, string classname, string properties, string ctor)
		{
			return @$"
using UnityEngine;
using UnityEngine.UIElements;
namespace {@namespace} {{
	public class {classname} 
	{{
		{properties}
		{ctor}
	}}
}}";
		}

		/// <summary>
		/// Gets the constructor.
		/// </summary>
		/// <param name="classname">The class name.</param>
		/// <returns>The constructor code.</returns>
		private static string GetConstructorCode(string classname) => $@"public {classname}(VisualElement root) => _root = root;";

		/// <summary>
		/// Gets the full property code.
		/// </summary>
		/// <param name="property">The property.</param>	
		/// <returns>The property code.</returns>
		private static string GetFullPropertyCode(Property property)
		{
			UxmlLogger.Log($"Writing {property.CodeName}");
			var fieldName = $"_{property.CodeName}";

			return $@"
private {property.Type} {fieldName};
public {property.Type} {property.CodeName} => {fieldName} ??= _root.Q<{property.Type}>(""{property.UxmlName}"");";
		}

		/// <summary>
		/// Generates the properties code.
		/// </summary>
		/// <param name="properties">The parsed properties.</param>
		/// <returns>The properties code.</returns>
		private static string GeneratePropertiesCode(IDictionary<string, Property> properties)
		{
			var rootField = $@"private VisualElement _root;";
			var sb = new StringBuilder();

			foreach (var (_, property) in properties)
				sb.Append(GetFullPropertyCode(property));

			var code = sb.ToString();

			return $"{rootField}{Environment.NewLine}{code}";
		}
	}
}