namespace AdventOfCode._2023.Day13
{
	public static class ValleyParser
	{
		public static Valley Parse(string input, int expectedNumberOfSmudges)
		{
			string[] split = input.Split("\r\n\r\n", StringSplitOptions.TrimEntries);
			return new Valley(split.Select(x => ParseAshPattern(x, expectedNumberOfSmudges)), expectedNumberOfSmudges);
		}

		private static AshPattern ParseAshPattern(string input, int expectedNumberOfSmudges)
		{
			string[] split = input.Split('\n', StringSplitOptions.TrimEntries);

			List<Pattern> rows = new() { new Pattern(0, split[0], false) };
			for (int y = 1; y < split.Length; y++)
			{
				bool isCandidate = StringDifferences.GetNumberOfDifferences(split[y], split[y - 1]) <= expectedNumberOfSmudges;
				rows.Add(new Pattern(y, split[y], isCandidate));
			}

			string lastColumn = string.Concat(split.Select(s => s[0]));
			List<Pattern> columns = new() { new Pattern(0, lastColumn, false) };
			for (int x = 1; x < split[0].Length; x++)
			{
				string nextColumn = string.Concat(split.Select(s => s[x]));
				bool isCandidate = StringDifferences.GetNumberOfDifferences(nextColumn, lastColumn) <= expectedNumberOfSmudges;
				columns.Add(new Pattern(x, nextColumn, isCandidate));
				lastColumn = nextColumn;
			}

			return new AshPattern(rows, columns);
		}
	}
}