using AdventOfCode._2023.Week2.Day09;
using FluentAssertions;

namespace AdventOfCode._2023.Week2
{
    [TestFixture]
    public class TestDay09
    {
        [Test]
        public void ParsingPuzzleInput_Should_GiveCorrectNumberOfResults()
        {
            string input = Resources.Resources.Day09;

            List<Series> result = SeriesParser.Parse(input);

            result.Should().HaveCount(200);
        }

        [Test]
        public void ExampleInput1_Should_GiveCorrectNumberOfSequences()
        {
            Series series = GetExampleInput1();

            Sequences result = Sequences.Create(series);

            result.Numbers.Should().HaveCount(3);
        }

        [Test]
        public void ExampleInput2_Should_GiveCorrectNumberOfSequences()
        {
            Series series = GetExampleInput2();

            Sequences result = Sequences.Create(series);

            result.Numbers.Should().HaveCount(4);
        }

        [Test]
        public void ExampleInput3_Should_GiveCorrectNumberOfSequences()
        {
            Series series = GetExampleInput3();

            Sequences result = Sequences.Create(series);

            result.Numbers.Should().HaveCount(5);
        }

        [Test]
        public void ExtrapolatingExampleInput1_Should_GiveCorrectResult()
        {
            Sequences sequences = Sequences.Create(GetExampleInput1());

            Sequences result = sequences.Extrapolate();

            result.GetLastNumber().Should().Be(18);
        }

        [Test]
        public void ExtrapolatingExampleInput2_Should_GiveCorrectResult()
        {
            Sequences sequences = Sequences.Create(GetExampleInput2());

            Sequences result = sequences.Extrapolate();

            result.GetLastNumber().Should().Be(28);
        }

        [Test]
        public void ExtrapolatingExampleInput3_Should_GiveCorrectResult()
        {
            Sequences sequences = Sequences.Create(GetExampleInput3());

            Sequences result = sequences.Extrapolate();

            result.GetLastNumber().Should().Be(68);
        }

        [Test]
        public void SumOfExtrapolatedNumbers_Should_BeCorrect()
        {
            List<Sequences> sequences = new()
            {
                Sequences.Create(GetExampleInput1()),
                Sequences.Create(GetExampleInput2()),
                Sequences.Create(GetExampleInput3())
            };

            int result = sequences
                .Select(sequence => sequence.Extrapolate().GetLastNumber())
                .Sum();

            result.Should().Be(114);
        }

        [Test]
        public void ExtrapolatingBackwardsForExampleInput1_Should_GiveCorrectResult()
        {
            Sequences sequences = Sequences.Create(GetExampleInput1());

            Sequences result = sequences.ExtrapolateBackwards();

            result.GetFirstNumber().Should().Be(-3);
        }

        [Test]
        public void ExtrapolatingBackwardsForExampleInput2_Should_GiveCorrectResult()
        {
            Sequences sequences = Sequences.Create(GetExampleInput2());

            Sequences result = sequences.ExtrapolateBackwards();

            result.GetFirstNumber().Should().Be(0);
        }

        [Test]
        public void ExtrapolatingBackwardsForExampleInput3_Should_GiveCorrectResult()
        {
            Sequences sequences = Sequences.Create(GetExampleInput3());

            Sequences result = sequences.ExtrapolateBackwards();

            result.GetFirstNumber().Should().Be(5);
        }


        [Test]
        public void Answer1_SumOfExtrapolatedNumbers_Should_BeCorrect()
        {
            List<Sequences> sequences = SeriesParser.Parse(Resources.Resources.Day09)
                .Select(Sequences.Create)
                .ToList();

            int result = sequences
                .Select(sequence => sequence.Extrapolate().GetLastNumber())
                .Sum();

            result.Should().Be(1974913025);
        }

        [Test]
        public void Answer2_SumOfBackwardsExtrapolatedNumbers_Should_BeCorrect()
        {
            List<Sequences> sequences = SeriesParser.Parse(Resources.Resources.Day09)
                .Select(Sequences.Create)
                .ToList();

            int result = sequences
                .Select(sequence => sequence.ExtrapolateBackwards().GetFirstNumber())
                .Sum();

            result.Should().Be(884);
        }

        private static Series GetExampleInput1()
        {
            return new Series(new List<int> { 0, 3, 6, 9, 12, 15 });
        }

        private static Series GetExampleInput2()
        {
            return new Series(new List<int> { 1, 3, 6, 10, 15, 21 });
        }

        private static Series GetExampleInput3()
        {
            return new Series(new List<int> { 10, 13, 16, 21, 30, 45 });
        }
    }
}
