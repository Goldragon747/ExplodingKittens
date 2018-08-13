
using ExplodingKittensLib.Models.Players;

namespace ExplodingKittensLib.Models.Cards
{
	public class Pair : Card
	{
		public Pair(Game game, int id, string name)
			: base(game, id, name)
		{
		}

		public override string ToString()
		{
			return string.Format("{0:00}. Pair: {1}", Id, Name);
		}

		public override ActionResponse Play()
		{
			throw new System.NotImplementedException("You need to select a player to play your pair on.");
		}

		public override ActionResponse Play(Player player)
		{
			ActionResponse res = new ActionResponse();

			foreach (Card card in this.Game.ActivePlayer.Hand.Cards.Values)
			{
				if (IsPair(card))
				{
					// play the pair card
					Game.ActivePlayer.Hand.Cards.Remove(card.Id);
					Game.Deck.PlayPile.Push(card);

					Card stolenCard = player.Hand.RemoveRandomCard();
					Game.ActivePlayer.Hand.Cards.Add(stolenCard.Id, stolenCard);
					res.AddMessage(string.Format("Player {0} stole player {1}'s card.", Game.ActivePlayer.Id, player.Id));

					break;
				}
			}

			return res;
		}

		private bool IsPair(Card card)
		{
			return card.GetType().Name == GetType().Name;
		}
	}
}
