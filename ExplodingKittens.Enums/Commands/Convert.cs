
namespace ExplodingKittens.Enums.Commands
{
	public static class Convert
	{
		public static Command Command(string command)
		{
			switch (command)
			{
				case "hand":
					return Commands.Command.Hand;
				case "draw":
					return Commands.Command.Draw;
				case "select":
					return Commands.Command.Select;
				case "deselect":
					return Commands.Command.Deselect;
				case "play":
					return Commands.Command.Play;
				case "give":
					return Commands.Command.Give;
				case "deck":
					return Commands.Command.Deck;
				case "status":
					return Commands.Command.Status;
				case "help":
					return Commands.Command.Help;
				case "quit":
					return Commands.Command.Quit;
				default:
					return Commands.Command.Unknown;
			}
		}
	}
}
