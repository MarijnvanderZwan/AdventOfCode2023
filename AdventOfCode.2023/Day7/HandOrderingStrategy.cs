namespace AdventOfCode._2023.Day7
{
	public class HandOrderingStrategy
	{
		public CardType GetCardType(string hand)
		{
			List<IGrouping<char, char>> orderedNumberOfCards = hand.GroupBy(x => x)
				.OrderByDescending(x => x.Count())
				.ToList();
			return orderedNumberOfCards[0].Count() switch
			{
				5 => CardType.FiveOfAKind,
				4 => CardType.FourOfAKind,
				3 when orderedNumberOfCards[1].Count() == 2 => CardType.FullHouse,
				3 => CardType.ThreeOfAKind,
				2 when orderedNumberOfCards[1].Count() == 2 => CardType.TwoPair,
				2 => CardType.OnePair,
				1 => CardType.HighCard,
				_ => throw new InvalidOperationException("Cannot determine type")
			};
		}

		public static int GetNumber(char c)
		{
			if (char.IsDigit(c))
			{
				return int.Parse(c.ToString());
			}

			return c switch
			{
				'T' => 10,
				'J' => 11,
				'Q' => 12,
				'K' => 13,
				'A' => 14,
				_ => throw new InvalidOperationException($"Cannot determine number for {c}")
			};
		}
	}

	public class HandOrderingStrategyWithJokers : HandOrderingStrategy
	{

	}
}