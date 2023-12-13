namespace AdventOfCode._2023.Day08
{
	public sealed class Maps
	{
		public Maps(IEnumerable<Node> nodes, string moves)
		{
			Nodes = nodes.ToDictionary(x => x.Label);
			Moves = moves;
		}

		public Dictionary<string, Node> Nodes { get; }
		public string Moves { get; }

		public int GetNumberOfMovesToDestination(string start, string end)
		{
			Node currentLocation = Nodes[start];
			int numberOfMoves = 0;
			while (currentLocation.Label != end)
			{
				string currentMove = Moves[numberOfMoves % Moves.Length].ToString();
				currentLocation = Nodes[currentLocation.Move(currentMove)];
				numberOfMoves++;
			}
			return numberOfMoves;
		}

		public long GetNumberOfMovesToDestination(char start)
		{
			List<long> loopSizes = GetLoopSizes(start);
			return LeastCommonMultiple(loopSizes);
		}

		public List<long> GetLoopSizes(char start)
		{
			List<Node> currentLocations = Nodes.Values
				.Where(x => x.MatchesEnd(start))
				.ToList();
			List<long> result = new();
			for (int i = 0; i < currentLocations.Count; i++)
			{
				Node currentLocation = currentLocations[i];
				long loopSize = Traverse(currentLocation);
				result.Add(loopSize);
			}
			return result;
		}

		private long Traverse(Node start)
		{
			int numberOfMoves = 0;
			Node currentLocation = start;
			while (!currentLocation.Label.EndsWith('Z') || numberOfMoves % Moves.Length != 0)
			{
				string currentMove = Moves[numberOfMoves % Moves.Length].ToString();
				currentLocation = Nodes[currentLocation.Move(currentMove)];
				numberOfMoves++;
			}

			return numberOfMoves;
		}

		private static long GreatestCommonDivider(long a, long b)
		{
			long result = a;
			long remainder = b;
			while (remainder != 0)
			{
				long tmp = remainder;
				remainder = result % remainder;
				result = tmp;
			}
			return result;
		}

		private static long LeastCommonMultiple(List<long> numbers)
		{
			long leastCommonMultiple = 1;

			foreach (long number in numbers)
			{
				leastCommonMultiple = Math.Abs(leastCommonMultiple * number) / GreatestCommonDivider(leastCommonMultiple, number);
			}

			return leastCommonMultiple;
		}
	}
}