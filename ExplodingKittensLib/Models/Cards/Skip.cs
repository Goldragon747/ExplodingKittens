
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public class Skip : Card
	{
		public Skip(Game game, int id, string tagLine)
			: base(game, id, "Skip", tagLine, "End your turn without drawing a card")
		{
		}

        public Skip(Game game, int id)
    : base(game, id, "Skip", "End your turn without drawing a card")
        {
        }

        /// <summary>
        /// Informs that a player has been skipped
        /// Changes who the active player is
        /// </summary>
        /// <returns></returns>
		public override ActionResponse Play()
		{
			string messageText = string.Format("Player {0}'s turn was skipped.", Game.NextPlayer.Id);

            if (Game.GetType() == typeof(ConsoleGame))
            {
			    Game.NextPlayer.IsActive = true;
			    Game.ActivePlayer.IsActive = false;
            }

			return new ActionResponse(new Message(Enums.Severity.Info, messageText));
		}
        /// <summary>
        /// Prevents the wrong ActionReponse from being done
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException("You can't play a skip on another player.");
		}
	}
}
