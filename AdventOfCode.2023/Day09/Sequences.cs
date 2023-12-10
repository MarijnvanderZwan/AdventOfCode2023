namespace AdventOfCode._2023.Day09
{
	public sealed class Sequences
	{
		public Sequences(List<Series> numbers)
		{
			Numbers = numbers;
		}

		public List<Series> Numbers { get; }

		public Sequences Extrapolate()
		{
			List<Series> result = new()
			{
				Numbers.Last()
			};
			for (int i = Numbers.Count - 2; i >= 0; i--)
			{
				int number = Numbers[i].Last() + result.Last().Last();
				List<int> numbers = Numbers[i]
					.Append(number)
					.ToList();
				result.Add(new Series(numbers));
			}

			return new Sequences(result.AsEnumerable().Reverse().ToList());
		}

		public Sequences ExtrapolateBackwards()
		{
			List<Series> result = new()
			{
				Numbers.Last()
			};
			for (int i = Numbers.Count - 2; i >= 0; i--)
			{
				int number = Numbers[i][0] - result.Last()[0];
				List<int> numbers = new[] { number }
					.Concat(Numbers[i])
					.ToList();
				result.Add(new Series(numbers));
			}

			return new Sequences(result.AsEnumerable().Reverse().ToList());
		}

		public int GetFirstNumber()
		{
			return Numbers.First().First();
		}

		public int GetLastNumber()
		{
			return Numbers.First().Last();
		}

		public static Sequences Create(Series numbers)
		{
			List<Series> result = new() { numbers };
			List<int> currentSequence = numbers;
			while (currentSequence.Any(c => c != 0))
			{
				var newSequence = new List<int>();
				for (int i = 1; i < currentSequence.Count; i++)
				{
					int difference = currentSequence[i] - currentSequence[i - 1];
					newSequence.Add(difference);
				}

				result.Add(new Series(newSequence));
				currentSequence = newSequence;
			}

			return new Sequences(result);
		}
	}
}