using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview
{
    public interface IEditorPreview : IDisposable
    {
        /// <summary>
        /// Should a skybox be used ?
        /// </summary>
        public bool UseSkybox { get; set; }
        public Material SkyboxMaterial { get; set; }
        
        /// <summary>
        /// Gets or sets the camera background color.
        /// If null, uses a skybox.
        /// </summary>
        public Color CameraBackgroundColor { get; set; }
        
        /// <summary>
        /// Does the preview need a repaint.
        /// </summary>
        public bool NeedsRepaint { get; set; }
        
        /// <summary>
        /// The preview camera.
        /// </summary>
        public Camera Camera { get; }
        
        /// <summary>
        /// The lights.
        /// </summary>
        public Light[] Lights { get; }
        
        /// <summary>
        /// The gizmos.
        /// </summary>
        public EditorPreviewGizmos Gizmos { get; }
        
        /// <summary>
        /// Initializes the preview.
        /// </summary>
        public void InitializePreview();
        
        /// <summary>
        /// Draws the preview texture.
        /// </summary>
        /// <param name="previewRect">The area where the texture will fit.</param>
        public void RenderPreview(Rect previewRect);
        
        /// <summary>
        /// Spawns an object within the preview scene.
        /// </summary>
        /// <param name="prefab">The prefab to instantiate.</param>
        /// <param name="callback">The instantiation callback.</param>
        public void SpawnObject(GameObject prefab, Action<GameObject> callback = null);
        
        /// <summary>
        /// Draws a mesh within the preview scene.
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="identity"></param>
        /// <param name="material"></param>
        /// <param name="i"></param>
        internal void DrawMesh(Mesh mesh, Matrix4x4 identity, Material material, int i);
    }
}