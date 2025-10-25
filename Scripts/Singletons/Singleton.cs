using System;
using UnityEngine;

namespace LemonInc.Core.Utilities.Singletons
{
	/// <summary>
	/// Default singleton pattern.
	/// </summary>
	public abstract class Singleton<T>
	{
		/// <summary>
		/// The instance.
		/// </summary>
		private static T _instance;

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static T Instance => _instance ??= (T)Activator.CreateInstance(typeof(T));

		/// <summary>
		/// Initializes a new instance of the <see cref="Singleton{T}"/> class.
		/// </summary>
		protected Singleton() 
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
#endif
		}

#if UNITY_EDITOR
		/// <summary>
		/// Resets the singleton instance when exiting play mode to prevent stale references.
		/// </summary>
		private static void OnPlayModeStateChanged(UnityEditor.PlayModeStateChange state)
		{
			if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode)
			{
				_instance = default;
			}
		}
#endif
	}
}