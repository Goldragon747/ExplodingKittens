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
using ExplodingKittensWPF.UserControls;

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
            NopeTrack.Visibility = Visibility.Hidden;
            PlayOverlay.Visibility = Visibility.Hidden;
            StartPlayerTurn();
        }

        private void AddNopeTrackBtns()
        {
            NopeTrack.Children.Clear();
            Player p = game.ActivePlayer;
            for (int i = 0; i < game.Players.Count; i++)
            {
                if (!p.IsActive)
                {
                    PlayerNope nope = new PlayerNope();
                    nope.PlayerName = p.Name;
                    nope.Id = p.Id;
                    nope.MouseDown += PlayOverlay_Nope_MouseDown;
                    nope.Margin = new Thickness(0, 0, 0, 20);
                    NopeTrack.Children.Add(nope);
                }
                p = game.GetNextPlayer(p);
            }
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

        private void ClearBoard()
        {
            playerHand.Children.Clear();
            PlayOverlay_Back.Visibility = Visibility.Hidden;
            PlayOverlay_Play.Visibility = Visibility.Hidden;
            PlayOverlay_Steal_Random.Visibility = Visibility.Hidden;
            PlayOverlay_Steal_Specific.Visibility = Visibility.Hidden;
        }

        private void StartPlayerTurn()
        {
            bool underAttack = game.ActivePlayer.IsUnderAttack;
            do
            {
                PlayerName.Content = game.ActivePlayer.Name;
                if (underAttack) { TurnsRemaining.Content = "2 Turns Remaining"; }
                else { TurnsRemaining.Content = "1 Turn Remaining"; }

                MessageBox.Show($"{game.ActivePlayer.Name}, get ready for your turn.");//todo MessageBox
                ShowHand();
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
         * - The Game should prompt the user by name if they are ready to began their turn
         * - Once ready the screen should display as normal with players hand, last played card and number of turns
         * 
         * On card drawn, 2 turns
         * - card is added to player hand
         * 
         * On card drawn, 1 turn
         * - card is added to player hand
         * - The Game should prompt the user by name if they are ready to end their turn
         */

        private bool stealIsValid = true;

        #region Mouse Downs
        private void DrawBtn_Click(object sender, RoutedEventArgs e)
        {
            WPFPlayer p = (WPFPlayer)game.ActivePlayer;
            p.DrawCard();
            if (game.Deck.PlayPile.Peek().GetType() == typeof(ExplodingKitten))
            {
                Card bomb = game.Deck.PlayPile.Pop();
                Card defuse = p.Hand.GetDefuse();
                if (defuse.GetType() != typeof(NullCard))
                {
                    p.PlayCard(defuse);
                    MessageBox.Show($"Fwew, you drew an Exploding Kitten, but you had a defuse.");//todo MessageBox
                    //todo If exploding kiten /w defuse, then allow player to choose where to put bomb in deck
                }
                else
                {
                    MessageBox.Show($"Oh no! You drew an Exploding Kitten, but you didn't have a defuse.");//todo MessageBox
                }
            }
            ShowHand();
            if (!game.ActivePlayer.IsUnderAttack)
            {
                MessageBox.Show("Your turn is now over.");//todo MessageBox
            }
            game.EndTurn();
            ClearBoard();
            StartPlayerTurn();
        }

        private void PlayerCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayOverlay.Visibility = Visibility.Visible;
            Image _img = sender as Image;
            PlayOverlay_Card.Source = _img.Source;
            game.ActivePlayer.Hand.SelectedCard.IsSelected = false;
            int.TryParse(_img.Uid, out int num);
            game.ActivePlayer.Hand.Cards[num].IsSelected = true;

            WPFPlayer p = (WPFPlayer)game.ActivePlayer;
            Card selectedCard = null;
            foreach (KeyValuePair<int, Card> card in p.Hand.Cards)
            {
                if (_img.Uid == card.Value.Id.ToString())
                {
                    selectedCard = card.Value;
                    break;
                }
            }
            int num = 0;
            foreach (KeyValuePair<int, Card> card in p.Hand.Cards)
            {
                if (card.Value.GetType() == selectedCard.GetType()){ num++; }
            }
            if(num < 2)
            {
                //todo disable steal 2 and 3
            }
            else if (num < 3)
            {
                //todo disable steal 3
            }

        }

        private void PlayOverlay_Back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PlayOverlay.Visibility = Visibility.Collapsed;
        }

        private void PlayOverlay_Steal_Random_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Steal_Specific_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void PlayOverlay_Play_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WPFPlayer p = (WPFPlayer)game.ActivePlayer;
            Image _img = sender as Image;
            Card selectedCard = null;
            foreach (KeyValuePair<int, Card> card in p.Hand.Cards)
            {
                if (_img.Uid == card.Value.Id.ToString())
                {
                    selectedCard = card.Value;
                    break;
                }
            }
            if (selectedCard.GetType() == typeof(Favor) || selectedCard.GetType() == typeof(Pair))
            {
                p.SelectCard(selectedCard.Id);
                //Todo choose player thing; Make sure to deselect card after
            }
            else
            {
                p.PlayCard(selectedCard);
                ClearBoard();
                NopeTrack.Visibility = Visibility.Visible;
            }
        }

        private void PlayOverlay_Nope_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddNopeTrackBtns();
            PlayerNope playerNope = sender as PlayerNope;
            Player p = game.GetSelectedPlayer(playerNope.Id);
            Card c = p.Hand.GetNope();
            if (c.GetType() == typeof(NullCard))
            {
                MessageBox.Show($"Sorry, {p.Name}, but you don't have any Nope cards.");//todo MessageBox
            }
            else
            {
                p.PlayCard(c);
                MessageBox.Show($"{p.Name} noped your card, {game.ActivePlayer.Name}");//todo MessageBox
                NopeTrack.Visibility = Visibility.Hidden;
                PlayOverlay.Visibility = Visibility.Hidden;
                ShowHand();
            }
        }

        private void PlayOverlay_NoNopes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NopeTrack.Visibility = Visibility.Hidden;
            PlayOverlay.Visibility = Visibility.Hidden;
            ShowHand();
        }
        #endregion

        #region Hover Events

        private void DrawBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/card_draw_hover.png"));
        }

        private void DrawBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/card_draw.png"));
        }

        private void PlayOverlay_Back_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_back_hover.png"));
        }

        private void PlayOverlay_Back_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_back.png"));
        }

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

        private void PlayOverlay_Play_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_play_hover.png"));
        }

        private void PlayOverlay_Play_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/game_play.png"));
        }

        private void PlayOverlay_Nope_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nope_hover.png"));
        }

        private void PlayOverlay_Nope_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nope.png"));
        }

        private void PlayOverlay_NoNopes_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nonope_hover.png"));
        }

        private void PlayOverlay_NoNopes_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nonope.png"));
        }
        #endregion

    }
}