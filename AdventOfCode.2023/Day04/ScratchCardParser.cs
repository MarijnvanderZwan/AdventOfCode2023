namespace AdventOfCode._2023.Day04
{
	public static class ScratchCardParser
	{
		public static List<ScratchCard> Parse(string content)
		{
			return FileParser.Parse(content, ParseLine).ToList();
		}

		private static ScratchCard ParseLine(string line)
		{
			string[] split = line.Split('|');
			string[] winningNumbers = split[0].Split(':');
			return new ScratchCard(
				ParseNumbers(winningNumbers[1]),
				ParseNumbers(split[1]));
		}

		private static List<int> ParseNumbers(string content)
		{
			return content
				.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();
		}
	}
}