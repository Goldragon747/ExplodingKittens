using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ExplodingKittensLib.Models.Cards;

namespace ExplodingKittensLib.Models
{
    public class WPFDeck : Deck
    {
        int id = 0;
        public WPFDeck(Game game, int numberOfPlayers)
            : base(game, numberOfPlayers)
        {
            AddIntialCards();
        }

        public Stack<Card> GetNopeCards()
        {
            Stack<Card> cards = new Stack<Card>();
            Nope one = new Nope(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_nope_1.jpg", UriKind.Absolute));
            Nope two = new Nope(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_nope_2.jpg", UriKind.Absolute));
            Nope three = new Nope(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_nope_3.jpg", UriKind.Absolute));
            Nope four = new Nope(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_nope_4.jpg", UriKind.Absolute));
            Nope five = new Nope(Game, id++);
            five.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_nope_5.jpg", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);
            cards.Push(five);

            return cards;
        }
        public Stack<Card> GetAttackCards()
        {
            Stack<Card> cards = new Stack<Card>();
            Attack one = new Attack(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_attack_1.jpg", UriKind.Absolute));
            Attack two = new Attack(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_attack_2.jpg", UriKind.Absolute));
            Attack three = new Attack(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_attack_3.jpg", UriKind.Absolute));
            Attack four = new Attack(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_attack_4.jpg", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);

            return cards;
        }
        public Stack<Card> GetSkipCards()
        {
            Stack<Card> cards = new Stack<Card>();
            Skip one = new Skip(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_skip_1.jpg", UriKind.Absolute));
            Skip two = new Skip(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_skip_2.jpg", UriKind.Absolute));
            Skip three = new Skip(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_skip_3.jpg", UriKind.Absolute));
            Skip four = new Skip(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_skip_4.jpg", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);

            return cards;
        }
        public Stack<Card> GetFavorCards()
        {
            Stack<Card> cards = new Stack<Card>();
            Favor one = new Favor(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_favor_1.jpg", UriKind.Absolute));
            Favor two = new Favor(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_favor_2.jpg", UriKind.Absolute));
            Favor three = new Favor(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_favor_3.jpg", UriKind.Absolute));
            Favor four = new Favor(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_favor_4.jpg", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);

            return cards;
        }
        public Stack<Card> GetShuffleCards()
        {
            Stack<Card> cards = new Stack<Card>();
            Shuffle one = new Shuffle(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_shuffle_1.jpg", UriKind.Absolute));
            Shuffle two = new Shuffle(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_shuffle_2.jpg", UriKind.Absolute));
            Shuffle three = new Shuffle(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_shuffle_3.jpg", UriKind.Absolute));
            Shuffle four = new Shuffle(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_shuffle_4", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);

            return cards;
        }
        public Stack<Card> GetSeeTheFutureCards()
        {
            Stack<Card> cards = new Stack<Card>();
            SeeTheFuture one = new SeeTheFuture(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_see_the_future_1.jpg", UriKind.Absolute));
            SeeTheFuture two = new SeeTheFuture(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_see_the_future_2.jpg", UriKind.Absolute));
            SeeTheFuture three = new SeeTheFuture(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_see_the_future_3.jpg", UriKind.Absolute));
            SeeTheFuture four = new SeeTheFuture(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_see_the_future_4.jpg", UriKind.Absolute));
            SeeTheFuture five = new SeeTheFuture(Game, id++);
            five.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_see_the_future_5.jpg", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);
            cards.Push(five);

            return cards;
        }
        public Stack<Card> GetCatCards()
        {
            Stack<Card> cards = new Stack<Card>();
            //Tacocat 4
            for (int i = 0; i < 4; i++)
            {
                Tacocat card = new Tacocat(Game, id++);
                card.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_tacocat.jpg", UriKind.Absolute));
                cards.Push(card);
            }
            //Rainbow - Ralphing Cat 4
            for (int i = 0; i < 4; i++)
            {
                RainbowRalphingCat card = new RainbowRalphingCat(Game, id++);
                card.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_rainbow_ralphing_cat.jpg", UriKind.Absolute));
                cards.Push(card);
            }
            //Beard Cat 4
            for (int i = 0; i < 4; i++)
            {
                BeardedCat card = new BeardedCat(Game, id++);
                card.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_beard_cat.jpg", UriKind.Absolute));
                cards.Push(card);
            }
            //Hairy Potato Cat 4
            for (int i = 0; i < 4; i++)
            {
                HairyPotatoCat card = new HairyPotatoCat(Game, id++);
                card.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_hairy_potato_cat.jpg", UriKind.Absolute));
                cards.Push(card);
            }
            //Cattermelon 4
            for (int i = 0; i < 4; i++)
            {
                Cattermelon card = new Cattermelon(Game, id++);
                card.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_cattermelon.jpg", UriKind.Absolute));
                cards.Push(card);
            }

            return cards;
        }
        public override Stack<Card> GetDefuseCards()
        {
            Stack<Card> cards = new Stack<Card>();
            if (NumberOfPlayers != 2)//todo Figure out where the randomization should be done and do it
            {
                Defuse one = new Defuse(Game, id++);
                one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_defuse_1.jpg", UriKind.Absolute));
                Defuse two = new Defuse(Game, id++);
                two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_defuse_2.jpg", UriKind.Absolute));
                Defuse three = new Defuse(Game, id++);
                three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_defuse_3.jpg", UriKind.Absolute));
                Defuse four = new Defuse(Game, id++);
                four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_defuse_4.jpg", UriKind.Absolute));
                Defuse five = new Defuse(Game, id++);
                five.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_defuse_5.jpg", UriKind.Absolute));
                Defuse six = new Defuse(Game, id++);
                six.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_defuse_6.jpg", UriKind.Absolute));
                cards.Push(one);
                cards.Push(two);
                cards.Push(three);
                cards.Push(four);
                cards.Push(five);
                cards.Push(six);
            }
            return cards;
        }
        public Stack<Card> GetExplodingKittenCards(int id)
        {
            Stack<Card> cards = new Stack<Card>();
            ExplodingKitten one = new ExplodingKitten(Game, id++);
            one.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_exploding_kitten_1.jpg", UriKind.Absolute));
            ExplodingKitten two = new ExplodingKitten(Game, id++);
            two.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_exploding_kitten_2.jpg", UriKind.Absolute));
            ExplodingKitten three = new ExplodingKitten(Game, id++);
            three.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_exploding_kitten_3.jpg", UriKind.Absolute));
            ExplodingKitten four = new ExplodingKitten(Game, id++);
            four.CardImage = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensLib;Component/Images/card_exploding_kitten_4.jpg", UriKind.Absolute));
            cards.Push(one);
            cards.Push(two);
            cards.Push(three);
            cards.Push(four);
            return cards;
        }

        private void AddIntialCards()
        {
            AddToDrawPile(GetNopeCards());//Nope 5
            AddToDrawPile(GetAttackCards());//Attack 4
            AddToDrawPile(GetSkipCards());//Skip 4
            AddToDrawPile(GetFavorCards());//Favor 4
            AddToDrawPile(GetShuffleCards());//Shuffle 4
            AddToDrawPile(GetSeeTheFutureCards());//See the future 5
            AddToDrawPile(GetCatCards());
        }

        public override void AddExplodingKittenCards()
        {
            AddToDrawPile(GetExplodingKittenCards(DrawPile.Count));//Exploding Kitten 4
        }

        private void AddToDrawPile(Stack<Card> cards)
        {
            foreach (Card card in cards)
            {
                DrawPile.Push(card);
            }
        }
    }
}
