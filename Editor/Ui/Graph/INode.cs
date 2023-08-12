using System;
using UnityEngine;

namespace LemonInc.Editor.Utilities.Ui.Graph
{
	public interface INode
	{
		public string Id { get; }
		public string Alias { get; set; }
		public Vector2 Position { get; set; }
	}
}
