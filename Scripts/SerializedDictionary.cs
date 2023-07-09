using System.Collections.Generic;
using UnityEngine;

namespace LemonInc.Core.Utilities
{
	/// <summary>
	/// Implements an In-Editor dictionary serialization
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	public abstract class SerializedDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
	{
		/// <summary>
		/// The key data.
		/// </summary>
		[SerializeField, HideInInspector]
		private List<TKey> _keyData = new();

		/// <summary>
		/// The value data.
		/// </summary>
		[SerializeField, HideInInspector]
		private List<TValue> _valueData = new();

		/// <summary>
		/// Implement this method to receive a callback after Unity deserializes your object.
		/// </summary>
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			this.Clear();
			for (int i = 0; i < this._keyData.Count && i < this._valueData.Count; i++)
			{
				this[this._keyData[i]] = this._valueData[i];
			}
		}

		/// <summary>
		/// Implement this method to receive a callback before Unity serializes your object.
		/// </summary>
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			_keyData.Clear();
			_valueData.Clear();

			foreach (var item in this)
			{
				_keyData.Add(item.Key);
				_valueData.Add(item.Value);
			}
		}
	}
}