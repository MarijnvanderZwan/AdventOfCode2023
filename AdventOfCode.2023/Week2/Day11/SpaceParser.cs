namespace AdventOfCode._2023.Week2.Day11
{
	public static class SpaceParser
	{
		public static Space ParseV2(string input, int emptyValue)
		{
			string[] split = input.Split('\n', StringSplitOptions.TrimEntries);
			var columnsWithoutGalaxies = Enumerable.Range(0, split[0].Length)
				.Where(i => split.All(s => s[i] == '.'))
				.ToList();
			var rowsWithoutGalaxies = Enumerable.Range(0, split.Length)
				.Where(i => split[i].All(c => c == '.'))
				.ToList();
			int i = 0;
			var galaxies = new List<Galaxy>();
			for (int y = 0; y < split.Length; y++)
			{
				for (int x = 0; x < split[0].Length; x++)
				{
					if (split[y][x] == '#')
					{
						galaxies.Add(new Galaxy(i++, x, y));
					}
				}
			}

			return new Space(galaxies, columnsWithoutGalaxies, rowsWithoutGalaxies, emptyValue);
		}
	}
}