
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Commands
{
	public class DeselectCommand : ICommand
	{
		public Player CurrentPlayer { get; set; }
		public int CurrentCardIndex { get; set; }

		public string Description
		{
			get { return string.Format("\"{0} <card id>\": Deselect a card.", CommandType); }
		}

		public Enums.Command CommandType
		{
			get { return Enums.Command.Deselect; }
		}

		public DeselectCommand()
		{
		}

		public DeselectCommand(Player player, int index)
		{
			CurrentPlayer = player;
			CurrentCardIndex = index;
		}
        /// <summary>
        /// Prevents the wrong ActionReponse from being done
        /// </summary>
        /// <returns></returns>
		public ActionResponse Execute()
		{
			if (CurrentCardIndex <= 0)
			{
				return new ActionResponse(new Message(Enums.Severity.Error, "You must choose a card to deselect."));
			}

			return CurrentPlayer.DeselectCard(CurrentCardIndex);
		}
	}
}
