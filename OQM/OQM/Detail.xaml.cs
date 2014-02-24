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
    public partial class detail : PhoneApplicationPage
    {
        carte focus;

        public detail()
        {
            InitializeComponent();
            focus = ((App)Application.Current).data.Hand[((App)Application.Current).data.index];
            image1.Source = focus.BitImg;
            textBlock1.Text = focus.Content;
            textBlock2.Text = focus.Type;
            textBlock3.Text = focus.Titre;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                ((App)Application.Current).data.Hand.RemoveAt(((App)Application.Current).data.index);
                Jeu.Main.RemoveAt(((App)Application.Current).data.index);
                // this.NavigationService.Navigate(new Uri("/Jeu.xaml", UriKind.Relative));
                this.NavigationService.GoBack();
            }
        }
    }
}