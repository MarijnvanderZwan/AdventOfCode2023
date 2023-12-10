namespace AdventOfCode._2023.Day08
{
	public static class MapsParser
	{
		public static Maps Parse(string content)
		{
			string[] split = content.Split('\n', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

			string moves = split[0];
			IEnumerable<Node> nodes = split.Skip(1).Select(ParseNode);
			return new Maps(nodes, moves);
		}

		private static Node ParseNode(string line)
		{
			List<string> split = line.Split('=', '(', ',', ')')
				.Where(s => !string.IsNullOrWhiteSpace(s))
				.ToList();
			return new Node(split[0].Trim(), split[1].Trim(), split[2].Trim());
		}
	}
}