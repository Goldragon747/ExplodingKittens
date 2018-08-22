using ExplodingKittensDAL;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ExplodingKittensService
    {
        public EKCardModelList GetAllCards()
        {
            EKCardModelList cardList = new EKCardModelList();
            using (var db = new Pro250_KittensEntities())
            {
                var query = db.Cards.Select(x => x);
                var Cards_List = query.ToList();
                Cards_List.ForEach(cardDetail =>
                   cardList.CardList.Add(
                        new Card()
                        {
                            CardID = cardDetail.CardID,
                            Flavor_Text = cardDetail.Flavor_Text,
                            Text = cardDetail.Text,
                            Title = cardDetail.Title

                        }));
            }
            return cardList;
        }


        public bool IsCardInHand(int cardId, int playerId)
        {
            using (var db = new Pro250_KittensEntities())
            {
                var getHandquery = db.Hands.Where(x => x.PlayerID == playerId).ToList();
                for (int i = 0; i < getHandquery.Count; i++)
                {
                    if (getHandquery[i].CardID == cardId)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public void addCardToTable(int cardID, string flavorText, string text, string title)
        {
            using (var db = new Pro250_KittensEntities())
            {
                db.Cards.Add(new Card()
                {
                    CardID = cardID,
                    Flavor_Text = flavorText,
                    Text = text,
                    Title = title
                });
                db.SaveChanges();
            }
        }
        public void Update(string id, string content)
        {
            //using (var db = new Pro250_KittensEntities())
            //{
            //    var element = db.Stored_Elements.Where(x => x.TagIndex == id).First();
            //    element.TagContent = content;
            //    db.SaveChanges();
            //}
        }
    }
}

