namespace AdventOfCode._2023.Day10
{
	public class InteriorCounter
	{
		public static int Count(string content, string sReplacement)
		{
			string grid = RemoveNonLoopParts(content);
			string processedInput = grid
				.Replace("S", sReplacement)
				.Replace("-", "")
				.Replace("L7", "|")
				.Replace("FJ", "|");

			string[] split = processedInput.Split('\n', StringSplitOptions.TrimEntries);
			int result = 0;
			for (int y = 0; y < split.Length; y++)
			{
				bool isOddNumberOfBarriers = false;
				for (int x = 0; x < split[y].Length; x++)
				{
					char c = split[y][x];
					if (IsVerticalBarrier(c))
					{
						isOddNumberOfBarriers = !isOddNumberOfBarriers;
					}

					if (c == '.' && isOddNumberOfBarriers)
					{
						result++;
					}
				}
			}
			return result;
		}

		private static string RemoveNonLoopParts(string content)
		{
			Diagram diagram = DiagramParser.Parse(content);

			HashSet<Offset> loop = diagram.GetLoop().ToHashSet();

			string total = string.Empty;
			for (int y = 0; y < diagram.Tiles.GetLength(1); y++)
			{
				string line = string.Empty;
				for (int x = 0; x < diagram.Tiles.GetLength(0); x++)
				{
					line += loop.Contains(new Offset(x, y))
						? diagram.Tiles[x, y].C
						: '.';
				}

				total += line + '\n';
			}

			return total;
		}

		private static bool IsVerticalBarrier(char c)
		{
			return c switch
			{
				'|' => true,
				_ => false
			};
		}
	}
}