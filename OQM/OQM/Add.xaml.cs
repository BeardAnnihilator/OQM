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
using Microsoft.Phone.Tasks;
using System.IO;


namespace OQM
{
    public partial class Add : PhoneApplicationPage
    {
        private string path = "/OQM;component/fourche.png";
        private bool passed = false;
        public Add()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (passed)
            ((App)Application.Current).data.Placelist.Add(new place(textBox1.Text, path));
            else
             ((App)Application.Current).data.Placelist.Add(new place(textBox1.Text));
            if (this.NavigationService.CanGoBack)
            this.NavigationService.GoBack();
        }
        PhotoChooserTask selectphoto = null;

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            selectphoto = new PhotoChooserTask();
         selectphoto.Completed += new EventHandler<PhotoResult>(selectphoto_Completed);
         selectphoto.Show();
        }

   void selectphoto_Completed(object sender, PhotoResult e)    
     {
         if (e.TaskResult == TaskResult.OK)
         {
             BinaryReader reader = new BinaryReader(e.ChosenPhoto);
             image1.Source = new BitmapImage(new Uri(e.OriginalFileName));
             path = e.OriginalFileName;
             passed = true;
         }
     }
    }
}