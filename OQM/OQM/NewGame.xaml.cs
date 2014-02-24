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
using System.Windows.Media.Imaging;

namespace OQM
{
    public partial class NewGame : PhoneApplicationPage
    {
        public NewGame()
        {
            InitializeComponent();
        }

        private void image1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            reload_dice();
        }

        private void reload_dice()
        {
            Random r = new Random();

            int v = r.Next(6) + 1;
            string path = "/OQM;component/Dice" + v + ".png";
            image1.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Jeu.xaml", UriKind.Relative));
        }


    }
}