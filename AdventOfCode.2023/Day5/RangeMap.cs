namespace AdventOfCode._2023.Day5
{
	public sealed record RangeMap(long FromStart, long ToStart, long Length)
	{
		public bool Contains(long value)
		{
			return value >= FromStart && value < FromStart + Length;
		}

		public long Map(long value)
		{
			return value - FromStart + ToStart;
		}

		public List<Range> Transform(Range inputRange)
		{
			if (inputRange.IsTransformed)
			{
				return new List<Range> { inputRange };
			}

			Range? intersection = new Range(FromStart, FromStart + Length).GetIntersection(inputRange);
			if (intersection == null)
			{
				return new List<Range> { inputRange };
			}

			Range transformed = new(intersection.Start + GetOffset(), intersection.End + GetOffset(), true);
			return new List<Range>
				{
					transformed
				}
				.Concat(inputRange.SubtractIntersection(intersection))
				.ToList();
		}

		private long GetOffset()
		{
			return ToStart - FromStart;
		}
	}
}