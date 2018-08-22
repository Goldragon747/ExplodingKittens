using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Models
{
    public class EKGame
    {
        public int GameID { get; set; }
        public int CurrentPlayer { get; set; }
        public string Name { get; set; }
    }
}
