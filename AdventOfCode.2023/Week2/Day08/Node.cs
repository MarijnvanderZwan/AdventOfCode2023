namespace AdventOfCode._2023.Week2.Day08
{
	public record Node(string Label, string Left, string Right)
	{
		public string Move(string move)
		{
			if (move == "L")
			{
				return Left;
			}
			if (move == "R")
			{
				return Right;
			}

			throw new InvalidOperationException($"Invalid move {move}");
		}

		public bool MatchesEnd(char c)
		{
			return Label.EndsWith(c);
		}
	}
}