namespace AdventOfCode._2023.Week1.Day06
{
    public static class ListExtensions
    {
        public static long Product(this IEnumerable<long> list)
        {
            return list.Aggregate(1L, (x, y) => x * y);
        }
    }
}