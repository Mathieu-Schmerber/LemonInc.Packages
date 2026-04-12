using System.Linq;
using LemonInc.Core.Utilities.Editor.Extensions;
using LemonInc.Core.Utilities.Editor.Helpers;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.Toolbars;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LemonInc.Tools.SceneSwitcher.Editor
{
    public class ToolbarSceneSwitcher
    {
        [MainToolbarElement("Scene Switcher", defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement Dropdown()
        {
            var content = new MainToolbarContent("Scene Switcher", "Scene Switcher");
            return new MainToolbarDropdown(content, OpenDropdown);
        }

        private static void OpenDropdown(Rect rect)
        {
            PopupWindow.Show(rect, new SceneSwitcherPopup(GetScenes()));
        }

        private static SceneItem[] GetScenes()
        {
            var loaded = new Scene[SceneManager.sceneCount];
            for (var i = 0; i < loaded.Length; i++)
                loaded[i] = SceneManager.GetSceneAt(i);

            var externals = "Assets/Externals".ToSystemPath();
            var plugins = "Assets/Plugins".ToSystemPath();

            return SceneHelper.GetAllScenesInProject(plugins, externals)
                .Select(x => new SceneItem(x.Path, x.BuildIndex)
                {
                    Active = loaded.Any(y => y.name.Equals(x.Name))
                })
                .OrderBy(x => x.DisplayName)
                .ToArray();
        }
    }

    internal class SceneSwitcherPopup : PopupWindowContent
    {
        private const float ROW_HEIGHT = 22f;
        private const float BUTTON_WIDTH = 22f;
        private const float WIDTH = 250f;
        private const int MAX_VISIBLE = 10;

        private readonly SceneItem[] _scenes;
        private Vector2 _scroll;
        private int _hoveredIndex = -1;

        public SceneSwitcherPopup(SceneItem[] scenes) => _scenes = scenes;

        public override Vector2 GetWindowSize() =>
            new Vector2(WIDTH, Mathf.Min(_scenes.Length, MAX_VISIBLE) * ROW_HEIGHT);

        public override void OnGUI(Rect rect)
        {
            var e = Event.current;

            _scroll = GUI.BeginScrollView(rect, _scroll,
                new Rect(0, 0, WIDTH, _scenes.Length * ROW_HEIGHT),
                alwaysShowHorizontal: false, alwaysShowVertical: false);

            for (var i = 0; i < _scenes.Length; i++)
            {
                var row = new Rect(0, i * ROW_HEIGHT, WIDTH, ROW_HEIGHT);
                DrawRow(row, _scenes[i], i);
            }

            GUI.EndScrollView();

            if (e.type == EventType.MouseMove)
            {
                var mouseInContent = e.mousePosition + _scroll;
                var newHovered = (int)(mouseInContent.y / ROW_HEIGHT);
                newHovered = newHovered >= 0 && newHovered < _scenes.Length ? newHovered : -1;

                if (newHovered != _hoveredIndex)
                {
                    _hoveredIndex = newHovered;
                    editorWindow.Repaint();
                }
            }
        }

        private void DrawRow(Rect row, SceneItem scene, int index)
        {
            var buttonRect = new Rect(row.xMax - BUTTON_WIDTH, row.y + 1f, BUTTON_WIDTH, row.height - 2f);
            var labelRect = new Rect(row.x, row.y, row.width - BUTTON_WIDTH, row.height);

            if (index == _hoveredIndex)
                EditorGUI.DrawRect(row, new Color(1f, 1f, 1f, 0.07f));

            if (scene.Active)
                EditorGUI.DrawRect(row, new Color(0f, 0.5f, 1f, 0.15f));

            var prevColor = GUI.color;
            GUI.color = scene.Active ? Color.cyan : Color.white;
            if (GUI.Button(labelRect, scene.DisplayName, EditorStyles.label))
            {
                EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
                EditorSceneManager.OpenScene(scene.Path, OpenSceneMode.Single);
                editorWindow.Close();
            }
            GUI.color = prevColor;

            using (new EditorGUI.DisabledScope(scene.Active))
            {
                if (GUI.Button(buttonRect, "+"))
                {
                    EditorSceneManager.OpenScene(scene.Path, OpenSceneMode.Additive);
                    editorWindow.Close();
                }
            }
        }
    }
}