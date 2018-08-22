using ExpKittensDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EKGameModelList
    {
        public List<Game> GameList { get; set; }
        public EKGameModelList()
        {
            GameList = new List<Game>();
        }
    }
}
