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
        public void SaveGame(ExplodingKittensLib.Models.Game myGame)
        {
            var currentPlayers = myGame.Players;
            int activePlayerIndex = -1;
            using(var db = new Pro250_KittensEntities1())
            {
              
                //Save Players
                for (int i = 0; i < currentPlayers.Count; i++)
                {
                    if(currentPlayers.ElementAt(i).IsActive == true)
                    {
                        activePlayerIndex = i;
                    }
                    savePlayer(currentPlayers.ElementAt(i), i, myGame.ID);
                }
                //SaveGame
                saveGameToTable(myGame, activePlayerIndex);
                //Saves Hands
                for (int i = 0; i < currentPlayers.Count; i++)
                {
                    SaveHand(currentPlayers.ElementAt(i));
                }
                //Save Decks
                savePlayDeck(myGame.Deck.PlayPile, myGame.ID);
                saveDrawDeck(myGame.Deck.DrawPile, myGame.ID);
            }
            
        }
        public ExplodingKittensLib.Models.Game loadGame(ExplodingKittensLib.Models.Game myGame)
        {
            using(var db = new Pro250_KittensEntities1())
            {
                IQueryable<Player> playersList = db.Players.Where(x => x.GameID == myGame.ID);
                LinkedList<ExplodingKittensLib.Models.Players.Player> playerObjectsList = new LinkedList<ExplodingKittensLib.Models.Players.Player>();
                List<int> cardIDList = new List<int>();
                ExplodingKittensLib.Models.WPFDeck myWPFDeck = new ExplodingKittensLib.Models.WPFDeck(myGame, myGame.Players.Count);

                foreach (Player newPlayer in playersList)
                {
                    //New Hand and Player
                    ExplodingKittensLib.Models.Hand myHand = new ExplodingKittensLib.Models.Hand();
                    ExplodingKittensLib.Models.Players.Player myPlayer = new ExplodingKittensLib.Models.Players.Player(newPlayer.PlayerID, myGame);
                    for (int i = 0; i < newPlayer.Player_Hand.Count; i++)
                    {     
                        //Add to CardID List to get the hand information
                        cardIDList.Add(newPlayer.Player_Hand.ElementAt(i).CardID);                      
                    }
                    //Set active Player
                    if (myGame.ActivePlayer.Id == newPlayer.PlayerID)
                    {
                        myPlayer.IsActive = true;
                    }
                    else
                    {
                        myPlayer.IsActive = false;
                    }
                    myHand = myWPFDeck.GetCardStack(cardIDList);
                    myPlayer.Id = newPlayer.PlayerID;
                    myPlayer.Hand = myHand;
                    myPlayer.IsAskedForFavor = false;
                    myPlayer.IsBeingStolenFrom = false;
                    myPlayer.IsUnderAttack = false;
                    myPlayer.Name = newPlayer.Player_Name;
                    playerObjectsList.AddFirst(myPlayer);                  
                }
                myGame.Players = playerObjectsList;
            }
            return myGame;
        }
        public void saveGameToTable(ExplodingKittensLib.Models.Game myGame, int activePlayerIndex)
        {
            using(var db = new Pro250_KittensEntities1())
            {
                var gameQuery = db.Games.Where(x => x.GameID == myGame.ID).First();
                if(gameQuery != null)
                {
                    db.Games.Remove(gameQuery);
                }
                db.Games.Add(new Game
                {
                    GameID = myGame.ID,
                    Current_Player = activePlayerIndex,
                    Game_Name = myGame.Name,
                    
                });
            }
        }
        public void savePlayer(ExplodingKittensLib.Models.Players.Player myPlayer, int playerPosition, int gameID)
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

        public void SaveHand(ExplodingKittensLib.Models.Players.Player myPlayer)
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
                db.SaveChanges();
            }
        }
        public void savePlayDeck(Stack<Card> playDeck, int gameID)
        {
            using (var db = new Pro250_KittensEntities1())
            {
                var getPlayDeckQuery = db.PlayDecks.Where(x => x.GameID == gameID).First();
                if(getPlayDeckQuery != null)
                {
                    db.PlayDecks.Remove(getPlayDeckQuery);
                }
                for (int i = 0; i < playDeck.Count; i++)
                {
                    db.PlayDecks.Add(new PlayDeck
                    {
                        CardID = playDeck.ElementAt(i).Id,
                        GameID = gameID

                    });
                    db.SaveChanges();
                }
              
            }
        }
        public void saveDrawDeck(Stack<Card> drawDeck, int gameID)
        {
            using (var db = new Pro250_KittensEntities1())
            {
                var getDrawDeckQuery = db.DrawDecks.Where(x => x.GameID == gameID).First();
                if (getDrawDeckQuery != null)
                {
                    db.DrawDecks.Remove(getDrawDeckQuery);
                }
                for (int i = 0; i < drawDeck.Count; i++)
                {
                    db.DrawDecks.Add(new DrawDeck
                    {
                        CardID = drawDeck.ElementAt(i).Id,
                        GameID = gameID

                    });
                    db.SaveChanges();
                }

            }
        }
    }
}

