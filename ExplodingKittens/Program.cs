using System;

namespace ExplodingKittens
{
	public class Program
	{
		public static void Main(string[] args)
		{
			new GameLoop().Setup();
			Console.ReadKey();
		}
	}
}
