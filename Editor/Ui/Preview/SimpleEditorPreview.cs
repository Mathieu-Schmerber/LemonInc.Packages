using System;
using System.Collections.Generic;
using LemonInc.Core.Utilities.Editor.Ui.Preview.InputHandle;
using UnityEditor;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview
{
    public class SimpleEditorPreview : IEditorPreview
    {
        // Settings
        
        /// <inheritdoc/>
        public bool UseSkybox { get; set; } = true;
        
        /// <inheritdoc/>
        public Color? CameraBackgroundColor { get; set; } = null;

        // Controls
        public bool NeedsRepaint { get; set; }

        // Accesses
        
        /// <inheritdoc/>
        public Camera Camera => _initialized ? _previewUtility.camera : throw new InvalidOperationException("Preview has not been initialized.");
        
        /// <inheritdoc/>
        public Light[] Lights => _initialized ? _previewUtility.lights : throw new InvalidOperationException("Preview has not been initialized.");
         
        /// <inheritdoc/>
        public EditorPreviewGizmos Gizmos { get; private set; }
        
        // private fields
        private readonly PreviewRenderUtility _previewUtility = new();
        private bool _initialized;
        private bool _disposed;
        private Texture _previewTexture;
        private List<IEventHandleStrategy> _inputHandleStrategies = new();

        public SimpleEditorPreview()
        {
            Gizmos = new EditorPreviewGizmos(this);
        }

        ~SimpleEditorPreview()
        {
            if (!_disposed)
            {
                Debug.LogError("SimpleEditorPreview was not disposed before being destroyed. Call Dispose() to clean up resources.");
                Dispose();
            }
        }
        
        public void Dispose()
        {
            if (_disposed)
                return;

            if (_initialized)
            {
                _previewUtility.Cleanup();
                _initialized = false;
            }

            _inputHandleStrategies.ForEach(x => x.Dispose());
            _inputHandleStrategies.Clear();
            _disposed = true;
            GC.SuppressFinalize(this);
        }
        
        public void InitializePreview()
        {
            if (_initialized)
                return;

            _previewUtility.camera.fieldOfView = 60f;
            _previewUtility.camera.nearClipPlane = 0.01f;
            _previewUtility.camera.farClipPlane = 1000f;
            _previewUtility.lights[0].intensity = 1.5f;
            _previewUtility.lights[0].transform.rotation = Quaternion.Euler(30f, 180f, 0f);
            
            _initialized = true;
        }

        public T UseInputHandler<T>()
            where T : class, IEventHandleStrategy, new()
        {
            var result = new T();
            _inputHandleStrategies.Add(result);
            result.Active = true;
            return result;
        }
        
        public void UseInputHandler(EventType eventType, IEventHandleStrategy strategy)
        {
            _inputHandleStrategies.Add(strategy);
            strategy.Active = true;
        }

        public void RemoveInputHandler<T>() => _inputHandleStrategies.RemoveAll(s => s is T);
        public void RemoveInputHandler(Type type) => _inputHandleStrategies.RemoveAll(s => s.GetType() == type);
        
        public void RenderPreview(Rect previewRect)
        {
            if (!_initialized)
            {
                Debug.LogWarning("Preview has not been initialized. Call InitializePreview() first.");
                return;
            }

            if (previewRect.width <= 0)
                return;

            NeedsRepaint = false;
            _previewUtility.BeginPreview(previewRect, GUIStyle.none);

            foreach (var strategy in _inputHandleStrategies)
            {
                if (strategy.ConsumeEvent(this, Event.current))
                    break;
            }
            
            if (CameraBackgroundColor != null)
            {
                _previewUtility.camera.clearFlags = CameraClearFlags.SolidColor;
                _previewUtility.camera.backgroundColor = CameraBackgroundColor.Value;
            }
            else
            {
                _previewUtility.camera.clearFlags = CameraClearFlags.Skybox;
                _previewUtility.camera.Render();
            }

            _previewUtility.camera.aspect = previewRect.width / previewRect.height;
            _previewUtility.Render(true);
            _previewTexture = _previewUtility.EndPreview();

            GUI.DrawTexture(previewRect, _previewTexture, ScaleMode.ScaleToFit, false);
        }

        public void SpawnObject(GameObject prefab, Action<GameObject> callback = null)
        {
            if (!_initialized)
            {
                Debug.LogWarning("Preview has not been initialized. Call InitializePreview() first.");
                return;
            }

            var instance = _previewUtility.InstantiatePrefabInScene(prefab);
            callback?.Invoke(instance);
        }

        void IEditorPreview.DrawMesh(Mesh mesh, Matrix4x4 identity, Material material, int i)
        {
            if (!_initialized)
            {
                Debug.LogWarning("Preview has not been initialized. Call InitializePreview() first.");
                return;
            }

            _previewUtility.DrawMesh(mesh, identity, material, i);
        }
    }
}