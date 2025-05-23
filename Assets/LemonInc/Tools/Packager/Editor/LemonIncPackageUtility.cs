﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace LemonInc.Tools.Packager.Editor
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
		/// <param name="packageName">BranchName of the package.</param>
		/// <returns></returns>
		public static string ToLemonIncPackageName(this string packageName) => $"com.lemon-inc.{packageName}";

		/// <summary>
		/// Determines whether the given name is a valid  package name.
		/// </summary>
		/// <param name="packageName">BranchName of the package.</param>
		public static bool IsValidPackageName(string packageName) => packageName.Contains(".");

		/// <summary>
		/// Gets the installed packages.
		/// </summary>
		public static async Task<IEnumerable<PackageInfo>> GetInstalledPackages()
		{
			var packages = Client.List();

			Debug.Log($"Fetching packages...");
			while (!packages.IsCompleted)
				await Task.Yield();

			Debug.Log($"Done fetching !");
			return packages.Result;
		}

		/// <summary>
		/// Installs a git package.
		/// </summary>
		/// <param name="package">The package.</param>
		public static IEnumerator InstallPackage(LemonIncPackage package, Action<bool> then = null)
		{
			var url = $"{GITHUB_URL}#{package.BranchName}";

			Debug.Log($"Installing '{url}' ...");

			var request = Client.Add(url);
			yield return new WaitUntil(() => request.IsCompleted);

			package.Installed = request.Status == StatusCode.Success;
			then?.Invoke(request.Status == StatusCode.Success);
		}

		/// <summary>
		/// Removes the package.
		/// </summary>
		/// <param name="package">The package.</param>
		public static IEnumerator RemovePackage(LemonIncPackage package, Action<bool> then = null)
		{
			Debug.Log($"Removing {package.FullName}...");

			var request = Client.Remove(package.FullName);
			yield return new WaitUntil(() => request.IsCompleted);

			package.Installed = request.Status != StatusCode.Success;
			then?.Invoke(request.Status == StatusCode.Success);
		}
		
		/// <summary>
		/// Installs multiple git packages sequentially.
		/// </summary>
		/// <param name="packages">List of packages to install.</param>
		/// <param name="then">Callback with a list of install results (true = success).</param>
		public static IEnumerator BatchInstall(IEnumerable<LemonIncPackage> packages, Action<List<bool>> then = null)
		{
			var results = new List<bool>();

			foreach (var package in packages)
			{
				bool result = false;
				yield return InstallPackage(package, success => result = success);
				results.Add(result);
			}

			then?.Invoke(results);
		}

		/// <summary>
		/// Removes multiple packages sequentially.
		/// </summary>
		/// <param name="packages">List of packages to remove.</param>
		/// <param name="then">Callback with a list of removal results (true = success).</param>
		public static IEnumerator BatchRemove(IEnumerable<LemonIncPackage> packages, Action<List<bool>> then = null)
		{
			var results = new List<bool>();

			foreach (var package in packages)
			{
				bool result = false;
				yield return RemovePackage(package, success => result = success);
				results.Add(result);
			}

			then?.Invoke(results);
		}
	}
}