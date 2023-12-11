using AdventOfCode._2023.Day08;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay08
	{
		[Test]
		public void NumberOfMovesForExampleInput_Should_GiveCorrectResult()
		{
			Maps maps = new (
				new List<Node>
				{
					new ("AAA", "BBB", "BBB"),
					new ("BBB", "AAA", "ZZZ"),
					new ("ZZZ", "ZZZ", "ZZZ")
				}, "LLR");

			int result = maps.GetNumberOfMovesToDestination("AAA", "ZZZ");

			result.Should().Be(6);
		}

		[Test]
		public void ParseExampleInput_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day08_ExamplePart1;

			Maps result = MapsParser.Parse(input);

			using (new AssertionScope())
			{
				result.Moves.Should().HaveLength(2);
				result.Nodes.Should().HaveCount(7);
				result.Nodes["AAA"].Label.Should().Be("AAA");
				result.Nodes["AAA"].Left.Should().Be("BBB");
				result.Nodes["AAA"].Right.Should().Be("CCC");
			}
		}

		[Test]
		public void Example2TraverseUntilAllZ_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day08_ExamplePart2;
			Maps maps = MapsParser.Parse(input);

			long result = maps.GetNumberOfMovesToDestination('A');

			result.Should().Be(6);
		}

		[Test]
		public void GetLoopSizes_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day08;
			Maps maps = MapsParser.Parse(input);

			List<long> result = maps.GetLoopSizes('A');

			using (new AssertionScope())
			{
				result.Should().HaveCount(6)
					.And.ContainInConsecutiveOrder(19637, 18023, 21251, 16409, 11567, 14257);
			}
		}

		[Test]
		public void Answer1_GetNumberOfMovesForPuzzleInput_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day08;
			Maps maps = MapsParser.Parse(input);

			int result = maps.GetNumberOfMovesToDestination("AAA", "ZZZ");

			using (new AssertionScope())
			{
				result.Should().Be(18023);
			}
		}

		[Test]
		public void Answer2_GetNumberOfMovesForPuzzleInput_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day08;
			Maps maps = MapsParser.Parse(input);

			long result = maps.GetNumberOfMovesToDestination('A');

			using (new AssertionScope())
			{
				result.Should().Be(14449445933179);
			}
		}
	}
}