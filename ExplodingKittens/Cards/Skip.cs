
using ExplodingKittens.Players;

namespace ExplodingKittens.Cards
{
	public class Skip : Card
	{
		public Skip(Game game, int id, string tagLine)
			: base(game, id, "Skip", tagLine, "End your turn without drawing a card")
		{
		}

		public override ActionResponse Play()
		{
			string messageText = string.Format("Player {0}'s turn was skipped.", Game.NextPlayer.Id);

			Game.NextPlayer.IsActive = true;
			Game.ActivePlayer.IsActive = false;

			return new ActionResponse(new Message(Enums.Severity.Info, messageText));
		}

		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException("You can't play a skip on another player.");
		}
	}
}
