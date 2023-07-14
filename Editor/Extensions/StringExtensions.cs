namespace LemonInc.Tools.Packager.Editor.Extensions
{
	public static class StringExtensions
	{
		public static string FirstCharToUpper(this string input)
		{
			var arr = input.ToCharArray();

			arr[0] = char.ToUpperInvariant(arr[0]);
			return new string(arr);
		}
	}
}