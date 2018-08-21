using ExplodingKittensLib.Models;
using ExplodingKittensLib.Models.Cards;
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
        public GamePage(int numOfPlayers, string[] playerNames)
        {
            InitializeComponent();
            //game = new Game(numOfPlayers, false);
            NopeTrack.Visibility = Visibility.Hidden;
            AddNopeTrackBtns(numOfPlayers);
        }

        private void AddNopeTrackBtns(int numOfPlayers)
        {
            NopeTrack.Children.Clear();
            for (int i = 0; i < numOfPlayers; i++)
            {
                Button b = new Button();
                b.Content = $"P{i + 1}";
                b.Click += NopeBtn_Click;
                NopeTrack.Children.Add(b);
            }
        }

        private void DrawBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ActivePlayer.DrawCard();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ActivePlayer.PlaySelectedCards();
            NopeTrack.Visibility = Visibility.Visible;
        }

        private void NopeBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void showHand()
        {
            Hand activePlayerHand = game.ActivePlayer.Hand;
            foreach (KeyValuePair<int, Card> card in activePlayerHand.Cards)
            {
               
            }
        }
    }
}
