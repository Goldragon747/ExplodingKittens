using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExplodingKittensLib.Models.Cards;

namespace ExplodingKittensLib.Models
{
    public class WpfDeck : Deck
    {
        public WpfDeck(Game game, int numberOfPlayers)
            : base(game, numberOfPlayers)
        {
        }

        public override Stack<Card> GetDefuseCards()
        {
            Stack<Card> cards = new Stack<Card>();
            if (NumberOfPlayers != 2)//todo Figure out where the randomization should be done and do it
            {
                //todo M: Set Defuse card images
                Defuse one = new Defuse(Game, 0);
                one.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                Defuse two = new Defuse(Game, 1);
                two.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                Defuse three = new Defuse(Game, 2);
                three.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                Defuse four = new Defuse(Game, 3);
                four.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                Defuse five = new Defuse(Game, 4);
                five.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                Defuse six = new Defuse(Game, 5);
                six.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                cards.Push(one);
                cards.Push(two);
                cards.Push(three);
                cards.Push(four);
                cards.Push(five);
                cards.Push(six);
            }
            return cards;
        }

        public Stack<Card> GetExplodingKittenCards()
        {
            Stack<Card> cards = new Stack<Card>();
            if (NumberOfPlayers != 2)//todo Figure out where the randomization should be done and do it
            {
                //todo M: Set ExplodingKitten card images
                ExplodingKitten one = new ExplodingKitten(Game, 6);
                one.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                ExplodingKitten two = new ExplodingKitten(Game, 7);
                two.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                ExplodingKitten three = new ExplodingKitten(Game, 8);
                three.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                ExplodingKitten four = new ExplodingKitten(Game, 9);
                four.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                cards.Push(one);
                cards.Push(two);
                cards.Push(three);
                cards.Push(four);
            }
            return cards;
        }

        private Stack<Card> MakeCards()
        {
            bool done = false;
            while (!done)
            {
                GetExplodingKittenCards();//Exploding Kitten 4
                GetDefuseCards();//Defuse 6
                //Nope 5
                //Attack 4
                //Skip 4
                //Favor 4
                //Shuffle 4
                //See the future 5
                //Tacocat 4
                //Rainbow - Ralphing Cat 4
                //Beard Cat 4
                //Hairy Potato Cat 4
                //Cattermelon 4
            }
            //todo Get cards from database
            throw new NotImplementedException();
        }
    }
}
