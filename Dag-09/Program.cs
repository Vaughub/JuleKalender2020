using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag_09
{
	class Program
	{
		static void Main(string[] args)
		{
			var elfList = File.ReadAllLines("Elfs.txt").Select(l => l.Trim().ToCharArray()).ToArray();

			var days = 0;

			bool spreadContinue;

			do
			{
				var newElfList = new List<char[]>();
				spreadContinue = false;

				for (var y = 0; y < elfList.Length; y++)
				{
					var tableX = new List<char>();
					
					for (var x = 0; x < elfList[y].Length; x++)
					{
						var sickElf = 0;

						if (y + 1 < elfList.Length && elfList[y + 1][x] == 'S') sickElf++;
						if (y - 1 >= 0 && elfList[y - 1][x] == 'S') sickElf++;
						if (x + 1 < elfList[y].Length && elfList[y][x + 1] == 'S') sickElf++;
						if (x - 1 >= 0 && elfList[y][x - 1] == 'S') sickElf++;

						if (sickElf >= 2 && elfList[y][x] == 'F') spreadContinue = true;

						tableX.Add(sickElf >= 2 ? 'S' : elfList[y][x]);
					}

					newElfList.Add(tableX.ToArray());
				}

				days++;
				elfList = newElfList.ToArray();

			} while (spreadContinue);

			Console.WriteLine($"{days} Days");
		}
	}
}
