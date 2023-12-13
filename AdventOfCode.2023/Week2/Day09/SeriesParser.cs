namespace AdventOfCode._2023.Day09
{
	public static class SeriesParser
	{
		public static List<Series> Parse(string content)
		{
			return FileParser.Parse(content, ParseSeries);
		}

		private static Series ParseSeries(string line)
		{
			var numbers = line.Split(' ', StringSplitOptions.TrimEntries)
				.Select(int.Parse)
				.ToList();
			return new Series(numbers);
		}
	}
}