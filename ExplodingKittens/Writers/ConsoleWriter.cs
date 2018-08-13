using System;

namespace ExplodingKittens.Writers
{
	public class ConsoleWriter : IOutputWriter
	{
		public string Message { get; set; }

		public void Write(string message)
		{
			Message = message;
			Console.Write(message);
		}

		public void WriteLine()
		{
			Console.WriteLine();
		}

		public void WriteLine(string message)
		{
			Message = message;
			Console.WriteLine(message);
		}
	}
}
