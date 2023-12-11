namespace AdventOfCode._2023.Day10
{
	public static class DiagramParser
	{
		public static Diagram Parse(string content)
		{
			string[] lines = content.Split("\n", StringSplitOptions.TrimEntries);

			int width = lines[0].Length;
			int height = lines.Length;
			Tile? start = null;
			Tile[,] tiles = new Tile[width, height];
			for (int y = 0; y < lines.Length; y++)
			{
				for (int x = 0; x < width; x++)
				{
					tiles[x, y] = Parse(x, y, lines[y][x]);
					if (tiles[x, y].IsStart)
					{
						start = tiles[x, y];
					}
				}
			}

			if (start != null)
			{
				tiles[start.X, start.Y] = GetStartWithConnections(start, tiles);
			}
			return new Diagram(tiles);
		}

		private static Tile GetStartWithConnections(Tile start, Tile[,] tiles)
		{
			var connections = new List<Offset>();
			var candidates = new List<Offset>()
			{
				new Offset(1, 0),
				new Offset(-1, 0),
				new Offset(0, -1),
				new Offset(0, 1)
			};
			foreach (var candidate in candidates)
			{
				int x = start.X + candidate.X;
				int y = start.Y + candidate.Y;
				if (x >= 0 && x < tiles.GetLength(0) &&
				    y >= 0 && y < tiles.GetLength(1) &&
				    tiles[x, y].IsConnectedTo(start.X, start.Y))
				{
					connections.Add(new Offset(candidate.X, candidate.Y));
				}
			}
			return new Tile(start.C, start.X, start.Y, true, connections);
		}

		public static Tile Parse(int x, int y, char c)
		{
			return c switch
			{
				'|' => new Tile(c, x, y, false, new List<Offset> { new Offset(0,  -1), new Offset(0, 1)}),
				'-' => new Tile(c, x, y, false, new List<Offset> { new Offset(1,  0), new Offset(-1, 0) }),
				'L' => new Tile(c, x, y, false, new List<Offset> { new Offset(0,  -1), new Offset( 1, 0) }),
				'J' => new Tile(c, x, y, false, new List<Offset> { new Offset(0,  -1), new Offset(-1, 0) }),
				'7' => new Tile(c, x, y, false, new List<Offset> { new Offset(0, 1), new Offset(-1, 0)}),
				'F' => new Tile(c, x, y, false, new List<Offset> { new Offset(0, 1), new Offset( 1, 0) }),
				'.' => new Tile(c, x, y, false, new List<Offset>()),
				'S' => new Tile(c, x, y, true, new List<Offset>()),
				_ => throw new InvalidOperationException($"Cannot parse tile {c}")
			};
		}
	}
}