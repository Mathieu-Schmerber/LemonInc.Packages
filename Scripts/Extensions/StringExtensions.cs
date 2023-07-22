using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LemonInc.Core.Utilities.Extensions
{
	/// <summary>
	/// String extensions.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Capitalizes the specified string.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <returns>The capitalized string.</returns>
		public static string ToCapitalized(this string str)
		{
			if (string.IsNullOrEmpty(str))
				return str;

			return char.ToUpper(str[0]) + str.Substring(1);
		}

		/// <summary>
		/// Convert string to snake_case format
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public static string ToSnakeCase(this string text)
		{
			if (string.IsNullOrEmpty(text))
				return text;

			var builder = new StringBuilder(text.Length + Math.Min(2, text.Length / 5));
			var previousCategory = default(UnicodeCategory?);

			for (var currentIndex = 0; currentIndex < text.Length; currentIndex++)
			{
				var currentChar = text[currentIndex];
				if (currentChar == '_')
				{
					builder.Append('_');
					previousCategory = null;
					continue;
				}

				var currentCategory = char.GetUnicodeCategory(currentChar);
				switch (currentCategory)
				{
					case UnicodeCategory.UppercaseLetter:
					case UnicodeCategory.TitlecaseLetter:
						if (previousCategory == UnicodeCategory.SpaceSeparator ||
							previousCategory == UnicodeCategory.LowercaseLetter ||
							previousCategory != UnicodeCategory.DecimalDigitNumber &&
							previousCategory != null &&
							currentIndex > 0 &&
							currentIndex + 1 < text.Length &&
							char.IsLower(text[currentIndex + 1]))
						{
							builder.Append('_');
						}

						currentChar = char.ToLower(currentChar, CultureInfo.InvariantCulture);
						break;

					case UnicodeCategory.LowercaseLetter:
					case UnicodeCategory.DecimalDigitNumber:
						if (previousCategory == UnicodeCategory.SpaceSeparator)
						{
							builder.Append('_');
						}
						break;

					default:
						if (previousCategory != null)
						{
							previousCategory = UnicodeCategory.SpaceSeparator;
						}
						continue;
				}

				builder.Append(currentChar);
				previousCategory = currentCategory;
			}

			return builder.ToString();
		}

		/// <summary>
		/// Converts to pascalcase.
		/// </summary>
		/// <param name="original">The original.</param>
		/// <returns></returns>
		public static string ToPascalCase(this string original)
		{
			var invalidCharsRgx = new Regex("[^_a-zA-Z0-9]");
			var whiteSpace = new Regex(@"(?<=\s)");
			var startsWithLowerCaseChar = new Regex("^[a-z]");
			var firstCharFollowedByUpperCasesOnly = new Regex("(?<=[A-Z])[A-Z0-9]+$");
			var lowerCaseNextToNumber = new Regex("(?<=[0-9])[a-z]");
			var upperCaseInside = new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))");

			// replace white spaces with underscore, then replace all invalid chars with empty string
			var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(original, "_"), string.Empty)
				// split by underscores
				.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
				// set first letter to uppercase
				.Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
				// replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
				.Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
				// set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
				.Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
				// lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
				.Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

			return string.Concat(pascalCase);
		}

		/// <summary>
		/// Parses the format.
		/// </summary>
		/// <param name="str">The string.</param>
		/// <param name="template">
		/// The template.
		/// <example>ex: str.ParseFormat("The value {0} is '{1}'.")</example>
		/// </param>
		/// <returns>The matching strings in order.</returns>
		public static IList<string> ParseFormat(this string str, string template)
		{
			//Handles regex special characters.
			template = Regex.Replace(template, @"[\\\^\$\.\|\?\*\+\(\)\[\]]", m => "\\" + m.Value);
			var pattern = "^" + Regex.Replace(template, @"\{[0-9]+\}", "(.*?)") + "$";

			var r = new Regex(pattern);
			var m = r.Match(str);
			var ret = new List<string>();

			for (var i = 1; i < m.Groups.Count; i++)
			{
				ret.Add(m.Groups[i].Value);
			}

			return ret;
		}

	}
}
