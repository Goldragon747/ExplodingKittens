using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.IO;
using ExplodingKittensLib.Models;
using ExplodingKittensLib.Models.Cards;
using ExplodingKittensLib.Models.Players;

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
            Setup();
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

        private void ShowHand()
        {
            Hand activePlayerHand = game.ActivePlayer.Hand;
            int row = 0;
            int column = 0;
            foreach (KeyValuePair<int, Card> card in activePlayerHand.Cards)
            {
                System.Drawing.Image img = card.Value.CardImage;
                System.Windows.Controls.Image convertedImage = null;
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        ms.Seek(0, SeekOrigin.Begin);
                        var decoder = BitmapDecoder.Create(ms, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                        convertedImage = new System.Windows.Controls.Image { Source = decoder.Frames[0] };
                    }
                }
                catch (Exception) { }

                playerHand.Children.Add(convertedImage);
                if (column == 5)
                {
                    column = 0;
                    row++;
                }
                else { column++; }
            }
        }

        private void AttachCards()
        {
            foreach (Card card in game.Deck.DrawPile)
            {
                card.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
            }
            foreach (WPFPlayer p in game.Players)
            {
                foreach (Card card in p.Hand.Cards.Values)
                {
                    card.CardImage = System.Drawing.Image.FromFile("Assets/demo-card.jpg");
                }
            }
        }

        private void Setup()
        {
            AttachCards();
        }
    }
}