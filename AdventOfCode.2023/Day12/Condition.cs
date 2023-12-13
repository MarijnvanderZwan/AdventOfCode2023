using System.Collections.Immutable;

namespace AdventOfCode._2023.Day12
{
	public record Condition(string Record, ImmutableStack<int> Values)
	{
		public static Condition Create(string record, IEnumerable<int> values)
		{
			return new Condition(record, ImmutableStack.CreateRange(values.Reverse()));
		}

		public Condition ConsumeOperational()
		{
			return new Condition(Record[1..], Values);
		}

		public Condition ConsumeValue()
		{
			int value = Values.Peek();
			return new Condition(Record[(value + 1)..], Values.Pop());
		}

		public Condition BranchOperational()
		{
			return new Condition('.' + Record[1..], Values);
		}

		public Condition BranchDamaged()
		{
			return new Condition('#' + Record[1..], Values);
		}
	}
}