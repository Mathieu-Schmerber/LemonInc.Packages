using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace LemonInc.Editor.Utilities.Ui.GraphView.Node
{
	/// <summary>
	/// <see cref="Edge"/> for <see cref="GraphNodeView{T}"/>.
	/// </summary>
	/// <seealso cref="UnityEditor.Experimental.GraphView" />
	public class GraphNodeEdge : EdgeView
	{
		protected override EdgeControl CreateEdgeControl() => new GraphNodeEdgeControl(this);
		
        private readonly Image _flowImg;

        private const int ARROW_SIZE = 10;
        private const string TRIANGLE_PATH = "Editor/Ui/GraphView/Resources/triangle.png";

        public GraphNodeEdge()
        {
	        var triangle = AssetDatabase.LoadAssetAtPath<Sprite>($"Packages/com.lemon-inc.editor.utilities/{TRIANGLE_PATH}") ??
	                       AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/LemonInc/Editor/Utilities/{TRIANGLE_PATH}");

			_flowImg = new Image
            {
                name = "flow-image",
                style =
	            {
	                width = new Length(ARROW_SIZE, LengthUnit.Pixel),
	                height = new Length(ARROW_SIZE, LengthUnit.Pixel),
					backgroundImage = new StyleBackground(triangle)
	            },
            };

            Add(_flowImg);
        }

        public override bool UpdateEdgeControl()
        {
	        if (!base.UpdateEdgeControl())
		        return false;

	        UpdateFlow();
	        return true;
        }

        public void UpdateFlow()
        {
	        var progress = 0.5f;

			// Position
			_flowImg.transform.position = Vector2.Lerp(edgeControl.controlPoints[2], edgeControl.controlPoints[1], progress) - new Vector2(ARROW_SIZE/2f, ARROW_SIZE/2f);

			// Rotation
			var dir = (edgeControl.controlPoints[^1] - edgeControl.controlPoints[0]).normalized;
			var angle = Vector2.SignedAngle(Vector2.up, dir);
			_flowImg.style.rotate = new StyleRotate(new Rotate(Angle.Degrees(angle)));

			// Color
			_flowImg.style.unityBackgroundImageTintColor = Color.Lerp(edgeControl.inputColor, edgeControl.outputColor, progress);
        }
	}
}