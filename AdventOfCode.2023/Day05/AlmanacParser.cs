namespace AdventOfCode._2023.Day05
{
	public static class AlmanacParser
	{
		public static Almanac Parse(string content)
		{
			string[] split = content.Split("\r\n\r", StringSplitOptions.TrimEntries);
			IEnumerable<long> input = ParseInput(split[0]);
			IEnumerable<Map> maps = split.Skip(1).Select(ParseMap);

			return new Almanac(input, maps);
		}

		private static IEnumerable<long> ParseInput(string input)
		{
			string[] split = input.Split(':');
			return split[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
				.Select(long.Parse);
		}

		private static Map ParseMap(string input)
		{
			string[] split = input.Split('\n', StringSplitOptions.TrimEntries);

			string[] label = split[0][..^5].Split("-to-");
			string from = label[0];
			string to = label[1];
			return new Map(from, to, split.Skip(1).Select(ParseRange).ToList());
		}

		private static RangeMap ParseRange(string input)
		{
			string[] split = input.Trim().Split(' ', StringSplitOptions.TrimEntries);
			long fromStart = long.Parse(split[1]);
			long toStart = long.Parse(split[0]);
			long length = long.Parse(split[2]);
			return new RangeMap(fromStart, toStart, length);
		}
	}
}