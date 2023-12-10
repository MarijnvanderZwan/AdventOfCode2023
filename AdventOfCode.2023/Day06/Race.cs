namespace AdventOfCode._2023.Day06
{
	public record Race(long Time, long Record)
	{
		public Solution Solve()
		{
			const double marginToBeatRecord = 0.1;
			return QuadraticSolver.Solve(1, -Time, Record + marginToBeatRecord);
		}

		public long GetRange()
		{
			return Solve().GetRange();
		}
	}
}