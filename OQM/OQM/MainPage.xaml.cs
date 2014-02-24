using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace OQM
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            ((App)Application.Current).data.remove_extra_cards();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            // navigate
            this.NavigationService.Navigate(new Uri("/Regles.xaml", UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // navigate
            this.NavigationService.Navigate(new Uri("/Lieux.xaml", UriKind.Relative));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (((App)Application.Current).data.Placelist.Count > 0)
            {
                ((App)Application.Current).data.make_extra_cards();
                ((App)Application.Current).data.remove_hand_cards();
                Jeu.Main.Clear();
                Jeu.gamestarted = false;
                this.NavigationService.Navigate(new Uri("/Jeu.xaml", UriKind.Relative));
            }
            else
                MessageBox.Show("Pour pouvoir jouer, il faut référencer au moins un lieu!", "Oops!", MessageBoxButton.OK);
        }
    }
}