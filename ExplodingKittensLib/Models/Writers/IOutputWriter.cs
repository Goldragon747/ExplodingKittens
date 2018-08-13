
namespace ExplodingKittensLib.Models.Writers
{
	public interface IOutputWriter
	{
		string Message { get; set; }

		void Write(string message);
		void WriteLine();
		void WriteLine(string message);
	}
}
