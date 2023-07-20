using System.Collections.Generic;
using System.IO;
using System.Text;
using LemonInc.Core.Utilities.Extensions;
using LemonInc.Tools.Panels.Models;
using UnityEditor;

namespace LemonInc.Tools.Panels
{
	/// <summary>
	/// Panel generator.
	/// </summary>
	public static class PanelCodeGenerator
	{
		/// <summary>
		/// The namespace.
		/// </summary>
		private const string NAMESPACE = "LemonInc.Generated";

		/// <summary>
		/// The class name.
		/// </summary>
		private const string CLASS_NAME = "PanelMenuItems";

		/// <summary>
		/// Generates the script.
		/// </summary>
		/// <param name="panels">The panels.</param>
		/// <param name="outputPath">The output path.</param>
		/// <param name="generateFolders">if set to <c>true</c> [generate folders].</param>
		public static void GenerateScript(IDictionary<string, PanelDefinition> panels, string outputPath, bool generateFolders = true)
		{
			var builder = new StringBuilder();

			foreach (var (panelName, panelDefinition) in panels)
			{
				var methodCode = GenerateMethodCode(panelName);
				builder.Append(methodCode);
			}
			
			var code = ComputeFinalCode(builder.ToString());

			if (generateFolders)
			{
				var directory = Path.GetDirectoryName(outputPath);
				Directory.CreateDirectory(directory);
			}
			
			File.WriteAllText(outputPath, code);
			AssetDatabase.Refresh();
		}

		/// <summary>
		/// Compute file code.
		/// </summary>
		/// <param name="currentCode"></param>
		private static string ComputeFinalCode(string currentCode)
		{
			var newClassCode = $@"
				using UnityEditor;
				using UnityEngine;
				namespace {NAMESPACE} {{
			        internal static class {CLASS_NAME}
			        {{
			            {currentCode}
			        }}
			    }}";

			return newClassCode;
		}

		/// <summary>
		/// Generates the method code.
		/// </summary>
		/// <param name="panelName"></param>
		private static string GenerateMethodCode(string panelName)
		{
			var pascalName = panelName.ToPascalCase();
			var methodName = $"Open{pascalName}";

			return $@"
		        [MenuItem(""Tools/LemonInc/Panels/{panelName}"")]
		        public static void {methodName}()
		        {{
		            var window = UnityEditor.EditorWindow.CreateWindow<{typeof(PanelEditorWindow).FullName}>();
		            window.titleContent = new GUIContent(""{panelName}"");
					window.Init(""{panelName}"");
		            window.Show();
		            window.Focus();
		        }}
		        ";
		}
	}
}