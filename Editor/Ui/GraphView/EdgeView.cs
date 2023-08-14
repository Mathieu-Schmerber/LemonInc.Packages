using System;
using UnityEditor.Experimental.GraphView;

namespace LemonInc.Editor.Utilities.Ui.GraphView
{
	/// <summary>
	/// Base <see cref="Edge"/> with events.
	/// </summary>
	/// <seealso cref="UnityEditor.Experimental.GraphView.Edge" />
	public class EdgeView : Edge
	{
		public Action<Edge> OnEdgeSelected;
		public Action<Edge> OnEdgeUnSelected;

		public override void OnSelected()
		{
			base.OnSelected();
			OnEdgeSelected?.Invoke(this);
		}

		public override void OnUnselected()
		{
			base.OnUnselected();
			OnEdgeUnSelected?.Invoke(this);
		}
	}
}