using AdventOfCode._2023.Week2.Day13;
using FluentAssertions;

namespace AdventOfCode._2023.Week2
{
    [TestFixture]
    public class TestDay13
    {
        [Test]
        public void ExampleInput_Should_ParseCorrectly()
        {
            string input = Resources.Resources.Day13_Example;

            Valley result = ValleyParser.Parse(input, 0);

            result.Patterns.Should().HaveCount(2);
        }

        [Test]
        public void PuzzleInput_Should_ParseCorrectly()
        {
            string input = Resources.Resources.Day13;

            Valley result = ValleyParser.Parse(input, 0);

            result.Patterns.Should().HaveCount(100);
        }

        [Test]
        public void SummaryOfExampleInput_Should_GiveCorrectResult()
        {
            string input = Resources.Resources.Day13_Example;
            const int expectedNumberOfSmudges = 0;

            int result = ValleyParser.Parse(input, expectedNumberOfSmudges).GetSummary();

            result.Should().Be(405);
        }

        [Test]
        public void SummaryOfExampleInputWithSmudges_Should_GiveCorrectResult()
        {
            string input = Resources.Resources.Day13_Example;
            const int expectedNumberOfSmudges = 1;

            int result = ValleyParser.Parse(input, expectedNumberOfSmudges).GetSummary();

            result.Should().Be(400);
        }

        [Test]
        public void Answer1_SummaryOfPuzzleInput_Should_GiveCorrectResult()
        {
            string input = Resources.Resources.Day13;
            const int expectedNumberOfSmudges = 0;

            int result = ValleyParser.Parse(input, expectedNumberOfSmudges).GetSummary();

            result.Should().Be(42974);
        }

        [Test]
        public void Answer2_SummaryOfPuzzleInput_Should_GiveCorrectResult()
        {
            string input = Resources.Resources.Day13;
            const int expectedNumberOfSmudges = 1;

            int result = ValleyParser.Parse(input, expectedNumberOfSmudges).GetSummary();

            result.Should().Be(27587);
        }
    }
}