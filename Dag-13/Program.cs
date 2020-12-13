using System;
using System.Collections.Generic;
using System.IO;

namespace Dag_13
{
	class Program
	{
		static void Main(string[] args)
		{
			var input = File.ReadAllText("Input.txt");

			for (var i = 0; i < 26; i++)
			{
				var allIndexOf = AllIndexOf(input, (char)(97 + i));

				for (var j = allIndexOf.Count - 1; j >= 0; j--)
				{
					if (j == i) continue;
					input = input.Remove(allIndexOf[j], 1);
				}
			}

			Console.WriteLine(input);
		}

		public static IList<int> AllIndexOf(string text, char str)
		{
			IList<int> allIndexOf = new List<int>();
			int index = text.IndexOf(str);

			while (index != -1)
			{
				allIndexOf.Add(index);
				index = text.IndexOf(str, index + 1);
			}

			return allIndexOf;
		}
	}
}
