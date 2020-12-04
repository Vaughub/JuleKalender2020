using System;
using System.Linq;
using RestSharp;

namespace Dag_04
{
	class Program
	{
		static void Main(string[] args)
		{
			var requestM = new RestRequest("leveringsliste.txt");
			var response = new RestClient("https://julekalender-backend.knowit.no/challenges/4/attachments/").Execute(requestM).Content;

			var ingredient = response.Split('\n')
				.Select(s => s.Split(", ").Select(s2 => s2.Split(": "))
					.Select(s3 => new { Ingredient = s3.First(), Quantity = int.Parse(s3.Last()) }))
				.SelectMany(l => l)
				.Aggregate(new { Sugar = 0, Milk = 0, Egg = 0, Flour = 0 }, (total, next) => new
				{
					Sugar = next.Ingredient == "sukker" ? total.Sugar + next.Quantity : total.Sugar,
					Milk = next.Ingredient == "melk" ? total.Milk + next.Quantity : total.Milk,
					Egg = next.Ingredient == "egg" ? total.Egg + next.Quantity : total.Egg,
					Flour = next.Ingredient == "mel" ? total.Flour + next.Quantity : total.Flour
				});

			var cakeBaked = Lowest(ingredient.Sugar / 2, ingredient.Milk / 3, ingredient.Flour / 3, ingredient.Egg);

			Console.WriteLine($"Number of cake baked is {cakeBaked}");
		}

		public static int Lowest(params int[] inputs)
		{
			return inputs.Min();
		}
	}
}


//var strings = response.Split('\n');

//var sugar = 0;
//var flour = 0;
//var milk = 0;
//var egg = 0;

//foreach (var t1 in strings)
//{
//	var line = t1.Split(',');

//	foreach (var t in line)
//	{
//		if (t.Contains("melk")) milk += int.Parse(t.Split(':')[1]);
//		else if (t.Contains("egg")) egg += int.Parse(t.Split(':')[1]);
//		else if (t.Contains("mel")) flour += int.Parse(t.Split(':')[1]);
//		else if (t.Contains("sukker")) sugar += int.Parse(t.Split(':')[1]);
//		else throw new Exception("Error");
//	}
//}

//sugar /= 2;
//flour /= 3;
//milk /= 3;

//var cakeBaked = Lowest(sugar, flour, milk, egg);

//Console.WriteLine($"Number of cake baked is {cakeBaked}");