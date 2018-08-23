
using ExplodingKittensLib.Models.Players;
using System;
namespace ExplodingKittensLib.Models.Cards
{
	public class Favor : Card
	{
		public Favor(Game game, int id, string tagline)
			: base(game, id, "Favor", tagline, "One player must give you a card of their choice.")
		{
		}

        public Favor(Game game, int id)
    : base(game, id, "Favor", "One player must give you a card of their choice.")
        {
        }

        /// <summary>
        /// Prevents the wrong ActionReponse from being done
        /// </summary>
        /// <returns></returns>
		public override ActionResponse Play()
		{
			throw new NotImplementedException("You need to choose a player to ask a favor from.");
		}
        /// <summary>
        /// Informs the players who asked for the favor
        /// Prevents the player from not picking someone
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
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
