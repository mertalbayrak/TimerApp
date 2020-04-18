using System.Windows;
using System.Security.Principal;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Diagnostics;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for Notification1.xaml
    /// </summary>
    public partial class Notification : Window
    {
        public Notification()
        {
            InitializeComponent();
            var rand = new Random();
            int fotonum = rand.Next(5);
            //String foto = "./images/" + fotonum + ".jpg";
            String foto = fotonum + ".jpg";
            Debug.WriteLine("deneme: " + foto);
            Image workout1 = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(foto, UriKind.Relative);
            //bitmap.UriSource = new Uri("pack://application:,,,/TimerApp;component/TimerApp/images/workout1.png", UriKind.Relative);
            bitmap.EndInit();

            // Set Image.Source  
            workout1.Source = bitmap;
            workout1.Height = 200;
            workout1.Width = 300;
            
            stackPanel1.Children.Add(workout1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
