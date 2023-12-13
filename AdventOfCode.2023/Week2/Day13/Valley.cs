namespace AdventOfCode._2023.Day13
{
	public class Valley
	{
		public List<AshPattern> Patterns { get; }
		public int ExpectedNumberOfSmudges { get; }

		public Valley(IEnumerable<AshPattern> patterns, int expectedNumberOfSmudges)
		{
			ExpectedNumberOfSmudges = expectedNumberOfSmudges;
			Patterns = patterns.ToList();
		}

		public int GetSummary()
		{
			return Patterns
				.Select(pattern => pattern.GetSummary(ExpectedNumberOfSmudges))
				.Sum();
		}
	}
}