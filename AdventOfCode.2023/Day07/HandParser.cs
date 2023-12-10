namespace AdventOfCode._2023.Day07
{
	public static class HandParser
	{
		public static List<Hand> Parse(string content)
		{
			return FileParser.Parse(content, ParseHand);
		}

		private static Hand ParseHand(string line)
		{
			string[] split = line.Split(' ', StringSplitOptions.TrimEntries);
			return Hand.Create(split[0], int.Parse(split[1]));
		}
	}
}