namespace AdventOfCode._2023.Day5
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
			foreach (RangeMap mapx in Ranges)
			{
				updatedRanges = updatedRanges.SelectMany(mapx.Transform).ToList();
			}

			return updatedRanges
				.ConvertAll(range => range.Reset());
		}
	}
}