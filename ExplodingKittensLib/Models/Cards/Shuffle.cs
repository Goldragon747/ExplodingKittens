
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public class Shuffle : Card
	{
		public Shuffle(Game game, int id, string tagline)
			: base(game, id, "Shuffle", tagline, "Shuffle the draw pile.")
		{
		}

        public Shuffle(Game game, int id)
    : base(game, id, "Shuffle", "Shuffle the draw pile.")
        {
        }

        /// <summary>the deck has been shuffled
        /// Informs the player 
        /// </summary>
        /// <returns></returns>
		public override ActionResponse Play()
		{
			Game.Deck.Shuffle();

			return new ActionResponse(new Message(Enums.Severity.Info, string.Format("Deck shuffled by player {0}.", Game.ActivePlayer.Id)));
		}
        /// <summary>
        /// Prevents the wrong ActionReponse from being done
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException("You can't play a shuffle on another player.");
		}
	}
}
