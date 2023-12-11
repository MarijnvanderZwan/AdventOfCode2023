using AdventOfCode._2023.Day07;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay07
	{
		[TestCase("AAAAA", CardType.FiveOfAKind)]
		[TestCase("AA8AA", CardType.FourOfAKind)]
		[TestCase("23332", CardType.FullHouse)]
		[TestCase("TTT98", CardType.ThreeOfAKind)]
		[TestCase("23432", CardType.TwoPair)]
		[TestCase("A23A4", CardType.OnePair)]
		[TestCase("23456", CardType.HighCard)]
		public void GetCardTypes_Should_GiveCorrectResult(string hand, CardType expectedCardType)
		{
			CardType actualCardType = Hand.Create(hand, 0).Type;

			actualCardType.Should().Be(expectedCardType);
		}

		[Test]
		public void Hands_Should_OrderCorrectly()
		{
			var hands = new List<Hand>
			{
				Hand.Create("32T3K", 0),
				Hand.Create("T55J5", 0),
				Hand.Create("KK677", 0),
				Hand.Create("KTJJT", 0),
				Hand.Create("QQQJA", 0)
			};

			var ordered = hands
				.OrderBy(x => x.Type)
				.ThenByDescending(x => x.Number);

			using (new AssertionScope())
			{
				ordered.Select(x => new string(x.Cards.ToArray())).Should().ContainInOrder(
					"QQQJA", "T55J5", "KK677", "KTJJT", "32T3K");
			}
		}

		[Test]
		public void Hands_Should_GiveCorrectTotalWinnings()
		{
			var hands = new List<Hand>
			{
				Hand.Create("32T3K", 765),
				Hand.Create("T55J5", 684),
				Hand.Create("KK677", 28),
				Hand.Create("KTJJT", 220),
				Hand.Create("QQQJA", 483)
			};

			var ordered = hands
				.OrderBy(x => x.Type)
				.ThenByDescending(x => x.Number)
				.Select((i, j) => i.GetWinnings(hands.Count - j))
				.Sum();

			using (new AssertionScope())
			{
				ordered.Should().Be(6440);
			}
		}

		[Test]
		public void Hands_Should_GiveCorrectTotalWinningsV2()
		{
			var hands = new List<Hand>
			{
				Hand.Create("32T3K", 765),
				Hand.Create("T55J5", 684),
				Hand.Create("KK677", 28),
				Hand.Create("KTJJT", 220),
				Hand.Create("QQQJA", 483)
			};

			var ordered = hands
				.OrderBy(x => x.TypeV2)
				.ThenByDescending(x => x.NumberV2)
				.Select((i, j) => i.GetWinnings(hands.Count - j))
				.Sum();

			using (new AssertionScope())
			{
				ordered.Should().Be(5905);
			}
		}

		[Test]
		public void HandParser_Should_GiveCorrectNumberOfHands()
		{
			string content = Resources.Resources.Day07;

			List<Hand> hands = HandParser.Parse(content);

			using (new AssertionScope())
			{
				hands.Should().HaveCount(1000);
			}
		}

		[Test]
		public void Answer1_Should_GiveCorrectResult()
		{

			List<Hand> hands = HandParser.Parse(Resources.Resources.Day07);
			var ordered = hands
				.OrderBy(x => x.Type)
				.ThenByDescending(x => x.Number)
				.Select((i, j) => i.GetWinnings(hands.Count - j))
				.Sum();

			using (new AssertionScope())
			{
				ordered.Should().Be(250951660);
			}
		}

		[Test]
		public void Answer2_Should_GiveCorrectResult()
		{
			List<Hand> hands = HandParser.Parse(Resources.Resources.Day07);
			int ordered = hands
				.OrderBy(x => x.TypeV2)
				.ThenByDescending(x => x.NumberV2)
				.Select((i, j) => i.GetWinnings(hands.Count - j))
				.Sum();

			using (new AssertionScope())
			{
				ordered.Should().Be(251481660);
			}
		}
	}
}