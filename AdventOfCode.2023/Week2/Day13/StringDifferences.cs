namespace AdventOfCode._2023.Week2.Day13
{
	public static class StringDifferences
	{
		public static int GetNumberOfDifferences(string s1, string s2)
		{
			int differences = 0;

			for (int i = 0; i < s1.Length; i++)
			{
				if (s1[i] != s2[i])
				{
					differences++;
				}
			}

			return differences;
		}
	}
}