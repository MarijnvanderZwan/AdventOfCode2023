using AdventOfCode._2023.Day11;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay11
	{
		[Test]
		public void ParsingExample_Should_GiveCorrectGalaxies()
		{
			string input = Resources.Resources.Day11_Example;

			Space result = SpaceParser.ParseV2(input, 2);

			using (new AssertionScope())
			{
				result.Galaxies.Should().HaveCount(9);
			}
		}

		[Test]
		public void ParsingPuzzleInput_Should_GiveCorrectGalaxies()
		{
			string input = Resources.Resources.Day11;

			Space result = SpaceParser.ParseV2(input, 0);

			using (new AssertionScope())
			{
				result.Galaxies.Should().HaveCount(451);
			}
		}

		[Test]
		public void SumOfShortestRouteForExampleInputV3_Should_GiveCorrectResult()
		{
			Space result = SpaceParser.ParseV2(Resources.Resources.Day11_Example, 2);

			long sum = result.GetSumOfShortestRoutes(result);

			sum.Should().Be(374);
		}

		[TestCase(2, 374)]
		[TestCase(10, 1030)]
		[TestCase(100, 8410)]
		public void SumOfShortestRouteForExampleInput_Should_GiveCorrectResult(
			int size, int expectedValue)
		{
			Space result = SpaceParser.ParseV2(Resources.Resources.Day11_Example, size);

			long sum = result.GetSumOfShortestRoutes(result);

			sum.Should().Be(expectedValue);
		}

		[Test]
		public void Answer1_SumOfShortestRouteForPuzzleInput_Should_GiveCorrectResult()
		{
			Space result = SpaceParser.ParseV2(Resources.Resources.Day11, 2);

			long sum = result.GetSumOfShortestRoutes(result);

			sum.Should().Be(10289334);
		}

		[Test]
		public void Answer2_SumOfShortestRouteForPuzzleInput_Should_GiveCorrectResult()
		{
			Space result = SpaceParser.ParseV2(Resources.Resources.Day11, 1000000);

			long sum = result.GetSumOfShortestRoutes(result);

			sum.Should().Be(649862989626);
		}
	}
}