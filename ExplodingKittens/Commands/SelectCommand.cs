
using ExplodingKittens.Players;

namespace ExplodingKittens.Commands
{
	public class SelectCommand : ICommand
	{
		public Player CurrentPlayer { get; set; }
		public int CurrentCardIndex { get; set; }

		public string Description
		{
			get { return string.Format("\"{0} <card id>\": Select the given card.", CommandType); }
		}

		public Enums.Commands.Command CommandType
		{
			get { return Enums.Commands.Command.Select; }
		}

		public SelectCommand()
		{
		}

		public SelectCommand(Player player, int index)
		{
			CurrentPlayer = player;
			CurrentCardIndex = index;
		}

		public ActionResponse Execute()
		{
			return CurrentPlayer.SelectCard(CurrentCardIndex);
		}
	}
}
