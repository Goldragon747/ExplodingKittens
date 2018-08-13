namespace ExplodingKittensLib.Models
{
	public class Message
	{
		public Enums.Severity Severity { get; set; }
		public string Text { get; set; }

		public Message(Enums.Severity severity, string text)
		{
			Severity = severity;
			Text = text;
		}
	}
}
