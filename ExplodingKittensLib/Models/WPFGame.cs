using ExplodingKittensLib.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplodingKittensLib.Models
{
    public class WPFGame : Game
    {
        public LinkedList<WPFPlayer> Players { get; set; }
        /// <summary>
        /// Create the only instance of the wpf game class
        /// </summary>
        /// <param name="numberOfPlayers">The number of players in the game (between 2 and 5 inclusive)</param>
        public WPFGame(int numberOfPlayers, bool isConsoleApp) 
            : base(numberOfPlayers, isConsoleApp)
        {
            Players = new LinkedList<WPFPlayer>();
        }
    }
}
