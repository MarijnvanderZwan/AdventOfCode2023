namespace AdventOfCode._2023.Day12
{
	public class ArrangementCalculator
	{
		private readonly Dictionary<Condition, long> _cache = new();

		public long Calculate(IEnumerable<Condition> conditions)
		{
			return conditions
				.Select(Calculate)
				.Sum();
		}

		public long Calculate(Condition condition)
		{
			if (_cache.ContainsKey(condition))
			{
				return _cache[condition];
			}
			long result = Process(condition);
			_cache[condition] = result;
			return result;
		}

		private long Process(Condition condition)
		{
			if (condition.Record.Length <= 1 && condition.Values.Any())
			{
				return 0;
			}
			if (condition.Record.Length <= 1 && !condition.Values.Any())
			{
				return 1;
			}

			return condition.Record[0] switch
			{
				'.' => Calculate(condition.ConsumeOperational()),
				'#' => HandleDamaged(condition),
				'?' => Calculate(condition.BranchOperational()) + Calculate(condition.BranchDamaged()),
				_ => throw new InvalidOperationException("Only the values ., # or ? are allowed")
			};
		}

		private long HandleDamaged(Condition condition)
		{
			if (!condition.Values.Any())
			{
				return 0;
			}

			int expectedDamagedLength = condition.Values.Peek();

			for (int i = 0; i < expectedDamagedLength; i++)
			{
				if (condition.Record[i] != '#' && condition.Record[i] != '?')
				{
					return 0;
				}
			}

			if (condition.Record[expectedDamagedLength] == '#')
			{
				return 0;
			}

			if (condition.Record[expectedDamagedLength] == '.' || condition.Record[expectedDamagedLength] == '?')
			{
				return Calculate(condition.ConsumeValue());
			}

			throw new InvalidOperationException("One of the other conditions should be met");
		}
	}
}