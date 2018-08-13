namespace ExplodingKittensLib.Models.Writers
{
	public class MemoryWriter : IOutputWriter
	{
		public string Message { get; set; }

		public void Write(string message)
		{
			Message += message;
		}

		public void WriteLine()
		{
			Message += "\n";
		}

		public void WriteLine(string message)
		{
			Message += string.Format("{0}\n", message);
		}
	}
}
