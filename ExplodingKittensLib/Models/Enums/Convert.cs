
namespace ExplodingKittensLib.Models.Enums
{
	public static class Convert
	{
		public static Command Command(string command)
		{
			switch (command)
			{
				case "hand":
					return Enums.Command.Hand;
				case "draw":
					return Enums.Command.Draw;
				case "select":
					return Enums.Command.Select;
				case "deselect":
					return Enums.Command.Deselect;
				case "play":
					return Enums.Command.Play;
				case "give":
					return Enums.Command.Give;
				case "deck":
					return Enums.Command.Deck;
				case "status":
					return Enums.Command.Status;
				case "help":
					return Enums.Command.Help;
				case "quit":
					return Enums.Command.Quit;
				default:
					return Enums.Command.Unknown;
			}
		}
	}
}
