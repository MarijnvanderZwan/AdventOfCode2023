using AdventOfCode._2023.Day02;
using FluentAssertions;
using FluentAssertions.Execution;

namespace AdventOfCode._2023
{
	[TestFixture]
	public class TestDay02
	{
		[Test]
		public void Parsing_Should_GiveCorrectNumberOfGameResults()
		{
			GameResult result = GameParser.Parse(Resources.Resources.Day02);

			result.Games.Should().HaveCount(100);
		}

		[Test]
		public void Parsing_Should_GiveCorrectGameResults()
		{
			GameResult result = GameParser.Parse(Resources.Resources.Day02);

			using (new AssertionScope())
			{
				result.Games[0].Label.Should().Be(1);
				result.Games[0].Cubes.Should().HaveCount(6);

				result.Games[0].Cubes[0].NumberOfRed.Should().Be(5);
				result.Games[0].Cubes[0].NumberOfGreen.Should().Be(1);
				result.Games[0].Cubes[0].NumberOfBlue.Should().Be(0);

				result.Games[0].Cubes[1].NumberOfRed.Should().Be(6);
				result.Games[0].Cubes[1].NumberOfGreen.Should().Be(0);
				result.Games[0].Cubes[1].NumberOfBlue.Should().Be(3);
			}
		}

		[TestCase(0, 0, 0, false)]
		[TestCase(10, 10, 10, true)]
		[TestCase(10, 10, 0, false)]
		[TestCase(10, 0, 10, false)]
		[TestCase(0, 10, 10, false)]
		[TestCase(6, 7, 8, true)]
		public void WasPossibleWithNumberOfMoves_Should_GiveCorrectResult(
			int numberOfRed, int numberOfGreen, int numberOfBlue, bool expectedResult)
		{
			Game game = new(1,
				new List<Cubes>
				{
					new Cubes(1, 2, 3),
					new Cubes(3, 2, 1),
					new Cubes(6, 7, 8),
					new Cubes(0, 0, 0),
				});

			bool actualResult = game.WasPossibleWithNumberOfCubes(new Cubes(numberOfRed, numberOfGreen, numberOfBlue));

			actualResult.Should().Be(expectedResult);
		}

		[Test]
		public void SumOfExampleGames_Should_GiveCorrectResult()
		{
			const int numberOfRed = 12;
			const int numberOfGreen = 13;
			const int numberOfBlue = 14;
			GameResult games = GetExampleGames();

			int sum = games.GetSumOfPossibleGames(new Cubes(numberOfRed, numberOfGreen, numberOfBlue));

			sum.Should().Be(8);
		}

		[Test]
		public void SumOfPossibleGames_Should_GiveCorrectResult()
		{
			const int numberOfRed = 12;
			const int numberOfGreen = 13;
			const int numberOfBlue = 14;
			GameResult games = GameParser.Parse(Resources.Resources.Day02);

			int result = games.GetSumOfPossibleGames(new Cubes(numberOfRed, numberOfGreen, numberOfBlue));

			result.Should().Be(1867);
		}

		[TestCase(4, 2, 6, 48)]
		[TestCase(1, 3, 4, 12)]
		[TestCase(20, 13, 6, 1560)]
		[TestCase(14, 3, 15, 630)]
		[TestCase(6, 3, 2, 36)]
		public void GetPower_Should_GiveCorrectResult(
			int numberOfRed, int numberOfGreen, int numberOfBlue, int expectedPower)
		{
			Cubes cubes = new(numberOfRed, numberOfGreen, numberOfBlue);

			int power = cubes.GetPower();

			power.Should().Be(expectedPower);
		}


		[Test]
		public void Answer1_GetMinimalNumberOfCubesForExampleGames_Should_GiveCorrectResult()
		{
			GameResult games = GetExampleGames();

			int result = games.GetSumOfMinimalPowers();

			using (new AssertionScope())
			{
				result.Should().Be(2286);
			}
		}

		[Test]
		public void Answer2_SumsOfPowers_Should_GiveCorrectResult()
		{
			GameResult games = GameParser.Parse(Resources.Resources.Day02);

			int sum = games.GetSumOfMinimalPowers();

			sum.Should().Be(84538);
		}

		private static GameResult GetExampleGames()
		{
			List<Game> games = new()
			{
				GetExampleGame1(),
				GetExampleGame2(),
				GetExampleGame3(),
				GetExampleGame4(),
				GetExampleGame5()
			};
			return new GameResult(games);
		}

		private static Game GetExampleGame1()
		{
			return new Game(1, new List<Cubes>
			{
				new Cubes(4, 0, 3),
				new Cubes(1, 2, 6),
				new Cubes(0, 2, 0),
			});
		}

		private static Game GetExampleGame2()
		{
			return new Game(2, new List<Cubes>
			{
				new Cubes(0, 2, 1),
				new Cubes(1, 3, 4),
				new Cubes(0, 1, 1)
			});
		}

		private static Game GetExampleGame3()
		{
			return new Game(3, new List<Cubes>
			{
				new Cubes(20, 8, 6),
				new Cubes(4, 13, 5),
				new Cubes(1, 5, 0)
			});
		}

		private static Game GetExampleGame4()
		{
			return new Game(4, new List<Cubes>
			{
				new Cubes(3, 1, 6),
				new Cubes(6, 3, 0),
				new Cubes(14, 3, 15)
			});
		}

		private static Game GetExampleGame5()
		{
			return new Game(5, new List<Cubes>
			{
				new Cubes(6, 3, 1),
				new Cubes(1, 2, 2)
			});
		}
	}
}