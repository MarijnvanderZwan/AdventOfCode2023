namespace AdventOfCode._2023.Week1.Day03
{
    public record NumberResult(int X, int Y, int Number)
    {
        public int GetLength()
        {
            return Number.ToString().Length;
        }
    }
}