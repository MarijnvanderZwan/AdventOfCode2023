namespace AdventOfCode._2023.Day5
{
	public sealed class Almanac
	{
		public List<long> Input { get; }
		public IDictionary<string, Map> Maps { get; }

		public Almanac(IEnumerable<long> input, IEnumerable<Map> maps)
		{
			Input = input.ToList();
			Maps = maps.ToDictionary(x => x.From);
		}

		public Number MapOnce(Number input)
		{
			Map map = Maps[input.Label];
			long value = map.MapValue(input.Value);
			return new Number(map.To, value);
		}

		public Number MapToEnd(Number input)
		{
			Number result = input;
			while (Maps.ContainsKey(result.Label))
			{
				Map map = Maps[result.Label];
				long value = map.MapValue(result.Value);
				result = new Number(map.To, value);
			}

			return result;
		}

		public long GetLowestLocationByStartSeeds()
		{
			return Input
				.Select(i => MapToEnd(new Number("seed", i)))
				.Select(x => x.Value)
				.Min();
		}

		private IEnumerable<Range> GetRangesFromInput()
		{
			for (int i = 0; i < Input.Count / 2; i++)
			{
				long start = Input[i * 2];
				long length = Input[i * 2 + 1];
				yield return new Range(start, start + length);
			}
		}

		public long GetLowestLocation()
		{
			List<Range> currentRanges = GetRangesFromInput().ToList();
			string currentLabel = "seed";
			while (Maps.ContainsKey(currentLabel))
			{
				Map map = Maps[currentLabel];
				currentRanges = map.MapRanges(currentRanges);
				currentLabel = map.To;
			}

			return currentRanges
				.Select(x => x.Start)
				.Min();
		}
	}
}