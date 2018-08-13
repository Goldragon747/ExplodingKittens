
using ExplodingKittens.Players;

namespace ExplodingKittens.Commands
{
	public class HandCommand : ICommand
	{
		public Player CurrentPlayer { get; set; }

		public string Description
		{
			get { return string.Format("\"{0}\": List the current player's hand.", CommandType); }
		}

		public Enums.Commands.Command CommandType
		{
			get { return Enums.Commands.Command.Hand; }
		}

		public HandCommand()
		{
		}

		public HandCommand(Player player)
		{
			CurrentPlayer = player;
		}

		public ActionResponse Execute()
		{
			ActionResponse res = new ActionResponse();
			res.AddMessage(CurrentPlayer.Hand.ToString());
			return res;
		}
	}
}
