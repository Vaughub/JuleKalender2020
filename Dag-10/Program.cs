using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dag_10
{
	class Program
	{
		static void Main(string[] args)
		{
			var participants = File.ReadAllLines("Participants.txt");

			var scoreTable = new Dictionary<string, int>();

			foreach (var cont in participants)
			{
				var players = cont.Split(',');

				for (var i = 0; i < players.Length; i++)
				{
					var score = players.Length - (i + 1);

					if (scoreTable.ContainsKey(players[i])) scoreTable[players[i]] += score;
					else scoreTable.Add(players[i], score);
				}
			}

			var (key, value) = scoreTable.OrderByDescending(e => e.Value).First();

			Console.WriteLine($"{key}-{value}");
		}
	}
}
