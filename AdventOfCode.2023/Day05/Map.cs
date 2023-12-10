namespace AdventOfCode._2023.Day05
{
	public sealed record Map(string From, string To, List<RangeMap> Ranges)
	{
		public long MapValue(long inputValue)
		{
			List<RangeMap> range = Ranges
				.Where(range => range.Contains(inputValue))
				.ToList();
			return range.Any()
				? range.First().Map(inputValue)
				: inputValue;
		}

		public List<Range> MapRanges(IEnumerable<Range> ranges)
		{
			List<Range> updatedRanges = ranges.ToList();
			foreach (RangeMap range in Ranges)
			{
				updatedRanges = updatedRanges.SelectMany(range.Map).ToList();
			}

			return updatedRanges
				.ConvertAll(range => range.Reset());
		}
	}
}