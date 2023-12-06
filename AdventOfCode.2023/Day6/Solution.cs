namespace AdventOfCode._2023.Day6
{
	public record Solution(long X1, long X2)
	{
		public long GetRange()
		{
			return X2 - X1 + 1;
		}
	}
}