
				using System.Collections.Generic;
				using LemonInc.Tools.Panels.Models;
				using UnityEditor;
				using UnityEngine;
				namespace LemonInc.Generated {
			        internal static class PanelMenuItems
			        {
			            
		        [MenuItem("Tools/LemonInc/Panels/GD")]
		        public static void OpenGd()
		        {
		            var window = UnityEditor.EditorWindow.CreateWindow<LemonInc.Tools.Panels.PanelEditorWindow>();
		            
					window.titleContent = new GUIContent("GD");
					window.Init("GD");
		            window.Show();
		            window.Focus();
		        }
		        
			        }
			    }