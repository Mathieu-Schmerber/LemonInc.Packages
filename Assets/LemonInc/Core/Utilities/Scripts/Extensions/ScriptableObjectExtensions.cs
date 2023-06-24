using UnityEngine;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// Extensions for <see cref="ScriptableObject"/>.
	/// </summary>
	public static class ScriptableObjectExtensions
	{
        /// <summary>
        /// Creates a clone of the given <see cref="ScriptableObject"/>.
        /// </summary>
        /// <param name="scriptableObject">The <see cref="ScriptableObject"/> to clone.</param>
        /// <returns>The clone.</returns>
        public static T Clone<T>(this T scriptableObject) where T : ScriptableObject
        {
            if (scriptableObject == null)
            {
                Debug.LogError($"ScriptableObject was null. Returning default {typeof(T)} object.");
                return (T)ScriptableObject.CreateInstance(typeof(T));
            }

            var instance = Object.Instantiate(scriptableObject);
            instance.name = scriptableObject.name; // remove (Clone) from name
            return instance;
        }
    }
}