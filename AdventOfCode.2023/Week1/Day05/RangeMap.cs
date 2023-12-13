namespace AdventOfCode._2023.Week1.Day05
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

        public List<Range> Map(Range inputRange)
        {
            if (inputRange.Mapped)
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