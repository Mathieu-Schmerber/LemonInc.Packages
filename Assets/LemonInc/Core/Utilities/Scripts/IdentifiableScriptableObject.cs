using System;
using Sirenix.OdinInspector;

namespace LemonInc.Core.Utilities
{
	/// <summary>
	/// Provides a ScriptableObject with a unique Id
	/// </summary>
	public abstract class IdentifiableScriptableObject : SerializedScriptableObject
	{
		/// <summary>
		/// The identifier.
		/// </summary>
		[ReadOnly] public string Id = string.Empty;

		/// <summary>
		/// On create/compile
		/// </summary>
		protected virtual void OnValidate()
		{
			if (string.IsNullOrEmpty(Id))
				GenerateID();
		}

#if UNITY_EDITOR
		[Button, ShowIf("@string.IsNullOrEmpty(Id)")]
		private void GenerateID() => Id = Guid.NewGuid().ToString();
#endif
	}
}
