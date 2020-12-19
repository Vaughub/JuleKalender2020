using System;
using System.Collections.Generic;

namespace Dag_14
{
	class Program
	{
		static void Main(string[] args)
		{
			var sequence = new List<int> {0, 1};

			for (int i = 2; i < 15; i++)
			{
				if (sequence[i - 2] - i > 0 && !sequence.Contains(sequence[i - 2] - i)) sequence.Add(sequence[i - 2] - i);
				if (sequence[i - 2] + i > 0 && !sequence.Contains(sequence[i - 2] + i)) sequence.Add(sequence[i - 2] + i);
			}

			Console.WriteLine();
		}
	}
}
