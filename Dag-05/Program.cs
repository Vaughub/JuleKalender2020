using System;
using System.IO;
using System.Linq;

namespace Dag_05
{
	class Program
	{
		static void Main(string[] args)
		{
			var route = File.ReadAllLines("Route.txt").First();
			string[][] board = new string[1000][];

			for (int i = 0; i < board.Length; i++)
			{
				board[i] = new string[1000];
			}
			
			var yCord = 500;
			var xCord = 500;
			var prev = ' ';

			foreach (var letter in route)
			{
				if (letter == 'H')
				{
					if (prev == 'O') yCord--;
					else if (prev == 'N') yCord++;
					xCord++;
				}
				else if (letter == 'O')
				{
					if (prev == 'H') xCord++;
					else if (prev == 'V') xCord--;
					yCord--;
				}
				else if (letter == 'V')
				{
					if (prev == 'O') yCord--;
					else if (prev == 'N') yCord++;
					xCord--;
				}
				else if (letter == 'N')
				{
					if (prev == 'H') xCord++;
					else if (prev == 'V') xCord--;
					yCord++;
				}

				prev = letter;
				board[yCord][xCord] = "X";
			}

			foreach (var t in board)
			{
				foreach (var t1 in t)
				{
					Console.Write(t1 ?? " ");
				}

				Console.WriteLine();
			}
		}
	}
}
