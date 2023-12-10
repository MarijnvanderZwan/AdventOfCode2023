using AdventOfCode._2023.Day4;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay04
	{
		[Test]
		public void ParsingPuzzleInput_Should_GiveCorrectEntries()
		{
			string input = Resources.Resources.Day04;

			List<ScratchCard> result = ScratchCardParser.Parse(input);

			using (new AssertionScope())
			{
				result.Should().HaveCount(199);
				result[0].WinningNumbers.Should().HaveCount(10);
				result[0].Numbers.Should().HaveCount(25);
			}
		}

		[TestCaseSource(nameof(GetExamples))]
		public void GetWinnings_Should_GiveCorrectResult(ScratchCard card, int expectedWinnings)
		{
			int actualWinnings = card.GetWinnings();

			actualWinnings.Should().Be(expectedWinnings);
		}

		[Test]
		public void CalculatingNumberOfCardsForExampleInput_Should_GiveCorrectResult()
		{
			List<ScratchCard> cards = GetExampleCards();
			ScratchCardEvaluator evaluator = new ScratchCardEvaluator(cards);

			int result = evaluator.Evaluate();

			result.Should().Be(30);
		}

		[Test]
		public void Answer1_SumOfWinningsForPuzzleInput_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day04;
			List<ScratchCard> result = ScratchCardParser.Parse(input);

			int winnings = result.Select(x => x.GetWinnings()).Sum();

			winnings.Should().Be(23847);
		}

		[Test]
		public void Answer2_CalculatingNumberOfCardsForPuzzleInput_Should_GiveCorrectResult()
		{
			List<ScratchCard> cards = ScratchCardParser.Parse(Resources.Resources.Day04);
			ScratchCardEvaluator evaluator = new ScratchCardEvaluator(cards);

			int result = evaluator.Evaluate();

			result.Should().Be(8570000);
		}

		private static IEnumerable<object[]> GetExamples()
		{
			yield return new object[] { GetExampleCard1(), 8};
			yield return new object[] { GetExampleCard2(), 2};
			yield return new object[] { GetExampleCard3(), 2 };
			yield return new object[] { GetExampleCard4(), 1 };
			yield return new object[] { GetExampleCard5(), 0 };
			yield return new object[] { GetExampleCard6(), 0 };
		}

		private static List<ScratchCard> GetExampleCards()
		{
			return new List<ScratchCard>
			{
				GetExampleCard1(),
				GetExampleCard2(),
				GetExampleCard3(),
				GetExampleCard4(),
				GetExampleCard5(),
				GetExampleCard6()
			};
		}

		private static ScratchCard GetExampleCard1()
		{
			return new ScratchCard(new List<int> { 41, 48, 83, 86, 17},
				new List<int> { 83, 86, 6, 31, 17, 9, 48, 53});
		}

		private static ScratchCard GetExampleCard2()
		{
			return new ScratchCard(new List<int> { 13, 32, 20, 16, 61},
				new List<int> { 61, 30, 68, 82, 17, 32, 24, 19});
		}

		private static ScratchCard GetExampleCard3()
		{
			return new ScratchCard(new List<int> { 1, 21, 53, 59, 44},
				new List<int> { 69, 82, 63, 72, 16, 21, 14, 1});
		}

		private static ScratchCard GetExampleCard4()
		{
			return new ScratchCard(new List<int> { 41, 92, 73, 84, 69},
				new List<int> { 59, 84, 76, 51, 58, 5, 54, 83});
		}

		private static ScratchCard GetExampleCard5()
		{
			return new ScratchCard(new List<int> { 87, 83, 26, 28, 32},
				new List<int> { 88, 30, 70, 12, 93, 22, 82, 36});
		}

		private static ScratchCard GetExampleCard6()
		{
			return new ScratchCard(new List<int> { 31, 18, 13, 56, 72},
				new List<int> { 74, 77, 10, 23, 35, 67, 36, 11});
		}
	}
}