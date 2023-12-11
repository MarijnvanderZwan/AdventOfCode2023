namespace AdventOfCode._2023.Day10
{
	public record Tile(char C, int X, int Y, bool IsStart, List<Offset> Connections)
	{
		public bool IsConnectedTo(int x, int y)
		{
			return Connections.Any(connection => X + connection.X == x &&
			                                     Y + connection.Y == y);
		}

		public List<Offset> GetNext()
		{
			return Connections
				.Select(c => new Offset(X + c.X, Y + c.Y))
				.ToList();
		}
	}
}