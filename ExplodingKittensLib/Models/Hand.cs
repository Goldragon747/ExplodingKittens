using ExplodingKittensLib.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExplodingKittensLib.Models
{
	public class Hand
	{
		public Dictionary<int, Card> Cards { get; set; }
		public Dictionary<int, Card> SelectedCards { get; set; }

        public int CardsInHand { get { return Cards.Count; } }

		public bool HasSelectedCard
		{
			get { return Cards.Values.Any(card => card.IsSelected); }
		}

		public Card GetNope()
		{
			return Cards.Values.Where(card => card is Nope).DefaultIfEmpty(new NullCard()).First();
		}

		public Card SelectedCard
		{
			get
			{
				return Cards.Values.Where(card => card.IsSelected).DefaultIfEmpty(new NullCard()).First();
			}
		}

		public Card RemoveRandomCard()
		{
			List<int> keys = Cards.Keys.ToList();

			int removeIndex = keys.ElementAt(new Random().Next(1, CardsInHand));
			Card card = Cards[removeIndex];
			Cards.Remove(removeIndex);

			return card;
		}

		public Hand()
		{
			Cards = new Dictionary<int, Card>();
		}

		public override string ToString()
		{
			StringBuilder res = new StringBuilder();
			int cardIndex = 0;

			foreach (Card card in Cards.Values)
			{
				cardIndex += 1;

				if (cardIndex == Cards.Count)
					res.Append(card.ToString());
				else
					res.AppendLine(card.ToString());
			}

			return res.ToString();
		}
	}
}
