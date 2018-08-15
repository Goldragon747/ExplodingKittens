using ExplodingKittensLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExplodingKittensWPF.Pages
{
    /// <summary>
    /// Interaction logic for StartUpPage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private Game game;
        public GamePage(int numOfPlayers)
        {
            InitializeComponent();
            game = new Game(numOfPlayers, false);
        }

        private void DrawBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ActivePlayer.DrawCard();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ActivePlayer.PlaySelectedCards();
        }
    }
}
