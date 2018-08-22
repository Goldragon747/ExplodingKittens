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
            //todo Get cards from database
            throw new NotImplementedException();
        }

        public Stack<Card> GetCards()
        {
            //todo Get cards from database
            throw new NotImplementedException();
        }
    }
}
