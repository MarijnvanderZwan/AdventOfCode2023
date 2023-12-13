namespace AdventOfCode._2023.Day13
{
	public class AshPattern
	{
		public AshPattern(List<Pattern> rows, List<Pattern> columns)
		{
			_rows = rows;
			_columns = columns;
		}

		private readonly List<Pattern> _rows;
		private readonly List<Pattern> _columns;

		public int GetSummary(int expectedNumberOfSmudges)
		{
			int? row = GetReflectingPattern(expectedNumberOfSmudges, _rows);
			int? column = GetReflectingPattern(expectedNumberOfSmudges, _columns);
			if (row.HasValue)
			{
				return row.Value * 100;
			}

			if (column.HasValue)
			{
				return column.Value;
			}

			return -1;
		}

		private static int? GetReflectingPattern(int expectedNumberOfSmudges, List<Pattern> patterns)
		{
			return patterns
				.Where(pattern => pattern.IsCandidate)
				.Select(pattern => IsReflecting(pattern.Index, patterns, expectedNumberOfSmudges))
				.Where(pattern => pattern.HasValue)
				.DefaultIfEmpty(null)
				.First();
		}

		private static int? IsReflecting(int index, List<Pattern> entries, int expectedNumberOfSmudges)
		{
			int previous = index - 1;
			int next = index;

			int remainingNumberOfSmudges = expectedNumberOfSmudges;
			while (previous >= 0 && next < entries.Count)
			{
				int differences = StringDifferences.GetNumberOfDifferences(entries[previous].Input, entries[next].Input);
				if (differences > 1)
				{
					return null;
				}
				else if (differences > 0 && remainingNumberOfSmudges == 0)
				{
					return null;
				}
				else if (differences == 1 && remainingNumberOfSmudges > 0)
				{
					remainingNumberOfSmudges--;
				}

				previous--;
				next++;
			}

			return remainingNumberOfSmudges == 0
				? index
				: null;
		}
	}
}