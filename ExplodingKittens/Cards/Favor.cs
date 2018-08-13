
using ExplodingKittens.Players;
using System;
namespace ExplodingKittens.Cards
{
	public class Favor : Card
	{
		public Favor(Game game, int id, string tagline)
			: base(game, id, "Favor", tagline, "One player must give you a card of their choice.")
		{
		}

		public override ActionResponse Play()
		{
			throw new NotImplementedException("You need to choose a player to ask a favor from.");
		}

		public override ActionResponse Play(Player player)
		{
			string messageText = string.Format("Player {0} has asked player {1} for a favor.", Game.ActivePlayer.Id, player.Id);

			if (player is NullPlayer)
				throw new ArgumentException("You need to choose a player to ask a favor from.");

			player.IsAskedForFavor = true;

			return new ActionResponse(new Message(Enums.Severity.Info, messageText));
		}
	}
}
