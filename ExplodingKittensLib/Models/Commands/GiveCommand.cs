
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Commands
{
	public class GiveCommand : ICommand
	{
		public Game Game { get; set; }
		public Player CurrentPlayer { get; set; }
		public int CurrentTargetPlayerIndex { get; set; }

		public string Description
		{
			get
			{
				return string.Format("\"{0} <player id>\": Give the selected card to the chosen player.", CommandType);
			}
		}

		public Enums.Command CommandType
		{
			get { return Enums.Command.Give; }
		}

		public GiveCommand()
		{
		}

		public GiveCommand(Game game, Player player, int index)
		{
			Game = game;
			CurrentPlayer = player;
			CurrentTargetPlayerIndex = index;
		}

		public ActionResponse Execute()
		{
			return CurrentPlayer.GiveCard(CurrentPlayer.Hand.SelectedCard, Game.GetSelectedPlayer(CurrentTargetPlayerIndex));
		}
	}
}
