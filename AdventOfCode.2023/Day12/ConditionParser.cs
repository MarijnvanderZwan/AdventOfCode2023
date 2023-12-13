namespace AdventOfCode._2023.Day12
{
	public static class ConditionParser
	{
		public static List<Condition> Parse(string input)
		{
			return FileParser.Parse(input, x => ParseUnfoldedCondition(x, 1));
		}

		public static List<Condition> ParseUnfolded(string input)
		{
			return FileParser.Parse(input, x => ParseUnfoldedCondition(x, 5));
		}

		private static Condition ParseUnfoldedCondition(string input, int numberOfUnfolds)
		{
			string[] split = input.Split(' ', StringSplitOptions.TrimEntries);
			string record = split[0];
			string numbers = split[1];
			string repeatedRecord = $".{string.Join("?", Enumerable.Repeat(record, numberOfUnfolds))}.";
			string repeatedNumbers = $"{string.Join(",", Enumerable.Repeat(numbers, numberOfUnfolds))}";
			List<int> values = repeatedNumbers.Split(',').Select(int.Parse).ToList();
			return Condition.Create(repeatedRecord, values);
		}
	}
}