using AdventOfCode._2023.Day10;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay10
	{
		[Test]
		public void ParsingExampleInput1_Should_ParseCorrectly()
		{
			string input = Resources.Resources.Day10_Part1Example1;

			Diagram result = DiagramParser.Parse(input);

			using (new AssertionScope())
			{
				result.Tiles.GetLength(0).Should().Be(5);
				result.Tiles.GetLength(1).Should().Be(5);
				result.GetStart().Connections.Should().HaveCount(2);
				result.GetStart().Connections[0].Should().Be(new Offset(1, 0));
				result.GetStart().Connections[1].Should().Be(new Offset(0, 1));
			}
		}

		[Test]
		public void ParsingExampleInput2_Should_GiveCorrectDiagramSizes()
		{
			string input = Resources.Resources.Day10_Part1Example2;

			Diagram result = DiagramParser.Parse(input);

			using (new AssertionScope())
			{
				result.Tiles.GetLength(0).Should().Be(5);
				result.Tiles.GetLength(1).Should().Be(5);
				result.GetStart().Connections.Should().HaveCount(2);
				result.GetStart().Connections[0].Should().Be(new Offset(1, 0));
				result.GetStart().Connections[1].Should().Be(new Offset(0, 1));
			}
		}

		[Test]
		public void ParsingPuzzleInput_Should_GiveCorrectDiagramSizes()
		{
			string input = Resources.Resources.Day10;

			Diagram result = DiagramParser.Parse(input);

			using (new AssertionScope())
			{
				result.Tiles.GetLength(0).Should().Be(140);
				result.Tiles.GetLength(1).Should().Be(140);
				result.GetStart().Connections.Should().HaveCount(2);
				result.GetStart().Connections[0].Should().Be(new Offset(0, -1));
				result.GetStart().Connections[1].Should().Be(new Offset(0, 1));
			}
		}

		[Test]
		public void GetLoopForExampleInput1_Should_GiveCorrectLength()
		{
			var diagram = DiagramParser.Parse(Resources.Resources.Day10_Part1Example1);

			var result = diagram.GetLoop();

			result.Should().HaveCount(8);
		}

		[Test]
		public void GetLoopForExampleInput2_Should_GiveCorrectLength()
		{
			var diagram = DiagramParser.Parse(Resources.Resources.Day10_Part1Example2);

			var result = diagram.GetLoop();

			result.Should().HaveCount(16);
		}


		[Test]
		public void GetLoopForPuzzleInput_Should_GiveCorrectLength()
		{
			var diagram = DiagramParser.Parse(Resources.Resources.Day10);

			var result = diagram.GetLoop().Count / 2;

			result.Should().Be(6897);
		}

		[Test]
		public void CountAreaForExample1_Should_GiveCorrectResult()
		{
			var result = InteriorCounter.Count(Resources.Resources.Day10_Part2Example1, "F");

			result.Should().Be(4);
		}

		[Test]
		public void CountAreaForExample2_Should_GiveCorrectResult()
		{
			var result = InteriorCounter.Count(Resources.Resources.Day10_Part2Example2, "7");

			result.Should().Be(10);
		}

		[Test]
		public void CountAreaForPuzzleInput_Should_GiveCorrectResult()
		{
			var result = InteriorCounter.Count(Resources.Resources.Day10, "|");

			result.Should().Be(367);
		}
	}
}