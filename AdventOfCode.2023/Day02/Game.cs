namespace AdventOfCode._2023.Day02
{
    public record Game(int Label, List<Cubes> Cubes)
    {
        public bool WasPossibleWithNumberOfCubes(Cubes cubes)
        {
            return Cubes.All(
                move => move.NumberOfRed <= cubes.NumberOfRed &&
                        move.NumberOfGreen <= cubes.NumberOfGreen &&
                        move.NumberOfBlue <= cubes.NumberOfBlue);
        }

        public Cubes GetMinimalNumberOfCubes()
        {
            int minRed = Cubes.Select(m => m.NumberOfRed).DefaultIfEmpty(0).Max();
            int minGreen = Cubes.Select(m => m.NumberOfGreen).DefaultIfEmpty(0).Max();
            int minBlue = Cubes.Select(m => m.NumberOfBlue).DefaultIfEmpty(0).Max();
            return new Cubes(minRed, minGreen, minBlue);
        }
    }
}