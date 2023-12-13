namespace AdventOfCode._2023.Week1.Day02
{
    public static class GameParser
    {
        public static GameResult Parse(string content)
        {
            List<Game> games = FileParser.Parse(content, ParseFromLine);
            return new GameResult(games);
        }

        private static Game ParseFromLine(string line)
        {
            string[] split = line.Split(':');
            int label = int.Parse(split[0][5..]);
            string[] cubes = split[1].Split(';');
            IEnumerable<Cubes> parsedCubes = cubes.Select(ParseCubes);
            return new Game(label, parsedCubes.ToList());
        }

        private static Cubes ParseCubes(string move)
        {
            string[] split = move.Trim().Split(", ");

            int red = split.Where(s => s.EndsWith("red"))
                .Select(ParseCube)
                .Sum();
            int green = split.Where(s => s.EndsWith("green"))
                .Select(ParseCube)
                .Sum();
            int blue = split.Where(s => s.EndsWith("blue"))
                .Select(ParseCube)
                .Sum();
            return new Cubes(red, green, blue);
        }

        private static int ParseCube(string numberOfCubes)
        {
            return int.Parse(numberOfCubes.Trim().Split(' ')[0]);
        }
    }
}