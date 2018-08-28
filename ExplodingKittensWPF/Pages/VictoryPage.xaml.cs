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
    /// Interaction logic for VictoryPage.xaml
    /// </summary>
    public partial class VictoryPage : Page
    {
        public VictoryPage(string name)
        {
            InitializeComponent();
            victor.Content = name + " WINS!";
        }

        private void victory_back_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new TitlePage());
        }
    }
}
