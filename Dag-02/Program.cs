using System;
using System.Collections.Generic;
using System.Linq;

namespace Dag_02
{
	class Program
	{
		static void Main(string[] args)
		{
			var presentsDelivered = 0;
			var lastPrime = 0;

			for (int i = 0; i < 5433000; i++)
			{
				if (i.ToString().Contains("7"))
				{
					var prime = FindPrime(lastPrime, i);
					i += prime;
					lastPrime = prime;
					continue;
				}

				presentsDelivered++;
			}

			Console.WriteLine("Gave" + presentsDelivered);
		}

		private static int FindPrime(int min, int max)
		{
			var prime = 0;

			for (var num = min; num <= max; num++)
			{
				var ctr = 0;

				for (var i = 2; i <= num / 2; i++)
				{
					if (num % i != 0) continue;
					ctr++;
					break;
				}

				if (ctr == 0 && num != 1) prime = num;
			}

			return prime;
		}
	}
}
