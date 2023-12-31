﻿using AdventOfCode._2023.Week1.Day03;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023.Week1
{
    [TestFixture]
    public class TestDay03
    {
        [Test]
        public void ParsingExampleInput_Should_GiveCorrectSize()
        {
            string input = Resources.Resources.Day03_Example;

            Schematic result = SchematicParser.Parse(input);

            using (new AssertionScope())
            {
                result.Grid.GetLength(0).Should().Be(10);
                result.Grid.GetLength(1).Should().Be(10);
            }
        }

        [Test]
        public void ParsingPuzzleInput_Should_GiveCorrectSize()
        {
            string input = Resources.Resources.Day03;

            Schematic result = SchematicParser.Parse(input);

            using (new AssertionScope())
            {
                result.Grid.GetLength(0).Should().Be(140);
                result.Grid.GetLength(1).Should().Be(140);
            }
        }

        [Test]
        public void GetAllNumbersFromExampleInput_Should_GiveCorrectNumbers()
        {
            string input = Resources.Resources.Day03_Example;
            Schematic schematic = SchematicParser.Parse(input);

            List<NumberResult> result = schematic.GetAllNumbers().ToList();

            using (new AssertionScope())
            {
                result.Should().HaveCount(10);
                result.Select(r => r.Number).Should().ContainInConsecutiveOrder(
                    467, 114, 35, 633, 617,
                    58, 592, 755, 664, 598);
            }
        }

        [Test]
        public void GetAllNumbersFromPuzzleInput_Should_GiveCorrectNumbers()
        {
            string input = Resources.Resources.Day03;
            Schematic schematic = SchematicParser.Parse(input);
            int expectedDigits = input.Count(char.IsDigit);

            int actualDigits = schematic.GetAllNumbers()
                .Select(x => x.Number.ToString().Length)
                .Sum();

            using (new AssertionScope())
            {
                actualDigits.Should().Be(expectedDigits);
            }
        }

        [Test]
        public void GetAllEnginePartsFromExampleInput_Should_GiveCorrectNumbers()
        {
            string input = Resources.Resources.Day03_Example;
            Schematic schematic = SchematicParser.Parse(input);

            List<int> result = schematic.GetAllEngineParts().ToList();

            using (new AssertionScope())
            {
                result.Should().HaveCount(8);
                result.Should().ContainInConsecutiveOrder(
                    467, 35, 633, 617,
                    592, 755, 664, 598);
                result.Sum().Should().Be(4361);
            }
        }

        [Test]
        public void GetGearRatiosFromExampleInput_Should_GiveCorrectNumbers()
        {
            string input = Resources.Resources.Day03_Example;
            Schematic schematic = SchematicParser.Parse(input);

            List<int> result = schematic.GetGearRatios().ToList();

            using (new AssertionScope())
            {
                result.Should().HaveCount(2);
                result.Should().ContainInConsecutiveOrder(16345, 451490);
                result.Sum().Should().Be(467835);
            }
        }

        [Test]
        public void Answer1_GetAllEnginePartsFromPuzzleInput_Should_GiveCorrectSum()
        {
            string input = Resources.Resources.Day03;
            Schematic schematic = SchematicParser.Parse(input);

            List<int> result = schematic.GetAllEngineParts().ToList();

            using (new AssertionScope())
            {
                result.Should().HaveCount(1064);
                result.Sum().Should().Be(537732);
            }
        }

        [Test]
        public void Answer2_GetGearRatiosFromPuzzleInput_Should_GiveCorrectNumbers()
        {
            string input = Resources.Resources.Day03;
            Schematic schematic = SchematicParser.Parse(input);

            List<int> result = schematic.GetGearRatios().ToList();
            foreach (int i in result)
            {
                Console.WriteLine(i);
            }
            using (new AssertionScope())
            {
                result.Should().HaveCount(325);
                result.Sum().Should().Be(84883664);
            }
        }
    }
}