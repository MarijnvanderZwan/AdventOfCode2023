namespace AdventOfCode._2023.Day06
{
	public static class QuadraticSolver
	{
		public static Solution Solve(double a, double b, double c)
		{
			double discriminant = b * b - 4 * a * c;

			double x1 = (-b - Math.Sqrt(discriminant)) / (2 * a);
			double x2 = (-b + Math.Sqrt(discriminant)) / (2 * a);

			return new Solution(
				(long)Math.Ceiling(x1),
				(long)Math.Floor(x2));
		}
	}
}