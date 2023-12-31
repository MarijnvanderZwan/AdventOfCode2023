﻿namespace AdventOfCode._2023.Week1.Day02
{
    public record GameResult(List<Game> Games)

    {
        public int GetSumOfPossibleGames(Cubes cubes)
        {
            return Games
                .Where(game => game.WasPossibleWithNumberOfCubes(cubes))
                .Select(game => game.Label)
                .Sum();
        }

        public int GetSumOfMinimalPowers()
        {
            return Games
                .Select(game => game.GetMinimalNumberOfCubes())
                .Select(cubes => cubes.GetPower())
                .Sum();
        }
    }
}