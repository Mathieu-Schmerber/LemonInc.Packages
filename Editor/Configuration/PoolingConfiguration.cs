using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using FilePathAttribute = UnityEditor.FilePathAttribute;

namespace LemonInc.Core.Pooling.Editor.Configuration
{
	/// <summary>
	/// Pooling configuration.
	/// </summary>
	[UnityEditor.FilePath("Plugins/LemonInc/Resources/Pooling/PoolingConfiguration.asset", FilePathAttribute.Location.ProjectFolder)]
	public class PoolingConfiguration : ScriptableSingleton<PoolingConfiguration>
	{
		/// <summary>
		/// Describes the pool creator form state.
		/// </summary>
		[Serializable]
		public struct PoolCreatorForm
		{
			public GameObject Prefab;
			public int InitialCount;
			public string Key;
			public bool AutoGenerateOnCreate;

			/// <summary>
			/// Initializes a new instance of the <see cref="PoolCreatorForm"/> class.
			/// </summary>
			/// <param name="prefab">The prefab.</param>
			/// <param name="initialCount">The initial count.</param>
			/// <param name="key">The key.</param>
			/// <param name="autoGenerateOnCreate">if set to <c>true</c> [automatic generate on create].</param>
			public PoolCreatorForm(GameObject prefab, int initialCount, string key, bool autoGenerateOnCreate)
			{
				Prefab = prefab;
				InitialCount = initialCount;
				Key = key;
				AutoGenerateOnCreate = autoGenerateOnCreate;
			}
		}

		/// <summary>
		/// Gets or sets the last state of the form.
		/// </summary>
		/// <value>
		/// The last state of the form.
		/// </value>
		[SerializeField, ReadOnly] public PoolCreatorForm LastFormState;
	}
}
