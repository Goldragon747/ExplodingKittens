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

namespace ExplodingKittensWPF.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerNope.xaml
    /// </summary>
    public partial class PlayerNope : UserControl
    {
        public string PlayerName
        {
            get
            {
                return PlayerNameLabel.Content.ToString();
            }
            set
            {
                PlayerNameLabel.Content = value;
            }
        }

        public PlayerNope()
        {
            InitializeComponent();

        }

        private void PlayOverlay_Nope_MouseDown(object sender, MouseButtonEventArgs e) { }

        private void PlayOverlay_Nope_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nope_hover.png"));
        }

        private void PlayOverlay_Nope_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Image)sender).Source = new BitmapImage(new Uri("pack://application:,,,/ExplodingKittensWPF;component/Assets/GameScreen/Buttons/button_nope.png"));
        }
    }
}
