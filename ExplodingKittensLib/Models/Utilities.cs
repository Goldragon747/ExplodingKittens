namespace ExplodingKittensLib.Models
{
	public static class Utilities
	{
		public static int GetIntFromString(string input, int def)
		{
			int res = def;
			if (string.IsNullOrEmpty(input) || !int.TryParse(input, out res))
				return def;

			return res;
		}
	}
}
