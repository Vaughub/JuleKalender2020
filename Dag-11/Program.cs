using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag_11
{
	class Program
	{
		static void Main(string[] args)
		{
			var hint = File.ReadAllLines("Words.txt");

			foreach (var t in hint)
			{
				UpEverything(t);
			}
		}

		private static void UpEverything(string word)
		{
			var listWord = new List<string> {word};

			do
			{
				var arrayWord = word.ToCharArray();

				var upWord = arrayWord.Skip(1).Aggregate("", (current, c) => current + (char)(c + 1)).ToCharArray();
				var newWord = "";

				for (var j = 0; j < upWord.Length; j++)
				{
					newWord += (char)(((arrayWord[j] - 1) % 32 + (upWord[j] - 1) % 32) % 26 + 97);
				}

				listWord.Add(newWord);
				word = newWord;

			} while (word.Length > 1);

			var passList = new List<string>();

			for (var i = 0; i < listWord.Count; i++)
			{
				passList.Add(listWord.Aggregate("", (current, stg) => stg.Length > i ? current + stg.Substring(i, 1) : current));
			}

			if(passList.Exists(s => s.Contains("eamqia"))) Console.WriteLine(listWord.First());
		}
	}
}
