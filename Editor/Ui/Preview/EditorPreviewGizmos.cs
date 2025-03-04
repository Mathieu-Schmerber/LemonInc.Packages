using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace LemonInc.Core.Utilities.Editor.Ui.Preview
{
    public class EditorPreviewGizmos
    {
        private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");
        private static readonly int Smoothness = Shader.PropertyToID("_Smoothness");
        private static readonly int Metallic = Shader.PropertyToID("_Metallic");
        private static readonly int Surface = Shader.PropertyToID("_Surface");
        private static readonly int Blend = Shader.PropertyToID("_Blend");
        private static readonly int SrcBlend = Shader.PropertyToID("_SrcBlend");
        private static readonly int DstBlend = Shader.PropertyToID("_DstBlend");
        private static readonly int Cull = Shader.PropertyToID("_Cull");
        private readonly IEditorPreview _preview;
        private Material _gizmoMaterial;

        public EditorPreviewGizmos(IEditorPreview preview)
        {
            _preview = preview;
            InitializeGizmoMaterial();
        }

        /// <summary>
        /// Initializes the material for gizmos.
        /// </summary>
        private void InitializeGizmoMaterial()
        {
            // Determine the active render pipeline
            if (GraphicsSettings.currentRenderPipeline == null)
            {
                // Standard Render Pipeline
                _gizmoMaterial = new Material(Shader.Find("Unlit/Color"))
                {
                    enableInstancing = true
                };
            }
            else if (GraphicsSettings.currentRenderPipeline.GetType().Name.Contains("HDRenderPipeline"))
            {
                // HDRP
                _gizmoMaterial = new Material(Shader.Find("HDRP/Unlit"))
                {
                    enableInstancing = true
                };
            }
            else
            {
                // URP
                _gizmoMaterial = new Material(Shader.Find("Universal Render Pipeline/Unlit"))
                {
                    enableInstancing = true
                };
            }

            // Set default material properties
            _gizmoMaterial.SetColor(BaseColor, Color.white);
            _gizmoMaterial.SetFloat(Smoothness, 0f);
            _gizmoMaterial.SetFloat(Metallic, 0f);
            _gizmoMaterial.SetFloat(Surface, 1f); // Enable transparency
            _gizmoMaterial.SetInt(Blend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            _gizmoMaterial.SetInt(SrcBlend, (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            _gizmoMaterial.SetInt(DstBlend, (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            _gizmoMaterial.SetInt(Cull, (int)UnityEngine.Rendering.CullMode.Off);
        }
        
        /// <summary>
        /// Draws a wireframe cube in the preview.
        /// </summary>
        public void DrawWireCube(Vector3 center, Vector3 size, Color color)
        {
            var halfSize = size / 2f;
            var vertices = new[]
            {
                center + new Vector3(-halfSize.x, -halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, -halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, -halfSize.y, halfSize.z),
                center + new Vector3(-halfSize.x, -halfSize.y, halfSize.z),
                center + new Vector3(-halfSize.x, halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, halfSize.y, halfSize.z),
                center + new Vector3(-halfSize.x, halfSize.y, halfSize.z)
            };

            var indices = new[]
            {
                0, 1, 1, 2, 2, 3, 3, 0, // Bottom face
                4, 5, 5, 6, 6, 7, 7, 4, // Top face
                0, 4, 1, 5, 2, 6, 3, 7  // Vertical edges
            };

            DrawLines(vertices, indices, color);
        }
        
        /// <summary>
        /// Draws a solid cube in the preview.
        /// </summary>
        public void DrawCube(Vector3 center, Vector3 size, Color color)
        {
            var halfSize = size / 2f;
            var vertices = new[]
            {
                center + new Vector3(-halfSize.x, -halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, -halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, -halfSize.y, halfSize.z),
                center + new Vector3(-halfSize.x, -halfSize.y, halfSize.z),
                center + new Vector3(-halfSize.x, halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, halfSize.y, -halfSize.z),
                center + new Vector3(halfSize.x, halfSize.y, halfSize.z),
                center + new Vector3(-halfSize.x, halfSize.y, halfSize.z)
            };

            var indices = new[]
            {
                0, 2, 1, 0, 3, 2, // Bottom
                4, 5, 6, 4, 6, 7, // Top
                0, 1, 5, 0, 5, 4, // Front
                1, 2, 6, 1, 6, 5, // Right
                2, 3, 7, 2, 7, 6, // Back
                3, 0, 4, 3, 4, 7  // Left
            };

            var mesh = new Mesh
            {
                vertices = vertices
            };

            mesh.SetIndices(indices, MeshTopology.Triangles, 0);

            var material = new Material(_gizmoMaterial);
            material.SetColor(BaseColor, color);
            _preview.DrawMesh(mesh, Matrix4x4.identity, material, 0);
        }
        
        /// <summary>
        /// Draws a wireframe sphere in the preview.
        /// </summary>
        public void DrawWireSphere(Vector3 center, float radius, Color color, int segments = 64)
        {
            var vertices = new List<Vector3>();
            var indices = new List<int>();

            // Create circles around each axis
            CreateCircle(vertices, indices, center, radius, Vector3.right, Vector3.up, segments);
            CreateCircle(vertices, indices, center, radius, Vector3.up, Vector3.forward, segments);
            CreateCircle(vertices, indices, center, radius, Vector3.forward, Vector3.right, segments);

            DrawLines(vertices.ToArray(), indices.ToArray(), color);
        }

        /// <summary>
        /// Draws a line between two points in the preview.
        /// </summary>
        public void DrawLine(Vector3 start, Vector3 end, Color color)
        {
            var vertices = new[] { start, end };
            var indices = new[] { 0, 1 };
            DrawLines(vertices, indices, color);
        }

        /// <summary>
        /// Draws a set of lines in the preview.
        /// </summary>
        private void DrawLines(Vector3[] vertices, int[] indices, Color color)
        {
            var mesh = new Mesh
            {
                vertices = vertices
            };
            
            mesh.SetIndices(indices, MeshTopology.Lines, 0);

            var material = new Material(_gizmoMaterial);
            material.SetColor(BaseColor, color);
            _preview.DrawMesh(mesh, Matrix4x4.identity, material, 0);
        }

        /// <summary>
        /// Helper method to create a circle for wireframe sphere.
        /// </summary>
        private void CreateCircle(List<Vector3> vertices, List<int> indices, Vector3 center, float radius, Vector3 axis1, Vector3 axis2, int segments)
        {
            var startIndex = vertices.Count;
            for (var i = 0; i < segments; i++)
            {
                var angle = i * Mathf.PI * 2f / segments;
                var point = center + (axis1 * Mathf.Cos(angle) + (axis2 * Mathf.Sin(angle))) * radius;
                vertices.Add(point);

                if (i > 0)
                {
                    indices.Add(startIndex + i - 1);
                    indices.Add(startIndex + i);
                }
            }

            // Close the circle
            indices.Add(startIndex + segments - 1);
            indices.Add(startIndex);
        }
        
        /// <summary>
        /// Draws a grid in the preview.
        /// </summary>
        /// <param name="center">The center of the grid.</param>
        /// <param name="size">The total size of the grid (width and length).</param>
        /// <param name="cellSize">The size of each grid cell.</param>
        /// <param name="color">The color of the grid lines.</param>
        public void DrawGrid(Vector3 center, Vector2 size, Vector2 cellSize, Color color)
        {
            var halfSize = size / 2f;
            var vertices = new List<Vector3>();
            var indices = new List<int>();

            // Calculate the number of lines in each direction
            var xLines = Mathf.CeilToInt(size.x / cellSize.x);
            var zLines = Mathf.CeilToInt(size.y / cellSize.y);

            // Generate horizontal lines (along the X-axis)
            for (var i = 0; i <= xLines; i++)
            {
                var x = center.x - halfSize.x + i * cellSize.x;
                var zStart = center.z - halfSize.y;
                var zEnd = center.z + halfSize.y;

                vertices.Add(new Vector3(x, center.y, zStart));
                vertices.Add(new Vector3(x, center.y, zEnd));

                indices.Add(vertices.Count - 2);
                indices.Add(vertices.Count - 1);
            }

            // Generate vertical lines (along the Z-axis)
            for (var i = 0; i <= zLines; i++)
            {
                var z = center.z - halfSize.y + i * cellSize.y;
                var xStart = center.x - halfSize.x;
                var xEnd = center.x + halfSize.x;

                vertices.Add(new Vector3(xStart, center.y, z));
                vertices.Add(new Vector3(xEnd, center.y, z));

                indices.Add(vertices.Count - 2);
                indices.Add(vertices.Count - 1);
            }

            // Draw the grid lines
            DrawLines(vertices.ToArray(), indices.ToArray(), color);
        }
    }
}