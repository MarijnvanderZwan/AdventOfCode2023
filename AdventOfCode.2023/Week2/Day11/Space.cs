namespace AdventOfCode._2023.Week2.Day11
{
	public class Space
	{
		public Space(List<Galaxy> galaxies, List<int> emptyColumns, List<int> emptyRows, int emptyValue)
		{
			Galaxies = galaxies;
			EmptyColumns = emptyColumns;
			EmptyRows = emptyRows;
			EmptyValue = emptyValue;
		}

		public List<Galaxy> Galaxies { get; }
		public List<int> EmptyColumns { get; }
		public List<int> EmptyRows { get; }
		public int EmptyValue { get; }

		public long GetSumOfShortestRoutes(Space space)
		{
			List<long> shortestRoutes = new();

			HashSet<(int, int)> pairs = new();

			for (int i = 0; i < space.Galaxies.Count; i++)
			{
				Galaxy fromGalaxy = space.Galaxies[i];
				for (int j = 0; j < space.Galaxies.Count; j++)
				{
					var toGalaxy = space.Galaxies[j];
					if (!pairs.Contains((fromGalaxy.Label, toGalaxy.Label)))
					{
						long distance = space.GetDistance(fromGalaxy, toGalaxy);
						shortestRoutes.Add(distance);
						pairs.Add((fromGalaxy.Label, toGalaxy.Label));
						pairs.Add((toGalaxy.Label, fromGalaxy.Label));
					}
				}
			}

			return shortestRoutes.Sum();
		}

		public int GetDistance(Galaxy from, Galaxy to)
		{
			int columnValue = GetColumnValue(from.X, to.X, EmptyValue);
			int rowValue = GetRowValue(from.Y, to.Y, EmptyValue);
			return columnValue + rowValue;
		}

		private int GetColumnValue(int from, int to, int value)
		{
			int min = Math.Min(from, to);
			int max = Math.Max(from, to);
			int emptyColumns = EmptyColumns
				.Count(c => c > min && c < max);
			int nonEmptyColumns = max - min - emptyColumns;
			return nonEmptyColumns + emptyColumns * value;
		}

		private int GetRowValue(int from, int to, int value)
		{
			int min = Math.Min(from, to);
			int max = Math.Max(from, to);
			int emptyRows = EmptyRows
				.Count(c => c > min && c < max);
			int nonEmptyColumns = max - min - emptyRows;
			return nonEmptyColumns + emptyRows * value;
		}
	}
}