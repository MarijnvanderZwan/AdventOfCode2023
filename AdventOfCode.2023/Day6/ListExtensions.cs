namespace AdventOfCode._2023.Day6
{
	public static class ListExtensions
	{
		public static long Product(this IEnumerable<long> list)
		{
			return list.Aggregate(1L, (x, y) => x * y);
		}
	}
}