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

        private void title_play_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new GamePage());
        }
    }
}
