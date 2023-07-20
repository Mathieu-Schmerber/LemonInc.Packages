using LemonInc.Tools.Panels.Models;
using UnityEditor;

namespace LemonInc.Tools.Panels.Interfaces
{
	/// <summary>
	/// Describes a panel.
	/// </summary>
	public interface IPanel
	{
		/// <summary>
		/// Initializes with the specified name.
		/// </summary>
		/// <param name="name">The name.</param>
		public void Init(string name);
	}
}