
				using UnityEditor;
				using UnityEngine;
				namespace LemonInc.Generated {
			        internal static class PanelMenuItems
			        {
			            
		        [MenuItem("Tools/LemonInc/Panels/Game design")]
		        public static void OpenGameDesign()
		        {
		            var window = UnityEditor.EditorWindow.CreateWindow<LemonInc.Tools.Panels.PanelEditorWindow>();
		            window.titleContent = new GUIContent("Game design");
					window.Init("Game design");
		            window.Show();
		            window.Focus();
		        }
		        
			        }
			    }