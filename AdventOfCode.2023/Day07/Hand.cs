namespace AdventOfCode._2023.Day07
{
	public record Hand(List<char> Cards, CardType Type, CardType TypeV2, long Number, long NumberV2, int Bid)
	{
		public static Hand Create(string hand, int bid)
		{
			return new Hand(
				hand.ToList(),
				GetCardType(hand),
				GetCardTypeWithJokers(hand),
				GetOrdering(hand.ToList(), GetNumber),
				GetOrdering(hand.ToList(), GetNumberWithJokers),
				bid);
		}

		public int GetWinnings(int Position)
		{
			return Bid * Position;
		}

		private static CardType GetCardType(string hand)
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

		private static CardType GetCardTypeWithJokers(string hand)
		{
			List<IGrouping<char, char>> orderedNumberOfCards = hand
				.GroupBy(x => x)
				.OrderByDescending(x => x.Count())
				.ToList();
			if (orderedNumberOfCards.Count == 1 && orderedNumberOfCards.Single().Key == 'J')
			{
				return GetCardType("AAAAA");
			}

			if (orderedNumberOfCards.Any(x => x.Key == 'J'))
			{
				IGrouping<char, char> highestOther = orderedNumberOfCards.First(x => x.Key != 'J');
				return GetCardType(hand.Replace("J", highestOther.Key.ToString()));
			}
			return GetCardType(hand);
		}

		private static long GetOrdering(IList<char> cards, Func<char, int> getNumber)
		{
			const int baseNumber = 15;
			long total = 0;
			for (int i = 0; i < cards.Count; i++)
			{
				total += (long)Math.Pow(baseNumber, i) * getNumber(cards[cards.Count - i - 1]);
			}

			return total;
		}

		private static int GetNumber(char c)
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

		private static int GetNumberWithJokers(char c)
		{
			return c == 'J'
				? 1
				: GetNumber(c);
		}

		public override string ToString()
		{
			return $"{Type} {new string(Cards.ToArray())}";
		}
	}
}