using AdventOfCode._2023.Week1.Day06;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023.Week1
{
    [TestFixture]
    public class TestDay06
    {
        [TestCase(68, 1020, 23, 45)]
        [TestCase(59, 543, 12, 47)]
        [TestCase(82, 1664, 37, 45)]
        [TestCase(74, 1022, 19, 55)]
        public void Factorizing_Should_GiveCorrectResult(
            int b, int c, int x1, int x2)
        {
            var result = QuadraticSolver.Solve(1, -b, c);

            using (new AssertionScope())
            {
                result.X1.Should().Be(x1);
                result.X2.Should().Be(x2);
            }
        }

        [TestCase(68, 1020, 23)]
        [TestCase(59, 543, 36)]
        [TestCase(82, 1664, 9)]
        [TestCase(74, 1022, 37)]
        [TestCase(71530, 940200, 71503)]
        public void GetRange_Should_GiveCorrectResult(
            int time, int record, int expectedResult)
        {
            Race race = new(time, record);

            long actualResult = race.GetRange();

            actualResult.Should().Be(expectedResult);
        }

        [Test]
        public void ProductOfRangesForExampleInput_Should_GiveCorrectResult()
        {
            List<Race> input = GetExampleInput();

            long result = input.Select(x => x.GetRange()).Product();

            result.Should().Be(288);
        }

        [Test]
        public void RangeForCombinedExample_Should_GiveCorrectResult()
        {
            Race input = GetExampleCombinedRace();

            long result = input.GetRange();

            result.Should().Be(71503);
        }

        [Test]
        public void Answer1_ProductOfRanges_Should_GiveCorrectResult()
        {
            List<Race> input = GetPuzzleInput();

            long result = input.Select(x => x.GetRange()).Product();

            result.Should().Be(275724);
        }

        [Test]
        public void Answer2_GetResult_Should_GiveCorrectResult()
        {
            Race input = GetCombinedPuzzleInput();

            long result = input.GetRange();

            result.Should().Be(37286485);
        }

        private static List<Race> GetExampleInput()
        {
            return new List<Race>
            {
                new(7, 9),
                new(15, 40),
                new(30, 200)
            };
        }

        private static Race GetExampleCombinedRace()
        {
            return new Race(71530, 940200);
        }

        private static List<Race> GetPuzzleInput()
        {
            return new List<Race>
            {
                new(59, 543),
                new(68, 1020),
                new(82, 1664),
                new(74, 1022)
            };
        }

        private static Race GetCombinedPuzzleInput()
        {
            return new Race(59688274, 543102016641022);
        }
    }
}