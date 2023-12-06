namespace AdventOfCode._2023.Day4
{
	public class ScratchCardEvaluator
	{
		private readonly List<ScratchCard> _scratchCards;
		private readonly int[] _occurences;

		public ScratchCardEvaluator(IEnumerable<ScratchCard> scratchCards)
		{
			_scratchCards = scratchCards.ToList();
			_occurences = Enumerable.Repeat(1, _scratchCards.Count).ToArray();
		}

		public int Evaluate()
		{
			for (int i = 0; i < _scratchCards.Count; i++)
			{
				int numberOfCards = _occurences[i];
				int numberOfMatches = _scratchCards[i].GetNumberOfMatches();
				for (int j = 1; j <= numberOfMatches; j++)
				{
					_occurences[i + j] += numberOfCards;
				}
			}
			return _occurences.Sum();
		}

	}
}