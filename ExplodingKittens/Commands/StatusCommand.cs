
using ExplodingKittens.Players;

namespace ExplodingKittens.Commands
{
	public class StatusCommand : ICommand
	{
		public Player CurrentPlayer { get; set; }

		public string Description
		{
			get { return string.Format("\"{0}\": List the current player's status.", CommandType); }
		}

		public Enums.Commands.Command CommandType
		{
			get { return Enums.Commands.Command.Status; }
		}

		public StatusCommand()
		{
		}

		public StatusCommand(Player player)
		{
			CurrentPlayer = player;
		}

		public ActionResponse Execute()
		{
			return CurrentPlayer.GetStatus();
		}
	}
}
