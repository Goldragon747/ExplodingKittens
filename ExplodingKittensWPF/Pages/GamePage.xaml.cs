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
        private bool stealIsValid = true;
        private Image sCard;
        private int bombId;

        public GamePage(int numOfPlayers, string[] playerNames)
        {
            InitializeComponent();
            game = new Game(numOfPlayers, playerNames);

            NopeTrack.Visibility = Visibility.Hidden;
            PlayOverlay.Visibility = Visibility.Hidden;
            PlayerSelectPanel.Visibility = Visibility.Hidden;
            StartPlayerTurn();
        }

        private void AddNopeTrackBtns()
        {
            Image img = PlayOverlay_NoNopes;
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
            NopeTrack.Children.Add(img);
        }

        private void AddPlayerSelectPanelBtns()
        {
            PlayerSelectPanel.Children.Clear();
            Player p = game.ActivePlayer;
            for (int i = 0; i < game.Players.Count; i++)
            {
                if (!p.IsActive)
                {
                    PlayerSelect select = new PlayerSelect();
                    select.PlayerName = p.Name;
                    select.Id = p.Id;
                    select.MouseDown += PlayerSelectPanel_MouseDown;
                    select.Margin = new Thickness(0, 0, 0, 20);
                    PlayerSelectPanel.Children.Add(select);
                }
                p = game.GetNextPlayer(p);
            }
        }

        private void ShowHand()
        {
            PlayOverlay_Back.Visibility = Visibility.Visible;
            PlayOverlay_Play.Visibility = Visibility.Visible;
            PlayOverlay_Steal_Random.Visibility = Visibility.Visible;
            PlayOverlay_Steal_Specific.Visibility = Visibility.Visible;
            bool underAttack = false;
            if (game.ActivePlayer != null)
                 underAttack = game.ActivePlayer.IsUnderAttack;
            PlayerName.Content = game.ActivePlayer.Name;
            if (underAttack) { TurnsRemaining.Content = "2 Turns Remaining"; }
            else { TurnsRemaining.Content = "1 Turn Remaining"; }
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
            PlayerName.Content = game.ActivePlayer.Name;
            if (underAttack) { TurnsRemaining.Content = "2 Turns Remaining"; }
            else { TurnsRemaining.Content = "1 Turn Remaining"; }

            MessageBox.Show($"{game.ActivePlayer.Name}, get ready for your turn.");//todo MessageBox
            ShowHand();

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


        #region Mouse Downs
        private void DrawBtn_Click(object sender, RoutedEventArgs e)
        {
            WPFPlayer p = new WPFPlayer(game.ActivePlayer.Id, game, game.ActivePlayer.Name);
            p.Hand = game.ActivePlayer.Hand;
            p.IsUnderAttack = game.ActivePlayer.IsUnderAttack;
            int num = p.Hand.Cards.Count;
            bool bombnext = game.Deck.DrawPile.Peek().GetType() == typeof(ExplodingKitten);
            bool hasDefuse = p.Hand.GetDefuse().GetType() == typeof(Defuse);
            p.DrawCard();
            if (bombnext)
            {
                //Card bomb = game.Deck.PlayPile.Pop();
                Card defuse = p.Hand.GetDefuse();
                Card bomb = p.Hand.GetBomb();
                if (hasDefuse)
                {
                    bombId = bomb.Id;
                    p.Hand.Cards.Remove(defuse.Id);
                    p.Hand.Cards.Remove(bomb.Id);
                    MessageBox.Show($"Fwew, you drew an Exploding Kitten, but you had a defuse.");//todo MessageBox
                    //game.ActivePlayer.Hand.Cards.Add(bomb.Id, bomb);
                    //game.ActivePlayer.SelectCard(bomb.Id);
                    //ExplodePanel_Slider.Maximum = game.Deck.DrawPile.Count;

                    //ExplodePanel.Visibility = Visibility.Visible;
                    //PlayOverlay.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show($"Oh no! You drew an Exploding Kitten, but you didn't have a defuse.");//todo MessageBox
                    if (game.Players.Count == 1)
                    {
                        this.NavigationService.Navigate(new VictoryPage(game.Players.First.Value.Name));
                    }
                }
            }
            //game.ActivePlayer.Hand = p.Hand;
            //game.ActivePlayer.IsUnderAttack = p.IsUnderAttack;
            if (!game.HasFinished)
            {
                ShowHand();
                if (!game.ActivePlayer.IsUnderAttack)
                {
                    MessageBox.Show("Your turn is now over.");//todo MessageBox
                }
                if (!bombnext)
                {
                    game.ActivePlayer.Hand = p.Hand;
                    game.ActivePlayer.IsUnderAttack = p.IsUnderAttack;
                }
                game.EndTurn();
                ClearBoard();
                StartPlayerTurn();
            }


        }

        private void PlayerCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlayOverlay.Visibility = Visibility.Visible;
            Image _img = sender as Image;
            PlayOverlay_Card.Source = _img.Source;
            game.ActivePlayer.Hand.SelectedCard.IsSelected = false;
            int.TryParse(_img.Uid, out int temp);
            game.ActivePlayer.Hand.Cards[temp].IsSelected = true;

            Card selectedCard = null;
            foreach (KeyValuePair<int, Card> card in game.ActivePlayer.Hand.Cards)
            {
                if (_img.Uid == card.Value.Id.ToString())
                {
                    selectedCard = card.Value;
                    break;
                }
            }
            int num = 0;
            foreach (KeyValuePair<int, Card> card in game.ActivePlayer.Hand.Cards)
            {
                if (card.Value.GetType() == selectedCard.GetType()) { num++; }
            }
            if (num < 2)
            {
                //todo disable steal 2 and 3
            }
            else if (num < 3)
            {
                //todo disable steal 3
            }
            sCard = _img;
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
            WPFPlayer p = new WPFPlayer(game.ActivePlayer.Id, game, game.ActivePlayer.Name);
            //Player p = game.ActivePlayer;
            p.Hand = game.ActivePlayer.Hand;
            p.IsUnderAttack = game.ActivePlayer.IsUnderAttack;
            Image _img = new Image();
            _img.Source = PlayOverlay_Card.Source;
            _img.Uid = PlayOverlay_Card.Uid;
            Card selectedCard = null;
            foreach (KeyValuePair<int, Card> card in game.ActivePlayer.Hand.Cards)
            {
                if (sCard.Uid == card.Value.Id.ToString())
                {
                    selectedCard = card.Value;
                    break;
                }
            }
            if (selectedCard.GetType() == typeof(Favor) || selectedCard.GetType() == typeof(Pair))
            {
                p.SelectCard(selectedCard.Id);
                AddPlayerSelectPanelBtns();
                PlayerSelectPanel.Visibility = Visibility.Visible;
            }
            else if (selectedCard.GetType() == typeof(Attack))
            {
                p.PlayCard(selectedCard);
                Player prev = game.PreviousPlayer;
                game.ActivePlayer.IsActive = false;
                prev.IsActive = true;
                ClearBoard();
                AddNopeTrackBtns();
                NopeTrack.Visibility = Visibility.Visible;
            }
            else
            {
                p.PlayCard(selectedCard);
                Player prev = game.PreviousPlayer;
                game.ActivePlayer.IsActive = false;
                prev.IsActive = true;
                ClearBoard();
                AddNopeTrackBtns();
                NopeTrack.Visibility = Visibility.Visible;
            }
            game.EndTurn();
            game.ActivePlayer.Hand = p.Hand;
            game.ActivePlayer.IsUnderAttack = p.IsUnderAttack;
        }

        private void PlayOverlay_Nope_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //AddNopeTrackBtns();
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
                PlayOverlay_Back.Visibility = Visibility.Visible;
                PlayOverlay_Play.Visibility = Visibility.Visible;
                PlayOverlay_Steal_Random.Visibility = Visibility.Visible;
                PlayOverlay_Steal_Specific.Visibility = Visibility.Visible;
                ShowHand();
            }
        }

        private void PlayOverlay_NoNopes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NopeTrack.Visibility = Visibility.Hidden;
            PlayOverlay.Visibility = Visibility.Hidden;
            PlayOverlay_Back.Visibility = Visibility.Visible;
            PlayOverlay_Play.Visibility = Visibility.Visible;
            PlayOverlay_Steal_Random.Visibility = Visibility.Visible;
            PlayOverlay_Steal_Specific.Visibility = Visibility.Visible;
            if (game.Deck.PlayPile.Peek().GetType() == typeof(Attack))
            {
                game.EndTurn();
                game.ActivePlayer.IsUnderAttack = true;
                StartPlayerTurn();
            }
            else
            {
                ShowHand();
            }
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

        private void ExplodePanel_Place_Bomb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ExplodePanel.Visibility = Visibility.Hidden;
            int position = (int)ExplodePanel_Slider.Value;
            List<Card> pile = new List<Card>();
            WPFDeck temp = new WPFDeck(game, game.Players.Count);
            Card bomb = temp.FindCardById(bombId);
            bomb.IsSelected = false;
            game.ActivePlayer.Hand.Cards.Remove(bomb.Id);
            for (int i = 0; i < game.Deck.DrawPile.Count + 1; i++)
            {
                if (i == position)
                {
                    pile.Add(bomb);
                }
                else
                {
                    pile.Add(game.Deck.DrawPile.Pop());
                }
            }
            pile.Reverse();
            game.Deck.DrawPile = new Stack<Card>(pile);
            game.EndTurn();
            ClearBoard();
            StartPlayerTurn();
        }

        private void ExplodePanel_Place_Bomb_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_place_bomb_hover.png"));
        }

        private void ExplodePanel_Place_Bomb_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_place_bomb.png"));
        }


        private void PlayerSelectPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Todo Make sure to deselect card after
            PlayerSelect playerSelect = sender as PlayerSelect;
            Player p = game.GetSelectedPlayer(playerSelect.Id);
            Card c = game.ActivePlayer.Hand.SelectedCard;
            c.IsSelected = false;
            game.Deck.PlayPile.Push(c);
            game.ActivePlayer.Hand.Cards.Remove(c.Id);
            Card taken = p.Hand.RemoveRandomCard();
            game.ActivePlayer.Hand.Cards.Add(taken.Id, taken);
            PlayerSelectPanel.Visibility = Visibility.Hidden;
            ClearBoard();
            AddNopeTrackBtns();
            NopeTrack.Visibility = Visibility.Visible;
        }

        private void PlayerSelectPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_select_hover.png"));
        }

        private void PlayerSelectPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_select.png"));
        }
    }
}