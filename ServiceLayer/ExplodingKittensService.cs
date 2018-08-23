using ExplodingKittensDAL;
using ExplodingKittensLib;
using ExplodingKittensLib.Models.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ExplodingKittensService
    {
        //public EKCardModelList GetAllCards()
        //{
        //    EKCardModelList cardList = new EKCardModelList();
        //    using (var db = new Pro250_KittensEntities())
        //    {
        //        var query = db.Cards.Select(x => x);
        //        var Cards_List = query.ToList();
        //        Cards_List.ForEach(cardDetail =>
        //           cardList.CardList.Add(
        //                new Card()
        //                {
        //                    CardID = cardDetail.CardID,
        //                    Flavor_Text = cardDetail.Flavor_Text,
        //                    Text = cardDetail.Text,
        //                    Title = cardDetail.Title

        //                }));
        //    }
        //    return cardList;
        //}


        //public bool IsCardInHand(int cardId, int playerId)
        //{
        //    using (var db = new Pro250_KittensEntities())
        //    {
        //        var getHandQuery = db.Hands.Where(x => x.PlayerID == playerId).ToList();
        //        for (int i = 0; i < getHandQuery.Count; i++)
        //        {
        //            if (getHandQuery[i].CardID == cardId)
        //            {
        //                return true;
        //            }
        //        }
        //        return false;
        //    }
        //}
        //public void addCardToTable(int cardID, string flavorText, string text, string title)
        //{
        //    using (var db = new Pro250_KittensEntities())
        //    {
        //        db.Cards.Add(new Card()
        //        {
        //            CardID = cardID,
        //            Flavor_Text = flavorText,
        //            Text = text,
        //            Title = title
        //        });
        //        db.SaveChanges();
        //    }
        //}
        public void SaveGame(ExplodingKittensLib.Models.Game myGame)
        {
            var currentPlayers = myGame.Players;
            using(var db = new Pro250_KittensEntities1())
            {
                //Save Players
                for (int i = 0; i < currentPlayers.Count; i++)
                {
                    //savePlayer(currentPlayers.ElementAt(i), i, myGame.ID);
                }
                //Saves Hands
                for (int i = 0; i < currentPlayers.Count; i++)
                {
                    //SaveHand(currentPlayers.ElementAt(i));
                }
                //Save DrawDeck
                //saveDeck(myGame.Deck.DrawPile);
            }
            
        }
        public void savePlayer(ExplodingKittensLib.Models.Players.WPFPlayer myPlayer, int playerPosition, int gameID)
        {
            using (var db = new Pro250_KittensEntities1())
            {
                var playerQuery = db.Players.Where(x => x.PlayerID == myPlayer.Id).First();
                if (playerQuery != null)
                {
                    db.Players.Remove(playerQuery);
                }
                db.Players.Add(new Player
                {
                    PlayerID = myPlayer.Id,
                    Player_Name = myPlayer.Name,
                    Position = playerPosition,
                    GameID = gameID
                });
                db.SaveChanges();
            }
        }
        public void SaveHand(ExplodingKittensLib.Models.Players.WPFPlayer myPlayer)
        {
            using (var db = new Pro250_KittensEntities1())
            {
                var getPlayerHandQuery = db.Player_Hand.Where(x => x.PlayerID == myPlayer.Id).ToList();
                db.Player_Hand.RemoveRange(getPlayerHandQuery);
                for (int i = 0; i < myPlayer.Hand.Cards.Count; i++)
                {
                    db.Player_Hand.Add(new Player_Hand
                    {
                        CardID = myPlayer.Hand.Cards[i].Id,
                        PlayerID = myPlayer.Id
                    });
                }               
            }
        }
        public void saveDeck(Stack<Card> drawDeck, int gameID)
        {
            using (var db = new Pro250_KittensEntities1())
            {
                var getPlayDeckQuery = db.PlayDecks.Where(x => x.GameID == gameID);
            }
        }
    }
}

