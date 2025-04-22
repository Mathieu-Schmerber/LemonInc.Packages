using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// Reflection extensions.
	/// </summary>
	public static class ReflectionExtensions
	{
		/// <summary>
		/// Get a property's attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="property"></param>
		/// <param name="isRequired"></param>
		/// <returns></returns>
		public static T GetAttribute<T>(this PropertyInfo property, bool isRequired) where T : Attribute
		{
			var attribute = property.GetCustomAttributes(typeof(T), false).SingleOrDefault();

			if (attribute == null && isRequired)
			{
				throw new ArgumentException(
					string.Format(
						CultureInfo.InvariantCulture,
						"The {0} attribute must be defined on property {1}",
						typeof(T).Name,
						property.Name));
			}

			return (T)attribute;
		}

		/// <summary>
		/// Get a member's attribute
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="member"></param>
		/// <param name="isRequired"></param>
		/// <returns></returns>
		public static T GetAttribute<T>(this MemberInfo member, bool isRequired) where T : Attribute
		{
			var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

			if (attribute == null && isRequired)
			{
				throw new ArgumentException(
					string.Format(
						CultureInfo.InvariantCulture,
						"The {0} attribute must be defined on member {1}",
						typeof(T).Name,
						member.Name));
			}

			return (T)attribute;
		}

		/// <summary>
		/// Get the DisplayName attribute value of a property
		/// </summary>
		/// <param name="type"></param>
		/// <param name="propertyName"></param>
		/// <returns></returns>
		public static string GetDisplayNameByPropertyName(this Type type, string propertyName)
		{
			var property = type.GetProperty(propertyName);
			var display = property?.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;

			return display?.DisplayName;
		}

		/// <summary>
		/// Get all concrete (non-abstract, non-interface) child types of a given type,
		/// excluding specified types and their descendants, optionally restricting the search to specific assemblies.
		/// </summary>
		/// <param name="baseType">The base type to search descendants of.</param>
		/// <param name="exclusions">Types to exclude, including their subclasses.</param>
		/// <param name="assemblies">Optional assemblies to search in. If none provided, all loaded assemblies will be searched.</param>
		/// <returns>Array of matching concrete types.</returns>
		public static Type[] GetConcreteChildTypes(this Type baseType, Assembly[] assemblies = null, params Type[] exclusions)
		{
			var targetAssemblies = assemblies != null && assemblies.Length > 0
				? assemblies
				: AppDomain.CurrentDomain.GetAssemblies();

			return targetAssemblies
				.SelectMany(a =>
				{
					try
					{
						return a.GetTypes();
					}
					catch (ReflectionTypeLoadException ex)
					{
						return ex.Types.Where(t => t != null);
					}
					catch
					{
						return Enumerable.Empty<Type>();
					}
				})
				.Where(type => type != null
				               && baseType.IsAssignableFrom(type)
				               && !type.IsAbstract
				               && !type.IsInterface
				               && (exclusions == null || !exclusions.Any(ex => ex.IsAssignableFrom(type))))
				.ToArray();
		}
		
		private static readonly HashSet<string> InternalAssemblyNames = new()
		{
			"Bee.BeeDriver",
			"ExCSS.Unity",
			"Mono.Security",
			"mscorlib",
			"netstandard",
			"Newtonsoft.Json",
			"nunit.framework",
			"ReportGeneratorMerged",
			"Unrelated",
			"SyntaxTree.VisualStudio.Unity.Bridge",
			"SyntaxTree.VisualStudio.Unity.Messaging",
		};

		public static IEnumerable<Assembly> GetUserCreatedAssemblies(this AppDomain appDomain)
		{
			foreach(var assembly in appDomain.GetAssemblies())
			{
				if(assembly.IsDynamic)
				{
					continue;
				}
   
				var assemblyName = assembly.GetName().Name;
				if(assemblyName.StartsWith("System") ||
				   assemblyName.StartsWith("Unity") ||
				   assemblyName.StartsWith("UnityEditor") ||
				   assemblyName.StartsWith("UnityEngine") ||
				   assemblyName.StartsWith("JetBrains") ||
				   assemblyName.StartsWith("Sirenix") ||
				   InternalAssemblyNames.Contains(assemblyName))
				{
					continue;
				}
   
				yield return assembly;
			}
		}
	}
}