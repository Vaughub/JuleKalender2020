using System;
using System.Linq;
using RestSharp;

namespace Dag_01
{
	class Program
	{
		static void Main(string[] args)
		{
			var request = new RestRequest("1/attachments/numbers.txt");
			var response = new RestClient("https://julekalender-backend.knowit.no/challenges/").Execute(request);

			var numberList = response.Content.Split(',').Select(int.Parse);

			var result = Enumerable.Range(1, 100000).Except(numberList).First();

			Console.WriteLine($"Missing number is {result}");
		}
	}
}
