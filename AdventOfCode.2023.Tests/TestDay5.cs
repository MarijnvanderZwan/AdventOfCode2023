using AdventOfCode._2023.Day5;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay5
	{
		[Test]
		public void ParsingExampleInput_Should_GiveCorrectResult()
		{
			string content = Resources.Resources.Day5_Example;

			Almanac result = AlmanacParser.Parse(content);

			using (new AssertionScope())
			{
				result.Input.Should().HaveCount(4)
					.And.ContainInOrder(79, 14, 55, 13);
				result.Maps.Select(x => x.Value.From).Should().HaveCount(7)
					.And.ContainInOrder("seed", "soil", "fertilizer", "water", "light", "temperature", "humidity");
				result.Maps.Select(x => x.Value.To).Should().HaveCount(7)
					.And.ContainInOrder("soil", "fertilizer", "water", "light", "temperature", "humidity", "location");
			}
		}

		[Test]
		public void ParsingPuzzleInput_Should_GiveCorrectResult()
		{
			string content = Resources.Resources.Day5;

			Almanac result = AlmanacParser.Parse(content);

			using (new AssertionScope())
			{
				result.Input.Should().HaveCount(20);
				result.Maps.Select(x => x.Value.From).Should().HaveCount(7)
					.And.ContainInOrder("seed", "soil", "fertilizer", "water", "light", "temperature", "humidity");
				result.Maps.Select(x => x.Value.To).Should().HaveCount(7)
					.And.ContainInOrder("soil", "fertilizer", "water", "light", "temperature", "humidity", "location");
			}
		}

		[TestCase(1, 1)]
		[TestCase(48, 48)]
		[TestCase(50, 52)]
		[TestCase(97, 99)]
		[TestCase(98, 50)]
		[TestCase(99, 51)]
		[TestCase(79, 81)]
		[TestCase(14, 14)]
		[TestCase(55, 57)]
		[TestCase(13, 13)]
		public void MapOnce_Should_GiveCorrectResult(
			long inputValue, long expectedValue)
		{
			string content = Resources.Resources.Day5_Example;
			Almanac almanac = AlmanacParser.Parse(content);
			Number number = new("seed", inputValue);

			Number actualValue = almanac.MapOnce(number);

			using (new AssertionScope())
			{
				actualValue.Label.Should().Be("soil");
				actualValue.Value.Should().Be(expectedValue);
			}
		}

		[TestCase(79, 82)]
		[TestCase(14, 43)]
		[TestCase(55, 86)]
		[TestCase(13, 35)]
		public void MapToEnd_Should_GiveCorrectResult(
			long inputValue, long expectedValue)
		{
			string content = Resources.Resources.Day5_Example;
			Almanac almanac = AlmanacParser.Parse(content);
			Number number = new("seed", inputValue);

			Number actualValue = almanac.MapToEnd(number);

			using (new AssertionScope())
			{
				actualValue.Label.Should().Be("location");
				actualValue.Value.Should().Be(expectedValue);
			}
		}

		[Test]
		public void GetLowestLocationByStartSeedsForExampleInput_Should_GiveCorrectResult()
		{
			string content = Resources.Resources.Day5_Example;
			Almanac almanac = AlmanacParser.Parse(content);

			long result = almanac.GetLowestLocationByStartSeeds();

			using (new AssertionScope())
			{
				result.Should().Be(35);
			}
		}

		[Test]
		public void GetLowestLocationFromExampleInputV2_Should_GiveCorrectResult()
		{
			string content = Resources.Resources.Day5_Example;
			Almanac almanac = AlmanacParser.Parse(content);

			long result = almanac.GetLowestLocation();

			using (new AssertionScope())
			{
				result.Should().Be(46);
			}
		}

		[Test]
		public void Answer1_GetLowestLocationForByStartSeedsFromPuzzleInput_Should_GiveCorrectResult()
		{
			string content = Resources.Resources.Day5;
			Almanac almanac = AlmanacParser.Parse(content);

			long result = almanac.GetLowestLocationByStartSeeds();

			using (new AssertionScope())
			{
				result.Should().Be(226172555);
			}
		}

		[Test]
		public void Answer2_GetLowestLocationFromPuzzleInputV2_Should_GiveCorrectResult()
		{
			string content = Resources.Resources.Day5;
			Almanac almanac = AlmanacParser.Parse(content);

			long result = almanac.GetLowestLocation();

			using (new AssertionScope())
			{
				result.Should().Be(47909639);
			}
		}
	}
}