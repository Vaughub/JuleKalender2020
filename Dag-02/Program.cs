using System;

namespace Dag_02
{
	class Program
	{
		static void Main(string[] args)
		{
			var presentsDelivered = 0;

			for (int i = 0; i < 5433000; i++)
			{
				if (i.ToString().Contains("7"))
				{
					var prime = FindPrime(i);
					i += prime;
					continue;
				}

				presentsDelivered++;
			}
			
			Console.WriteLine($"Nissen leverte {presentsDelivered} gaver");
		}

		private static int FindPrime(int presentNr)
		{
			for (int i = 2; i < presentNr / 2; i++)
			{
				if (presentNr % i == 0) return FindPrime(presentNr - 1);
			}

			return presentNr;
		}
	}
}
