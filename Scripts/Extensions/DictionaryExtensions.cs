using System;
using System.Collections.Generic;

namespace LemonInc.Core.Utilities.Extensions
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the value associated with the specified key, or adds a new value if the key doesn't exist.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary key</typeparam>
        /// <typeparam name="TValue">The type of the dictionary value</typeparam>
        /// <param name="dictionary">The dictionary to operate on</param>
        /// <param name="key">The key to look up or add</param>
        /// <param name="value">The value to add if the key doesn't exist</param>
        /// <returns>The existing value if key exists, otherwise the newly added value</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));

            if (dictionary.TryGetValue(key, out var existingValue))
                return existingValue;

            dictionary[key] = value;
            return value;
        }

        /// <summary>
        /// Gets the value associated with the specified key, or adds a new value using the provided factory function.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary key</typeparam>
        /// <typeparam name="TValue">The type of the dictionary value</typeparam>
        /// <param name="dictionary">The dictionary to operate on</param>
        /// <param name="key">The key to look up or add</param>
        /// <param name="valueFactory">A function that creates the value if the key doesn't exist</param>
        /// <returns>The existing value if key exists, otherwise the newly created and added value</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            if (valueFactory == null)
                throw new ArgumentNullException(nameof(valueFactory));

            if (dictionary.TryGetValue(key, out var existingValue))
                return existingValue;

            var newValue = valueFactory();
            dictionary[key] = newValue;
            return newValue;
        }

        /// <summary>
        /// Gets the value associated with the specified key, or adds a new value using the provided factory function that takes the key as parameter.
        /// </summary>
        /// <typeparam name="TKey">The type of the dictionary key</typeparam>
        /// <typeparam name="TValue">The type of the dictionary value</typeparam>
        /// <param name="dictionary">The dictionary to operate on</param>
        /// <param name="key">The key to look up or add</param>
        /// <param name="valueFactory">A function that creates the value using the key if the key doesn't exist</param>
        /// <returns>The existing value if key exists, otherwise the newly created and added value</returns>
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
        {
            if (dictionary == null)
                throw new ArgumentNullException(nameof(dictionary));
            if (valueFactory == null)
                throw new ArgumentNullException(nameof(valueFactory));

            if (dictionary.TryGetValue(key, out var existingValue))
                return existingValue;

            var newValue = valueFactory(key);
            dictionary[key] = newValue;
            return newValue;
        }
    }
}