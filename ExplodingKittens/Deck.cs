using ExplodingKittens.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplodingKittens
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
				DrawPile.Push(new BikiniCat(Game, _cardIndex++));
				DrawPile.Push(new MommaCat(Game, _cardIndex++));
				DrawPile.Push(new ShyBladderCat(Game, _cardIndex++));
				DrawPile.Push(new ShrodingerCat(Game, _cardIndex++));
				DrawPile.Push(new ZombieCat(Game, _cardIndex++));
			}
		}

		private void AddSkipCards()
		{
			DrawPile.Push(new Skip(Game, _cardIndex++, "Evade dirty sasquatch underpants"));
			DrawPile.Push(new Skip(Game, _cardIndex++, "Sail away on your penis balloon. Be free, little buddy."));
			DrawPile.Push(new Skip(Game, _cardIndex++, "Play a game of whale boner tetherball"));
			DrawPile.Push(new Skip(Game, _cardIndex++, "Go base jumping using a pair of old lady boobs"));
		}

		private void AddNopeCards()
		{
			DrawPile.Push(new Nope(Game, _cardIndex++, "Awaken The Narnope"));
			DrawPile.Push(new Nope(Game, _cardIndex++, "Feed your opponent some cantanope"));
			DrawPile.Push(new Nope(Game, _cardIndex++, "Deliver some nope on your jump rope"));
			DrawPile.Push(new Nope(Game, _cardIndex++, "The Pope of Nope has spoken"));
			DrawPile.Push(new Nope(Game, _cardIndex++, "Put on your necktie of nope. Holy smokes you look good."));
		}

		private void AddSeeTheFutureCards()
		{
			DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Attach a butterfly to your genitals and see where it takes you in life"));
			DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Drink an entire bottle of bald eagle tears"));
			DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Discover a boob wizard living in your boobs. Listen to the secrets he tells."));
			DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Weave an infinity boner and live forever, foe it is the most sacred of boners."));
			DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Crawl inside a goat butt and see many wondrous things"));
		}

		private void AddShuffleCards()
		{
			DrawPile.Push(new Shuffle(Game, _cardIndex++, "Discover you have a toilet werewolf"));
			DrawPile.Push(new Shuffle(Game, _cardIndex++, "An asparagus bum dragon appears"));
			DrawPile.Push(new Shuffle(Game, _cardIndex++, "A kraken emerges and he's super upset"));
			DrawPile.Push(new Shuffle(Game, _cardIndex++, "Smoke some crack with a baby owl"));
		}

		private void AddFavorCards()
		{
			DrawPile.Push(new Favor(Game, _cardIndex++, "\"Baby Robin\" your best friend"));
			DrawPile.Push(new Favor(Game, _cardIndex++, "Teach someone a new palindrome"));
			DrawPile.Push(new Favor(Game, _cardIndex++, "Fall so deeply in love it you gives you both crazy diarrhea"));
			DrawPile.Push(new Favor(Game, _cardIndex++, "Donate your body to cat science"));
		}

		private void AddAttackCards()
		{
			DrawPile.Push(new Attack(Game, _cardIndex++, "Whip out your rubber dick collection"));
			DrawPile.Push(new Attack(Game, _cardIndex++, "Grow a magnificent squid arm and start slapping fat babies"));
			DrawPile.Push(new Attack(Game, _cardIndex++, "Release the torture bunnies"));
			DrawPile.Push(new Attack(Game, _cardIndex++, "Unleash some adorable penguin diarrhea"));
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
