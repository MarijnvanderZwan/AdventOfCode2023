namespace AdventOfCode._2023.Week1.Day05
{
    public sealed record Range(long Start, long End, bool Mapped = false)
    {
        public Range? GetIntersection(Range range)
        {
            if (End <= range.Start || Start >= range.End)
            {
                return null;
            }
            return new Range(Math.Max(Start, range.Start), Math.Min(End, range.End));
        }

        public List<Range> SubtractIntersection(Range intersection)
        {
            var result = new List<Range>();
            if (Start < intersection.Start)
            {
                result.Add(new Range(Start, intersection.Start));
            }

            if (End > intersection.End)
            {
                result.Add(new Range(intersection.End, End));
            }
            return result;
        }

        public Range Reset()
        {
            return new Range(Start, End);
        }
    }
}