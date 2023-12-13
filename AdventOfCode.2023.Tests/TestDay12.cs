using AdventOfCode._2023.Day12;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay12
	{
		[Test]
		public void ParsingExampleInput_Should_GiveCorrectResult()
		{
			string input = Resources.Resources.Day12_Example;

			List<Condition> conditions = ConditionParser.Parse(input);

			using (new AssertionScope())
			{
				conditions.Should().HaveCount(6);
				conditions[0].Record.Should().Contain("???.###");
				conditions[0].Values.Should().HaveCount(3).And.ContainInOrder(1, 1, 3);
			}
		}

		[Test]
		public void ParsingPuzzleInput_Should_GiveCorrectNumberOfResults()
		{
			string input = Resources.Resources.Day12;

			List<Condition> conditions = ConditionParser.Parse(input);

			using (new AssertionScope())
			{
				conditions.Should().HaveCount(1000);
			}
		}

		[Test]
		public void ExampleInputShould_GiveCorrectNumberOfArrangements()
		{
			string input = Resources.Resources.Day12_Example;
			List<Condition> conditions = ConditionParser.Parse(input);

			long result = new ArrangementCalculator().Calculate(conditions);

			result.Should().Be(21);
		}

		[Test]
		public void UnfoldedExampleInput1_Should_GiveCorrectNumberOfArrangements()
		{
			string input = "??????#..????##??? 1,1,1,1,5";

			List<Condition> conditions = ConditionParser.Parse(input);
			long result = new ArrangementCalculator().Calculate(conditions);

			result.Should().Be(45);
		}

		[Test]
		public void UnfoldedExampleInput2_Should_GiveCorrectNumberOfArrangements()
		{
			string input = "?###???????? 3,2,1";
			Condition condition = ConditionParser.ParseUnfolded(input).First();

			long result = new ArrangementCalculator().Calculate(condition);

			result.Should().Be(506250);
		}

		[Test]
		public void Answer1_PuzzleInput_Should_GiveCorrectNumberOfArrangements()
		{
			string input = Resources.Resources.Day12;

			List<Condition> conditions = ConditionParser.Parse(input);
			long result = new ArrangementCalculator().Calculate(conditions);

			result.Should().Be(7204);
		}

		[Test]
		public void Answer2_UnfoldedPuzzleInput_Should_GiveCorrectNumberOfArrangements()
		{
			string input = Resources.Resources.Day12;
			List<Condition> conditions = ConditionParser.ParseUnfolded(input);

			long result = new ArrangementCalculator().Calculate(conditions);

			result.Should().Be(1672318386674);
		}
	}
}