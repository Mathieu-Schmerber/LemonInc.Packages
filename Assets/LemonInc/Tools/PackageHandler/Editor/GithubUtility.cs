using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using System.Linq;
using UnityEngine;
using Newtonsoft.Json;

namespace LemonInc.Tools.PackageHandler
{
	/// <summary>
	/// Github utility.
	/// </summary>
	public static class GithubUtility
	{
		/// <summary>
		/// The base URL.
		/// </summary>
		private const string BASE_URL = "https://api.github.com/";

		/// <summary>
		/// The mozilla header.
		/// </summary>
		private const string MOZILLA_HEADER = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; Trident/6.0)";

		/// <summary>
		/// Lists the repository branches.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="repository">The repository.</param>
		/// <returns>A list of branches.</returns>
		public static async Task<IEnumerable<string>> ListRepositoryBranches(string owner, string repository)
		{
			IEnumerable<string> branches = null;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(BASE_URL);
				client.DefaultRequestHeaders.UserAgent.ParseAdd(MOZILLA_HEADER);
				
				var response = await client.GetAsync($"repos/{owner}/{repository}/branches");

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var branchData = JsonConvert.DeserializeObject<IEnumerable<Branch>>(content);

					if (branchData != null)
					{
						branches = branchData.Select(branch => branch.name);
					}
				}
				else
				{
					Debug.LogError($"Failed to retrieve branches: {response.StatusCode}");
				}
			}

			return branches ?? Enumerable.Empty<string>();
		}

		/// <summary>
		/// The git branch.
		/// </summary>
		private class Branch
		{
			public string name { get; set; }
		}
	}
}