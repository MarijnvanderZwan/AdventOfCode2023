using AdventOfCode._2023.Day1;
using FluentAssertions;

namespace AdventOfCode._2023
{
    [TestFixture]
	public class TestDay1
	{
		[TestCase("1abc2", 12)]
		[TestCase("pqr3stu8vwx", 38)]
		[TestCase("a1b2c3d4e5f", 15)]
		[TestCase("treb7uchet", 77)]
		[TestCase("two1nine", 29)]
		[TestCase("eightwothree", 83)]
		[TestCase("abcone2threexyz", 13)]
		[TestCase("xtwone3four", 24)]
		[TestCase("4nineeightseven2", 42)]
		[TestCase("zoneight234", 14)]
		[TestCase("7pqrstsixteen", 76)]
		[TestCase("7asdfive", 75)]
		[TestCase("sevenine8", 78)]
		public void GetCalibrationValue_Should_GiveCorrectResult(string value, int expectedResult)
		{
			int actualResult = Calibration.GetCalibrationValue(value);

			actualResult.Should().Be(expectedResult);
		}

		[Test]
		public void ParsingInput_Should_GiveCorrectNumberOfEntries()
		{
			string input = Resources.Resources.Day1;

			List<string> result = FileParser.Parse(input);

			result.Should().HaveCount(1000);
		}

		[Test]
		public void Answer1_SumOfInputs_Should_GiveCorrectResult()
		{
			string inputFile = Resources.Resources.Day1;
			List<string> input = FileParser.Parse(inputFile);

			int result = input.Select(Calibration.GetCalibrationValueWithoutLetters).Sum();

			result.Should().Be(54573);
		}

		[Test]
		public void Answer2_SumOfInputsWithLetters_Should_GiveCorrectResult()
		{
			string inputFile = Resources.Resources.Day1;
			List<string> input = FileParser.Parse(inputFile);

			int result = input.Select(Calibration.GetCalibrationValue).Sum();

			result.Should().Be(54591);
		}
	}
}