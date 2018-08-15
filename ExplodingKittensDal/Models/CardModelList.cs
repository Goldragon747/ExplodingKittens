using System;
using System.Collections.Generic;
using System.Text;

namespace ExplodingKittensDal.Models
{
    public class CardModelList
    {
        public List<Card> CardList { get; set; }

        public CardModelList()
        {
            CardList = new List<Card>();
        }
    }
}
