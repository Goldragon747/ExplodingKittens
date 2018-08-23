using ExplodingKittensLib.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingKittensLib.Models.Players
{
    public class WPFPlayer : Player
    {
        public WPFPlayer(int number, Game game) : base(number, game)
        {
        }

        public override ActionResponse SelectCard(int cardId)
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

        public override ActionResponse DeselectCard(int cardId)
        {
            if (!Hand.Cards.ContainsKey(cardId))
                return new ActionResponse(new Message(Enums.Severity.Error, "You don't have that card."));

            if (!Hand.Cards[cardId].IsSelected)
                return new ActionResponse(new Message(Enums.Severity.Error, "That card is already deselected."));

            Card card = Hand.Cards[cardId];
            card.IsSelected = false;

            return new ActionResponse(new Message(Enums.Severity.Info, string.Format("Player {0} deselected card: {1}", Id, card.ToString())));
        }

        public override void DeselectAllCards()
        {
            foreach (Card card in Hand.Cards.Values)
            {
                card.IsSelected = false;
            }
        }

        public override ActionResponse DrawCard()
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

            

            return res;
        }

        public override ActionResponse PlaySelectedCards()
        {
            //todo fill out PlaySelectedCards method
            return null;
        }

        public override ActionResponse PlayCard(Card card)
        {
            return PlayCard(card, new NullPlayer());
        }

        /// <summary>
        /// When a card is played, it is added to the play pile of the deck.
        /// The effect of the card then takes place.
        /// </summary>
        /// <param name="cardId"></param>
        public override ActionResponse PlayCard(Card card, Player player)
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

        public override void DiscardCard(Card card)
        {
            Hand.Cards.Remove(card.Id);
            _game.Deck.PlayPile.Push(card);
        }

        public override ActionResponse GiveCard(Card card, Player player)
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
    }
}
