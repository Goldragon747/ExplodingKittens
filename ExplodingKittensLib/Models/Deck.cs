using ExplodingKittensLib.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplodingKittensLib.Models
{
    public abstract class Deck
    {
        protected int _cardIndex { get; set; }

        public int NumberOfPlayers { get; set; }
        public Game Game { get; set; }
        public Stack<Card> DrawPile { get; set; }
        public Stack<Card> PlayPile { get; set; }

        public Deck(Game game, int numberOfPlayers)
        {
            _cardIndex = 1;
            Game = game;
            NumberOfPlayers = numberOfPlayers;
            DrawPile = new Stack<Card>();
            PlayPile = new Stack<Card>();
        }

        public void Shuffle()
        {
            Random randomNumberGenerator = new Random();
            Card[] cardsArray = DrawPile.ToArray();
            List<Card> unshuffledCards = new List<Card>();

            foreach (Card card in cardsArray)
            {
                unshuffledCards.Add(card);
            }

            Stack<Card> shuffledCards = new Stack<Card>();
            while (unshuffledCards.Count > 0)
            {
                int randomCardIndex = randomNumberGenerator.Next(0, unshuffledCards.Count);
                shuffledCards.Push(unshuffledCards[randomCardIndex]);
                unshuffledCards.RemoveAt(randomCardIndex);
            }

            DrawPile = shuffledCards;
        }

        public ActionResponse Print()
        {
            return new ActionResponse(new Message(Enums.Severity.Info, ToString()));
        }

        public override string ToString()
        {
            StringBuilder res = new StringBuilder();

            res.Append("Deck:\n-----\n");
            res.AppendFormat("Draw pile ({0}):\n", DrawPile.Count);

            foreach (Card card in DrawPile)
            {
                res.AppendLine(card.ToString());
            }

            res.AppendFormat("Play pile ({0}):\n", PlayPile.Count);

            foreach (Card card in PlayPile)
            {
                res.AppendLine(card.ToString());
            }

            return res.ToString();
        }

        public abstract Stack<Card> GetDefuseCards();
    }
}
