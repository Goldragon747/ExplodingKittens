using ExplodingKittensLib.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingKittensLib.Models
{
    public class ConsoleDeck:Deck
    {

        public ConsoleDeck(Game game, int numberOfPlayers)
            :base(game, numberOfPlayers)
        {
            AddAttackCards();
            AddFavorCards();
            AddShuffleCards();
            AddSeeTheFutureCards();
            AddNopeCards();
            AddSkipCards();
            AddPairCards();
            AddExplodingKittenCards();
        }

        public void AddExplodingKittenCards()
        {
            for (int playerIndex = 0; playerIndex < NumberOfPlayers - 1; playerIndex++)
            {
                DrawPile.Push(new ExplodingKitten(Game, _cardIndex++));
            }
        }

        public override Stack<Card> GetDefuseCards()
        {
            Stack<Card> defuseCards = new Stack<Card>();
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via 3am Flatulence"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via Participation in kitten yoga"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via catnip sandwiches"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via laser pointer"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via Kitten therapy"));
            defuseCards.Push(new Defuse(Game, _cardIndex++, "Via Belly rubs"));

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
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Feast upon a unicorn enchilada and gain its enchilada powers"));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Rub the belly of a pig-a-corn"));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Summon the Mantis shrimp"));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Ask the all-seeing goat wizard"));
            DrawPile.Push(new SeeTheFuture(Game, _cardIndex++, "Deploy the special-ops bunnies"));
        }

        private void AddShuffleCards()
        {
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "A plague of bat farts descends from the sky"));
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "A transdimensional Litter Box materializes"));
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "Abracrab lincoln is elected president"));
            DrawPile.Push(new Shuffle(Game, _cardIndex++, "An Electromagnetic pomeranian storm rolls in"));
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
    }
}
