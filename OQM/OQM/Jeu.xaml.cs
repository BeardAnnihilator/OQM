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
using System.Collections.ObjectModel;

namespace OQM
{
    public partial class Jeu : PhoneApplicationPage
    {
        public static bool gamestarted;
        private static ObservableCollection<carte> main = new ObservableCollection<carte>();
        public static ObservableCollection<carte> Main
        {
            get { return main; }
            set { main = value; }
        }
        private bool ok = false;
        public Jeu()
        {
            InitializeComponent();
            textBlock1.Visibility = System.Windows.Visibility.Collapsed;
            Main.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Main_CollectionChanged);
            listBox1.ItemsSource = Main;
            if (gamestarted)
            {
                button1.Content = "Mulligan ?";
                Main.Clear();
                foreach (carte c in ((App)Application.Current).data.Hand)
                {
                    Main.Add(c);
                }
            }
        }

        void Main_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Main.Count <= 0 && ok == false)
                textBlock1.Visibility = System.Windows.Visibility.Visible;
            ok = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (!gamestarted)
            {
                gamestarted = true;
                ((App)Application.Current).data.draw_random_card();
                Main.Add(((App)Application.Current).data.Hand.Last());
                ((App)Application.Current).data.draw_random_card();
                Main.Add(((App)Application.Current).data.Hand.Last());
                ((App)Application.Current).data.draw_random_card();
                Main.Add(((App)Application.Current).data.Hand.Last());
                ((App)Application.Current).data.draw_random_card();
                Main.Add(((App)Application.Current).data.Hand.Last());
                ((App)Application.Current).data.draw_random_extra();
                Main.Add(((App)Application.Current).data.Hand.Last());
                ((App)Application.Current).data.draw_random_extra();
                Main.Add(((App)Application.Current).data.Hand.Last());
                ((App)Application.Current).data.draw_random_extra();
                Main.Add(((App)Application.Current).data.Hand.Last());
                button1.Content = "Mulligan ?";
            }
            else
            {
                int tmp = ((App)Application.Current).data.Hand.Count - 1;
                ((App)Application.Current).data.remove_hand_cards();
                ok = true;
                Main.Clear();
                if (tmp > 0)
                {
                    int tmp2 = tmp / 2;
                    int tmp3 = tmp - tmp2;
                    for (int l = 0; l < tmp3; l++)
                    {
                        ((App)Application.Current).data.draw_random_card();
                        Main.Add(((App)Application.Current).data.Hand.Last());
                    }
                    for (int o = 0; o < tmp2; o++)
                    {
                        ((App)Application.Current).data.draw_random_extra();
                        Main.Add(((App)Application.Current).data.Hand.Last());
                    }
                    
                }
                else
                    textBlock1.Visibility = System.Windows.Visibility.Visible;
            }
        }


        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ((App)Application.Current).data.index = listBox1.SelectedIndex;
                this.NavigationService.Navigate(new Uri("/Detail.xaml", UriKind.Relative));
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/NewGame.xaml", UriKind.Relative));
        }

        private void listBox1_Tap(object sender, GestureEventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                ((App)Application.Current).data.index = listBox1.SelectedIndex;
                this.NavigationService.Navigate(new Uri("/Detail.xaml", UriKind.Relative));
            }
        }
    }
}