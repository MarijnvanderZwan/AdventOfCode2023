namespace AdventOfCode._2023.Day04
{
	public record ScratchCard(List<int> WinningNumbers, List<int> Numbers)
	{
		public int GetWinnings()
		{
			int numberOfMatches = GetNumberOfMatches();
			return numberOfMatches > 0
				? (int)Math.Pow(2, numberOfMatches - 1)
				: 0;
		}

		public int GetNumberOfMatches()
		{
			return Numbers
				.Count(WinningNumbers.Contains);
		}
	}
}