
				using UnityEditor;
				using UnityEngine;
				namespace LemonInc.Generated {
			        internal static class PanelMenuItems
			        {
			            
		        [MenuItem("Tools/LemonInc/Panels/LemonInc Panel")]
		        public static void OpenLemonIncPanel()
		        {
		            var window = UnityEditor.EditorWindow.CreateWindow<LemonInc.Tools.Panels.PanelEditorWindow>();
		            window.titleContent = new GUIContent("LemonInc Panel");
					window.Init("LemonInc Panel");
		            window.Show();
		            window.Focus();
		        }
		        
			        }
			    }