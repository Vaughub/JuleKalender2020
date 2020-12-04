using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace Dag_03
{
	class Program
	{
		static void Main(string[] args)
		{
			var requestM = new RestRequest("d277d4f01a9fe10f7c1d92e2d17f1b31/raw/49da54e4372a83f4fc11d7137f19fc8b4c58bda6/matrix.txt");
			var matrisa = new RestClient("https://gist.githubusercontent.com/knowitkodekalender/").Execute(requestM).Content;

			var request = new RestRequest("9e1ba20cd879b0c6d7af4ccfe8a87a19/raw/b19ae9548a33a825e2275d0283986070b9b7a126/wordlist.txt");
			var wordList = new RestClient("https://gist.githubusercontent.com/knowitkodekalender/").Execute(request).Content.Split('\n').ToArray();


			foreach (var word in wordList)
			{
				if(matrisa.Contains(word)) Console.WriteLine(word);
			}


			var reverseWordList = wordList.Select(s => s.ToCharArray().Reverse().ToArray()).Select(word => new string(word)).ToList();


			foreach (var word in reverseWordList.Where(word => matrisa.Contains(word)))
			{
				Console.WriteLine(new string(word.ToCharArray().Reverse().ToArray()));
			}


			ReverseString(wordList);


			Console.WriteLine();
		}

		static List<string> ReverseString(IEnumerable<string> stg)
		{
			return stg.Select(s => s.ToCharArray().Reverse().ToArray()).Select(word => new string(word)).ToList();
		}
	}
}
