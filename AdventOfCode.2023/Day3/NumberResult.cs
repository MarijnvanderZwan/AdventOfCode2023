namespace AdventOfCode._2023.Day3
{
	public record NumberResult(int X, int Y, int Number)
	{
		public int GetLength()
		{
			return Number.ToString().Length;
		}
	}
}