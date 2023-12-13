namespace AdventOfCode._2023.Week2.Day10
{
	public record Diagram(Tile[,] Tiles)
	{
		public Tile GetStart()
		{
			for (int x = 0; x < Tiles.GetLength(0); x++)
			{
				for (int y = 0; y < Tiles.GetLength(1); y++)
				{
					if (Tiles[x, y].IsStart)
					{
						return Tiles[x, y];
					}
				}
			}
			return null;
		}

		public List<Offset> GetLoop()
		{
			var result = new List<Offset>();
			var start = GetStart();
			int previousX = start.X;
			int previousY = start.Y;
			var nextX = start.X + start.Connections.First().X;
			var nextY = start.Y + start.Connections.First().Y;
			while (!(nextX == start.X && nextY == start.Y))
			{
				result.Add(new Offset(nextX, nextY));
				Offset next = Tiles[nextX, nextY].GetNext()
					.First(x => x.X != previousX || x.Y != previousY);
				previousX = nextX;
				previousY = nextY;
				nextX = next.X;
				nextY = next.Y;
			}

			result.Add(new Offset(nextX, nextY));
			return result;
		}
	}
}