using System.Text.RegularExpressions;

namespace AdventOfCode._2023.Day1
{
    public static class Calibration
    {
        public static int GetCalibrationValue(string value)
        {
            List<DigitResult> allDigits = GetNumberDigits(value)
                .Concat(GetWrittenDigits(value))
                .OrderBy(x => x.Position)
                .ToList();
            return GetResult(allDigits[0], allDigits[^1]);
        }

        public static int GetCalibrationValueWithoutLetters(string value)
        {
            List<DigitResult> allDigits = GetNumberDigits(value)
                .OrderBy(x => x.Position)
                .ToList();
            return GetResult(allDigits[0], allDigits[^1]);
        }

        private static int GetResult(DigitResult first, DigitResult last)
        {
            return first.Digit * 10 + last.Digit;
        }

        private static IEnumerable<DigitResult> GetNumberDigits(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsDigit(value[i]))
                {
                    yield return new DigitResult(i, int.Parse(value[i].ToString()));
                }
            }
        }

        private static List<DigitResult> GetWrittenDigits(string value)
        {
            return GetLetters()
                .SelectMany(letter => GetWrittenDigits(value, letter.Item1, letter.Item2))
                .ToList();
        }

        private static IEnumerable<DigitResult> GetWrittenDigits(string value, string valueToSearch, int digit)
        {
            return GetAllIndexesOf(value, valueToSearch)
                .Select(x => new DigitResult(x, digit));
        }

        private static IEnumerable<int> GetAllIndexesOf(string value, string valueToSearch)
        {
			foreach (Match match in Regex.Matches(value, valueToSearch).Cast<Match>())
            {
                yield return match.Index;
            }
        }

        private static List<(string, int)> GetLetters()
        {
            return new List<(string, int)>
            {
                ("one", 1),
                ("two", 2),
                ("three", 3),
                ("four", 4),
                ("five", 5),
                ("six", 6),
                ("seven", 7),
                ("eight", 8),
                ("nine", 9),
            };
        }

        private sealed record DigitResult(int Position, int Digit);
    }
}