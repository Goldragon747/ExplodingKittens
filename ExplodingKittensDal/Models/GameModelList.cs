using System;
using System.Collections.Generic;
using System.Text;

namespace ExpKittensDAL
{
    public class GameModelList
    {
        public List<Game> GameList { get; set; }
        public GameModelList()
        {
            GameList = new List<Game>();
        }
    }
}
