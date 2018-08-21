using System;
using System.Collections.Generic;
using System.Text;

namespace ExpKittensDAL
{
    class PlayerModelList
    {
        public List<Player> PlayerList { get; set; }
        public PlayerModelList()
        {
            PlayerList = new List<Player>();
        }
    }
}
