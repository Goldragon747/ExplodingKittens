
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public class ExplodingKitten : Card
	{
		public ExplodingKitten(Game game, int id)
			: base(game, id, "Exploding Kitten", "Show this card immediately.")
		{
		}

		public override string ToString()
		{
			return string.Format("{0:00}. {1} {{{2}}}", Id, Name, Explanation);
		}

		public override ActionResponse Play()
		{
			ActionResponse res = new ActionResponse();
			bool hasDefuse = false;

			foreach (Card card in Game.ActivePlayer.Hand.Cards.Values)
			{
				if (card is Defuse)
				{
					hasDefuse = true;
					Game.Deck.DrawPile.Push(this);
					res = Game.ActivePlayer.PlayCard(card);
					Game.Deck.Shuffle();
					break;
				}
			}

			if (!hasDefuse)
				res = Game.EliminatePlayer(Game.ActivePlayer);

			return res;
		}

		public override ActionResponse Play(Player player)
		{
			throw new System.NotImplementedException();
		}
	}
}
