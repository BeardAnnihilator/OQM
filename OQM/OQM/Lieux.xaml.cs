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
    public partial class Lieux : PhoneApplicationPage
    {
        private ObservableCollection<place> cache = new ObservableCollection<place>();
        public ObservableCollection<place> Cache
        { 
            get {
                return cache;
        }
            set {
                cache = value;

            }
        }

        public Lieux()
        {
            InitializeComponent();
//            Cache = ((App)Application.Current).data.Placelist;
            Cache = ((App)Application.Current).data.Placelist;
            listBox1.ItemsSource = Cache;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
                MessageBox.Show("Vous devez sélectionner un lieu pour le supprimer.", "Oops!", MessageBoxButton.OK);
            else
            {
                ((App)Application.Current).data.Placelist.RemoveAt(listBox1.SelectedIndex);
                Cache = ((App)Application.Current).data.Placelist;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/Add.xaml", UriKind.Relative));
        }
    }
}