using System;
using System.IO;
using System.Linq;

namespace Dag_06
{
	class Program
	{
		static void Main(string[] args)
		{
			var candyList = File.ReadAllLines("Candy.txt").First().Split(',').Select(int.Parse).ToArray();


			var sum = candyList.Sum() % (float)candyList.Length;

			//float i = (float)143 % 11;


			var sum1 = (float)(sum) / 11;


			Console.WriteLine();
		}
	}
}
