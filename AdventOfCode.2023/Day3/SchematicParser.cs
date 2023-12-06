namespace AdventOfCode._2023.Day3
{
	public static class SchematicParser
	{
		public static Schematic Parse(string content)
		{
			var lines = FileParser.Parse(content);

			var width = lines[0].Trim().Length;
			var height = lines.Count;
			char[,] grid = new char[width, height];
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					grid[x, y] = lines[y][x];
				}
			}

			return new Schematic(grid);
		}
		
	}
}