using LemonInc.Core.Utilities.Editor.Ui.Preview;
using LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Test
{
    [CustomEditor(typeof(TestSo))]
    public class TestSoEditor : UnityEditor.Editor
    {
        private SimpleEditorPreview _preview;

        private void OnEnable()
        {
            var data = target as TestSo;
            if (data == null)
                return;
            
            _preview = new SimpleEditorPreview();
            _preview.InitializePreview();
            
            _preview.Camera.transform.position = new Vector3(0, 0, 10);
            if (data.Prefab == null)
                return;
            
            _preview.SpawnObject(data.Prefab, (instance) =>
            {
                _preview.Camera.transform.LookAt(instance.transform);
            });

            _preview.CameraBackgroundColor = Color.black;
            _preview.UseInputHandler<ZoomOnScrollHandle>();
            _preview.UseInputHandler<OrbitHandle>();
        }

        private void OnDisable()
        {
            _preview?.Dispose();
        }

        public override void OnInspectorGUI()
        {
            if (_preview == null)
                return;
            base.OnInspectorGUI();
            
            Repaint();
            
            var rect = EditorGUILayout.GetControlRect(GUILayout.Width(500), GUILayout.Height(250));
            _preview.RenderPreview(rect);
            _preview.Gizmos.DrawGrid(Vector3.zero, Vector2.one * 100, Vector2.one, Color.white);
            _preview.Gizmos.DrawWireSphere(Vector3.zero, 1.5f, Color.red);
        }
    }
}