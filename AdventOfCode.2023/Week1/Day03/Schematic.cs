namespace AdventOfCode._2023.Week1.Day03
{
    public sealed record Schematic(char[,] Grid)
    {
        public IEnumerable<NumberResult> GetAllNumbers()
        {
            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                string currentNumber = string.Empty;
                for (int x = 0; x < Grid.GetLength(0); x++)
                {
                    if (char.IsDigit(Grid[x, y]))
                    {
                        currentNumber += Grid[x, y];
                    }
                    else if (currentNumber.Length > 0)
                    {
                        yield return new NumberResult(x - currentNumber.Length, y, int.Parse(currentNumber));
                        currentNumber = "";
                    }
                }

                if (currentNumber.Length > 0)
                {
                    yield return new NumberResult(Grid.GetLength(1) - 1 - currentNumber.Length, y, int.Parse(currentNumber));
                }
            }
        }

        public IEnumerable<int> GetAllEngineParts()
        {
            return GetAllNumbers()
                .Where(IsAdjacentToSymbol)
                .Select(x => x.Number);
        }

        public IEnumerable<int> GetGearRatios()
        {
            List<NumberResult> allNumbers = GetAllNumbers().ToList();
            var gears = GetAllGears();
            foreach ((int x, int y) gear in GetAllGears())
            {
                List<int> adjacentNumbers = GetAdjacentNumbers(gear.x, gear.y, allNumbers).ToList();
                if (adjacentNumbers.Count == 2)
                {
                    yield return adjacentNumbers[0] * adjacentNumbers[1];
                }
            }
        }

        private bool IsAdjacentToSymbol(NumberResult number)
        {
            for (int dx = -1; dx <= number.GetLength(); dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    char c = GetChar(number.X + dx, number.Y + dy);
                    if (c != '.' && !char.IsDigit(c))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static IEnumerable<int> GetAdjacentNumbers(int x, int y, List<NumberResult> numbers)
        {
            foreach (NumberResult number in numbers)
            {
                if (x >= number.X - 1 && x <= number.X + number.GetLength() &&
                    y >= number.Y - 1 && y <= number.Y + 1)
                {
                    yield return number.Number;
                }
            }
        }

        private char GetChar(int x, int y)
        {
            if (x >= 0 && x < Grid.GetLength(0) &&
                y >= 0 && y < Grid.GetLength(1))
            {
                return Grid[x, y];
            }

            return '.';
        }


        private IEnumerable<(int x, int y)> GetAllGears()
        {
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
                {
                    if (Grid[x, y] == '*')
                    {
                        yield return (x, y);
                    }
                }
            }
        }
    }
}