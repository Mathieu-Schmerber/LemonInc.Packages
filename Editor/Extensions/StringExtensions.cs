using System.Globalization;

namespace LemonInc.Tools.Packager.Editor.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Firsts the character to upper.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <returns></returns>
		public static string FirstCharToUpper(this string input)
		{
			var arr = input.ToCharArray();

			arr[0] = char.ToUpperInvariant(arr[0]);
			return new string(arr);
		}

		/// <summary>
		/// Converts to pascalcase.
		/// </summary>
		/// <param name="dashedCase">The dashed case.</param>
		/// <returns></returns>
		public static string ToTitleCaseFromDashed(this string dashedCase)
		{
			var textInfo = new CultureInfo("en-US", false).TextInfo;
			var words = dashedCase.Split('-');
			for (var i = 0; i < words.Length; i++)
			{
				words[i] = textInfo.ToTitleCase(words[i]);
			}
			return string.Join(" ", words);
		}
	}
}