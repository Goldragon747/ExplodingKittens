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
            game = new Game(numOfPlayers, playerNames);
            NopeTrack2.Visibility = Visibility.Hidden;
            PlayOverlay.Visibility = Visibility.Hidden;
            AddNopeTrackBtns(numOfPlayers);
            Update();
        }

        private void AddNopeTrackBtns(int numOfPlayers)
        {
            //NopeTrack2.Children.Clear();
            //for (int i = 0; i < numOfPlayers; i++)
            //{
            //    Button b = new Button();
            //    b.Content = $"P{i + 1}";
            //    b.Click += NopeBtn_Click;
            //    NopeTrack2.Children.Add(b);
            //}
        }

        private void DrawBtn_Click(object sender, RoutedEventArgs e)
        {
            game.ActivePlayer.DrawCard();
            //todo Add check to see if they drew an exploding kitten and it they had a defuse
            //todo If exploding kiten /w defuse, then allow player to choose where to put bomb in deck
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
            //todo Finsh Implementing PlayBtn_Click
            game.ActivePlayer.PlaySelectedCards();
            ShowHand();
            NopeTrack2.Visibility = Visibility.Visible;
        }

        private void NopeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ShowHand()
        {
            //todo Make player hand either scroll-able or stacked so the cards don't run off the screen
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
                cImg.Margin = new Thickness(5);
                Grid.SetRow(cImg, row);
                Grid.SetColumn(cImg, column);
                Grid.SetRowSpan(cImg, 3);
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
                cImg.Margin = new Thickness(5);
                Grid.SetRow(cImg, row);
                Grid.SetColumn(cImg, column);
                Grid.SetRowSpan(cImg, 3);
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
            PlayerName.Content = game.ActivePlayer.Name;
            //todo Clear board between turns
            //todo Ask player, by name, if they are ready to begin their turn
            ShowHand();
        }

        private void StartPlayerTurn()
        {
            bool underAttack = game.ActivePlayer.IsUnderAttack;
            do
            {
                if (underAttack) { TurnsRemaining.Content = "2 Turns Remaining"; }

                //Do play stuff

                if (underAttack && game.NextPlayer.IsUnderAttack)
                {
                    underAttack = false;
                }
            }
            while (underAttack);
        }
        /*On turn start
         * - Screen should be either cleared or hidden
         * - The Game should prompt the user by name if they are ready to began
         * - Once ready the screen should display as normal with players hand, last played card and number of turns
         * 
         */ 

        private void PlayerCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayOverlay.Visibility = Visibility.Visible;
            Image _img = sender as Image;
            PlayOverlay_Card.Source = _img.Source;
            game.ActivePlayer.Hand.SelectedCard.IsSelected = false;
            int.TryParse(_img.Uid, out int num);
            game.ActivePlayer.Hand.Cards[num].IsSelected = true;
            //ActiveCard.Content = game.ActivePlayer.Hand.SelectedCard.Name;

        }

        private void DrawBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/card_draw_hover.png"));
        }

        private void DrawBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/card_draw.png"));
        }

        private void PlayOverlay_Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayOverlay.Visibility = Visibility.Collapsed;
        }

        private void PlayOverlay_Back_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_back_hover.png"));
        }

        private void PlayOverlay_Back_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_back.png"));
        }
        //TODO add test for disabling steal buttons for 2 and 3 card combos
        private bool stealIsValid = true;
        private void PlayOverlay_Steal_Random_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stealIsValid)
            {
                ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/steal_random_hover.png"));
            }
        }

        private void PlayOverlay_Steal_Random_MouseLeave(object sender, MouseEventArgs e)
        {
            if (stealIsValid)
            {
                ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/steal_random.png"));
            }
        }

        private void PlayOverlay_Steal_Random_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Steal_Specific_MouseEnter(object sender, MouseEventArgs e)
        {
            if (stealIsValid)
            {
                ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/steal_specific_hover.png"));
            }
        }

        private void PlayOverlay_Steal_Specific_MouseLeave(object sender, MouseEventArgs e)
        {
            if (stealIsValid)
            {
                ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/steal_specific.png"));
            }
        }

        private void PlayOverlay_Steal_Specific_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Play_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_play_hover.png"));
        }

        private void PlayOverlay_Play_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_play.png"));
        }

        private void PlayOverlay_Play_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void PlayOverlay_Nope_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nope_hover.png"));
        }

        private void PlayOverlay_Nope_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nope.png"));
        }

        private void PlayOverlay_Nope_1_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Nope_2_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Nope_3_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Nope_4_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Nope_5_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}