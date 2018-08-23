using ExplodingKittensLib.Models.Cards;
using System;
using System.Text;

namespace ExplodingKittensLib.Models.Players
{
	public class Player
	{
		protected Game _game;

		public Hand Hand { get; set; }
		public int Id { get; set; }
		public bool IsActive { get; set; }
		public bool IsUnderAttack { get; set; }
		public bool IsAskedForFavor { get; set; }
		public bool IsBeingStolenFrom { get; set; }
		
		public Player(int number, Game game)
		{
			Id = number;
			Hand = new Hand();
			_game = game;
		}

		public virtual ActionResponse SelectCard(int cardId)
		{
			if (cardId <= 0)
				return new ActionResponse(new Message(Enums.Severity.Error, "You must choose a card to select."));

			if (!Hand.Cards.ContainsKey(cardId))
				return new ActionResponse(new Message(Enums.Severity.Error, "You don't have that card."));

			if (Hand.Cards[cardId].IsSelected)
				return new ActionResponse(new Message(Enums.Severity.Error, "That card is already selected."));
			
			DeselectAllCards();
			Card card = Hand.Cards[cardId];
			card.IsSelected = true;

			return new ActionResponse(new Message(Enums.Severity.Info, string.Format("Player {0} selected card: {1}", Id, card.ToString())));
		}

		public virtual ActionResponse DeselectCard(int cardId)
		{
			if (!Hand.Cards.ContainsKey(cardId))
				return new ActionResponse(new Message(Enums.Severity.Error, "You don't have that card."));

			if (!Hand.Cards[cardId].IsSelected)
				return new ActionResponse(new Message(Enums.Severity.Error, "That card is already deselected."));

			Card card = Hand.Cards[cardId];
			card.IsSelected = false;

			return new ActionResponse(new Message(Enums.Severity.Info, string.Format("Player {0} deselected card: {1}", Id, card.ToString())));
		}

		public virtual void DeselectAllCards()
		{
			foreach (Card card in Hand.Cards.Values)
			{
				card.IsSelected = false;
			}
		}

		public virtual ActionResponse DrawCard()
		{
			ActionResponse res = new ActionResponse();

			if (IsAskedForFavor)
				return new ActionResponse(new Message(Enums.Severity.Error, "You can't draw when you're being asked for a favor."));
			if (IsBeingStolenFrom)
				return new ActionResponse(new Message(Enums.Severity.Error, "You can't draw when you're being stolen from."));

			Card card = _game.Deck.DrawPile.Pop();
			Hand.Cards.Add(card.Id, card);

			if (card is ExplodingKitten)
				res = PlayCard(card);
			else
				res.AddMessage(string.Format("Player {0} picked up card {1}", _game.ActivePlayer.Id, card.ToString()));

			_game.EndTurn();

			return res;
		}

		public virtual ActionResponse PlayCard(Card card)
		{
			return PlayCard(card, new NullPlayer());
		}

		/// <summary>
		/// When a card is played, it is added to the play pile of the deck.
		/// The effect of the card then takes place.
		/// </summary>
		/// <param name="cardId"></param>
		public virtual ActionResponse PlayCard(Card card, Player player)
		{
			ActionResponse res = new ActionResponse();

			if (Id == player.Id)
				return new ActionResponse(new Message(Enums.Severity.Error, "You can't play a card on yourself."));
			if (IsAskedForFavor)
				return new ActionResponse(new Message(Enums.Severity.Error, "You can't play a card when you're being asked for a favor."));
			if (IsBeingStolenFrom)
				return new ActionResponse(new Message(Enums.Severity.Error, "You can't play a card when you're being stolen from."));

			try
			{
				if (player.Id <= 0)
					res = card.Play();
				else
					res = card.Play(player);
			}
			catch (Exception e)
			{
				res.AddError(e.Message);
			}

			if (res.IsSuccessful)
				DiscardCard(card);

			return res;
		}

        public virtual ActionResponse PlaySelectedCards()
        {
            //todo fill out PlaySelectedCards method
            return null;
        }

        public virtual void DiscardCard(Card card)
		{
			Hand.Cards.Remove(card.Id);
			_game.Deck.PlayPile.Push(card);
		}

		public virtual ActionResponse GiveCard(Card card, Player player)
		{
			string messageText = string.Format("Player {0} gave player {1} the card {2}", Id, player.Id, card.ToString());

			if (Id == player.Id)
				return new ActionResponse(new Message(Enums.Severity.Error, "You can't give a card to yourself."));
			if (player is NullPlayer)
				return new ActionResponse(new Message(Enums.Severity.Error, "You need to choose a player to give the card to."));
			if (card is NullCard)
				return new ActionResponse(new Message(Enums.Severity.Error, "No card selected."));
			if (IsAskedForFavor)
				IsAskedForFavor = false;

			Hand.Cards.Remove(card.Id);
			player.Hand.Cards.Add(card.Id, card);

			return new ActionResponse(new Message(Enums.Severity.Info, messageText));
		}

		public ActionResponse GetStatus()
		{
			return new ActionResponse(new Message(Enums.Severity.Info, ToString()));
		}

		public override string ToString()
		{
			StringBuilder res = new StringBuilder();

			res.AppendFormat("Player {0}:\n---------\n", Id);
			res.AppendFormat("Is {0}active\n", (IsActive ? "" : "not "));
			res.AppendFormat("Is {0}under attack\n", (IsUnderAttack ? "" : "not "));
			res.AppendFormat("Is {0}being asked for a favor\n", (IsAskedForFavor ? "" : "not "));
			res.AppendFormat("Is {0}being stolen from", (IsBeingStolenFrom ? "" : "not "));

			return res.ToString();
		}
	}
}
