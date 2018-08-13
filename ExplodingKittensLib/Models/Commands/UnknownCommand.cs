
namespace ExplodingKittensLib.Models.Commands
{
	public class UnknownCommand : ICommand
	{
		public UnknownCommand()
		{
		}

		public string Description
		{
			get { return string.Format("\"{0}\": An unknown command.", CommandType); }
		}

		public Enums.Command CommandType
		{
			get { return Enums.Command.Unknown; }
		}

		public ActionResponse Execute()
		{
			return new ActionResponse(new Message(Enums.Severity.Error, "Command not supported."));
		}
	}
}
