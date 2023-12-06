namespace AdventOfCode._2023.Day2
{
    public record Cubes(int NumberOfRed, int NumberOfGreen, int NumberOfBlue)
    {
        public int GetPower()
        {
            return NumberOfRed * NumberOfGreen * NumberOfBlue;
        }
    }
}