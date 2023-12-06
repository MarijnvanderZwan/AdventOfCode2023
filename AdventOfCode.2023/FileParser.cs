namespace AdventOfCode._2023
{
	public static class FileParser
	{
		public static List<string> Parse(string input)
		{
			return input.Split("\n").ToList();
		}

		public static List<T> Parse<T>(string input, Func<string ,T> converter)
		{
			return input.Split("\n")
				.Select(converter)
				.ToList();
		}
	}
}