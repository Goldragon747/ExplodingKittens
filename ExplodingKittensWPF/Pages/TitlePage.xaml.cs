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
    /// Interaction logic for TitlePage.xaml
    /// </summary>
    public partial class TitlePage : Page
    {
        public TitlePage()
        {
            InitializeComponent();
        }

        private void title_imploding_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_imploding_unchecked_hover.png", UriKind.Relative));
        }

        private void title_imploding_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_imploding_unchecked.png", UriKind.Relative));
        }

        private void title_instructions_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_instructions_hover.png", UriKind.Relative));
        }

        private void title_instructions_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_instructions.png", UriKind.Relative));
        }

        private void title_play_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_play_hover.png", UriKind.Relative));
        }

        private void title_play_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_play.png", UriKind.Relative));
        }

        private void title_load_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_load_hover.png", UriKind.Relative));
        }

        private void title_load_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri($"../Assets/TitleScreen/title_load.png", UriKind.Relative));
        }

        private void title_slider_players_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Slider slider = (Slider)sender;
                switch (slider.Value)
                {
                    case 2:
                        title_textbox_player_3.Visibility = Visibility.Collapsed;
                        title_textbox_player_4.Visibility = Visibility.Collapsed;
                        title_textbox_player_5.Visibility = Visibility.Collapsed;
                        break;
                    case 3:
                        title_textbox_player_3.Visibility = Visibility.Visible;
                        title_textbox_player_4.Visibility = Visibility.Collapsed;
                        title_textbox_player_5.Visibility = Visibility.Collapsed;
                        break;
                    case 4:
                        title_textbox_player_3.Visibility = Visibility.Visible;
                        title_textbox_player_4.Visibility = Visibility.Visible;
                        title_textbox_player_5.Visibility = Visibility.Collapsed;
                        break;
                    case 5:
                        title_textbox_player_3.Visibility = Visibility.Visible;
                        title_textbox_player_4.Visibility = Visibility.Visible;
                        title_textbox_player_5.Visibility = Visibility.Visible;
                        break;

                }
            }
            catch (Exception) { }
        }
        private void title_play_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int playerCount = (int)title_slider_players.Value;
            string[] players = new string[playerCount];
            players[0] = title_textbox_player_1.Text == "" ? "Player 1" : title_textbox_player_1.Text;
            players[1] = title_textbox_player_2.Text == "" ? "Player 2" : title_textbox_player_2.Text;
            if(playerCount > 2)
            {
                players[2] = title_textbox_player_3.Text == "" ? "Player 3" : title_textbox_player_3.Text;
            }
            if(playerCount > 3)
            {
                players[3] = title_textbox_player_4.Text == "" ? "Player 4" : title_textbox_player_4.Text;
            }
            if(playerCount > 3)
            {
                players[4] = title_textbox_player_5.Text == "" ? "Player 5" : title_textbox_player_5.Text;
            }
            this.NavigationService.Navigate(new GamePage(playerCount, players));
        }
    }
}
