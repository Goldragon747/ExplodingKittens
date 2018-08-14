using ExplodingKittensLib.Models.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplodingKittensLib.Models
{
    public class Deck
    {
        private int _cardIndex { get; set; }

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
            AddAttackCards();
            AddFavorCards();
            AddShuffleCards();
            AddSeeTheFutureCards();
            AddNopeCards();
            AddSkipCards();
            AddPairCards();
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

        public void AddExplodingKittenCards()
        {
            for (int playerIndex = 0; playerIndex < NumberOfPlayers - 1; playerIndex++)
            {
                DrawPile.Push(new ExplodingKitten(Game, _cardIndex++));
            }
        }

        public Stack<Card> GetDefuseCards()
        {
            //todo change text
            Stack<Card> defuseCards = new Stack<Card>();
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via nature documentaries"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via porkback riding into the sunset together"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via spray / neuter"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via crate"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via mauling a baby"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via excessive ball-cleaning"));

            return defuseCards;
        }

        private void AddPairCards()
        {
            int maxPairCardOfType = 4;

            for (int pairCardIndex = 0; pairCardIndex < maxPairCardOfType; pairCardIndex++)
            {
                DrawPile.Push(new Cattermelon(Game, _cardIndex++));
                DrawPile.Push(new HairyPotatoCat(Game, _cardIndex++));
                DrawPile.Push(new Tacocat(Game, _cardIndex++));
                DrawPile.Push(new BeardedCat(Game, _cardIndex++));
                DrawPile.Push(new RainbowRalphingCat(Game, _cardIndex++));
            }
        }

        private void AddSkipCards()
        {
            DrawPile.Push(new Skip(Game, _cardIndex++, "Crab walk with some crabs"));
            DrawPile.Push(new Skip(Game, _cardIndex++, "Don a portable cheetah butt"));
            DrawPile.Push(new Skip(Game, _cardIndex++, "Commandeer a Bunnyraptor"));
            DrawPile.Push(new Skip(Game, _cardIndex++, "Engage the Hypergoat"));
        }

        private void AddNopeCards()
        {
            DrawPile.Push(new Nope(Game, _cardIndex++, "Feed your opponent a nope sandwich with extra Nopesause"));
            DrawPile.Push(new Nope(Game, _cardIndex++, "Win the Nopebell peace prize"));
            DrawPile.Push(new Nope(Game, _cardIndex++, "A Jackanope bounds into the room"));
            DrawPile.Push(new Nope(Game, _cardIndex++, "Nopestradamus speaks the truth"));
            DrawPile.Push(new Nope(Game, _cardIndex++, "A nope ninja delivers a wicked dragon kick"));
        }

        private void AddSeeTheFutureCards()
        {
            //todo change text
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Attach a butterfly to your genitals and see where it takes you in life"));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Drink an entire bottle of bald eagle tears"));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Discover a boob wizard living in your boobs. Listen to the secrets he tells."));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Weave an infinity boner and live forever, foe it is the most sacred of boners."));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Crawl inside a goat butt and see many wondrous things"));
        }

        private void AddShuffleCards()
        {
            //todo change text
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "Discover you have a toilet werewolf"));
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "An asparagus bum dragon appears"));
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "A kraken emerges and he's super upset"));
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "Smoke some crack with a baby owl"));
        }

        private void AddFavorCards()
        {
            DrawPile.Push(new Favor(Game, _cardIndex++, "Take your friends beard-sailing on your beard boat"));
            DrawPile.Push(new Favor(Game, _cardIndex++, "Ask for a back hair shampoo"));
            DrawPile.Push(new Favor(Game, _cardIndex++, "Get inslaved by party squirrels"));
            DrawPile.Push(new Favor(Game, _cardIndex++, "Rub peanut butter on your belly button and make some new friends"));
        }

        private void AddAttackCards()
        {
            DrawPile.Push(new Attack(Game, _cardIndex++, "Unleash the catterwocky"));
            DrawPile.Push(new Attack(Game, _cardIndex++, "Deploy the thousand-year back hair"));
            DrawPile.Push(new Attack(Game, _cardIndex++, "Awaken the bear-o-dactyl"));
            DrawPile.Push(new Attack(Game, _cardIndex++, "Fire the crab-a-pult"));
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
    }
}
