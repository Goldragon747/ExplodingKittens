﻿using System;
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
    /// Interaction logic for InstructionsPage.xaml
    /// </summary>
    public partial class InstructionsPage : Page
    {
        public InstructionsPage()
        {
            InitializeComponent();
        }
        private void instructions_back_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new TitlePage());
        }
    }
}
