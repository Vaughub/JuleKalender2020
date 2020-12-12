using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag_12
{
	class Program
	{
		static void Main(string[] args)
		{
			var familyTree = File.ReadAllLines("FamilyTree.txt").First().Split(' ');

			var generation = 0;

			var list = new List<int>();

			foreach (var elf in familyTree)
			{
				if (elf.Contains("(")) generation++;

				if(generation == list.Count) list.Add(0);
			
				list[generation]++;

				if (elf.Contains(")")) generation -= elf.Count(z => z == ')');
			}

			var (number, index) = list.Select((n, i) => (Number: n, Index: i)).Max();

			Console.WriteLine($"Generation {index} with {number} elfs");
		}
	}
}
