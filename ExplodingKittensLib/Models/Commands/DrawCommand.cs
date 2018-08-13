
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Commands
{
	public class DrawCommand : ICommand
	{
		public Player CurrentPlayer { get; set; }

		public string Description
		{
			get { return string.Format("\"{0}\": Draw a card from the draw pile.", CommandType); }
		}

		public Enums.Command CommandType
		{
			get { return Enums.Command.Draw; }
		}

		public DrawCommand()
		{
		}

		public DrawCommand(Player player)
		{
			CurrentPlayer = player;
		}

		public ActionResponse Execute()
		{
			return CurrentPlayer.DrawCard();
		}
	}
}
