using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using ExplodingKittensLib.Models;
using ExplodingKittensLib.Models.Cards;
using ExplodingKittensLib.Models.Players;
using System.Windows.Input;

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
            game = new Game(numOfPlayers, false);
            NopeTrack.Visibility = Visibility.Hidden;
            AddNopeTrackBtns(numOfPlayers);
            Update();
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
            ShowHand();
            if (!game.ActivePlayer.IsUnderAttack)
            {
                MessageBox.Show("Your turn is now over.");
            }
            game.EndTurn();
            Update();
        }

        private void PlayBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ActivePlayer.PlaySelectedCards();
            ShowHand();
            NopeTrack.Visibility = Visibility.Visible;
        }

        private void NopeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowHand()
        {
            Hand activePlayerHand = game.ActivePlayer.Hand;
            playerHand.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (KeyValuePair<int, Card> card in activePlayerHand.Cards)
            {
                BitmapImage img = card.Value.CardImage;
                Image cImg = new Image();
                cImg.Uid = card.Value.Id.ToString();
                cImg.MouseDown += PlayerCard_MouseDown;
                playerHand.Children.Add(cImg);
                cImg.Source = img;
                Grid.SetRow(cImg, row);
                Grid.SetColumn(cImg, column);
                Grid.SetZIndex(cImg, row);

                if (column == 5)
                {
                    column = 0;
                    row++;
                }
                else { column++; }
            }
        }

        private void ShowSelected()
        {
            Hand activePlayerHand = game.ActivePlayer.Hand;
            playerHand.Children.Clear();
            int row = 0;
            int column = 0;
            foreach (KeyValuePair<int, Card> card in activePlayerHand.Cards)
            {
                BitmapImage img = card.Value.CardImage;
                Image cImg = new Image();
                playerHand.Children.Add(cImg);
                cImg.Source = img;
                Grid.SetRow(cImg, row);
                Grid.SetColumn(cImg, column);
                Grid.SetZIndex(cImg, row);

                if (column == 5)
                {
                    column = 0;
                    row++;
                }
                else { column++; }
            }
        }

        private void Update()
        {
            ShowHand();
            if (game.ActivePlayer.Hand.HasSelectedCard)
            {
                ActiveCard.Content = game.ActivePlayer.Hand.SelectedCard.Name;
            }
        }

        private void PlayerCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image _img = sender as Image;
            game.ActivePlayer.Hand.SelectedCard.IsSelected = false;
            int.TryParse(_img.Uid, out int num);
            game.ActivePlayer.Hand.Cards[num].IsSelected = true;
            ActiveCard.Content = game.ActivePlayer.Hand.SelectedCard.Name;

        }
    }
}