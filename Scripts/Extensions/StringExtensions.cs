using System;
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
	}
}
