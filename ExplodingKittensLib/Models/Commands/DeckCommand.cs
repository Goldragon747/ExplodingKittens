
namespace ExplodingKittensLib.Models.Commands
{
	public class DeckCommand : ICommand
	{
		public Deck Deck { get; set; }

		public string Description
		{
			get
			{
				return string.Format("\"{0}\": List the cards in the draw pile and the play pile (the deck).", CommandType);
			}
		}

		public Enums.Command CommandType
		{
			get { return Enums.Command.Deck; }
		}

		public DeckCommand()
		{
		}

		public DeckCommand(Deck deck)
		{
			Deck = deck;
		}

		public ActionResponse Execute()
		{
			return Deck.Print();
		}
	}
}
