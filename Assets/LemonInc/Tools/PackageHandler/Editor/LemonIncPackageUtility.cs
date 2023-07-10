using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace LemonInc.Tools.PackageHandler
{
	/// <summary>
	/// Package manager utility.
	/// </summary>
	public static class LemonIncPackageUtility
	{
		/// <summary>
		/// The github URL.
		/// </summary>
		private const string GITHUB_URL = "https://github.com/Mathieu-Schmerber/LemonInc.Packages.git";
		
		/// <summary>
		/// Converts to lemon inc package name.
		/// </summary>
		/// <param name="packageName">Name of the package.</param>
		/// <returns></returns>
		public static string ToLemonIncPackageName(this string packageName) => $"com.lemon-inc.{packageName}";

		/// <summary>
		/// Determines whether the given name is a valid  package name.
		/// </summary>
		/// <param name="packageName">Name of the package.</param>
		public static bool IsValidPackageName(string packageName) => packageName.Contains(".");

		/// <summary>
		/// Gets the installed packages.
		/// </summary>
		public static async Task<IEnumerable<PackageInfo>> GetInstalledPackages()
		{
			var packages = Client.List();

			while (!packages.IsCompleted)
				await Task.Yield();

			return packages.Result;
		}

		/// <summary>
		/// Installs a git package.
		/// </summary>
		/// <param name="package">The package.</param>
		public static IEnumerator InstallPackage(LemonIncPackage package)
		{
			var url = $"{GITHUB_URL}#{package.Name}";

			Debug.Log($"Installing '{url}' ...");

			var request = Client.Add(url);
			yield return new WaitUntil(() => request.IsCompleted);

			package.Installed = request.Status == StatusCode.Success;
			Debug.Log($"Package install request for '{package.FullName}': {request.Status}, {request.Error.message}");
		}

		/// <summary>
		/// Updates the package.
		/// </summary>
		/// <param name="package">The package.</param>
		public static IEnumerator UpdatePackage(LemonIncPackage package)
		{
			yield return InstallPackage(package);
		}

		/// <summary>
		/// Removes the package.
		/// </summary>
		/// <param name="package">The package.</param>
		public static IEnumerator RemovePackage(LemonIncPackage package)
		{
			Debug.Log($"Removing {package.FullName}...");

			var request = Client.Remove(package.FullName);
			yield return new WaitUntil(() => request.IsCompleted);

			package.Installed = request.Status != StatusCode.Success;
			Debug.Log($"Package remove request for '{package.FullName}': {request.Status}");
		}
	}
}