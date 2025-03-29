using UnityEngine;

namespace LemonInc.Core.Utilities.Singletons
{
	/// <summary>
	/// Defines a Singleton. <br/>
	/// This Singleton will NOT create a new object if it does not exist and is bound to its scene.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class SceneSingleton<T> : MonoBehaviour where T : Component
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
		public static T Instance
		{
			get
			{
				if (_instance == null)
					_instance = GameObject.FindObjectOfType<T>(includeInactive: false);
				return _instance;
			}
		}
	}
}