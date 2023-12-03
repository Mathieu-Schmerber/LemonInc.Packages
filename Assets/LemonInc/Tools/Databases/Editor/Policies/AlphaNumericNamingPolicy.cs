using System.Linq;
using LemonInc.Tools.Databases.Interfaces;

namespace LemonInc.Tools.Databases.Policies
{
	/// <summary>
	/// Alpha numeric naming policy.
	/// </summary>
	public class AlphaNumericNamingPolicy : INamingPolicy
	{
		/// <inheritdoc/>
		public bool Validate(string name, out string error)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				error = "Name cannot be empty";
				return false;
			}

			if (!name.All(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x)))
			{
				error = "Name is not alpha numerical.";
				return false;
			}

			error = string.Empty;
			return true;
		}
	}
}
