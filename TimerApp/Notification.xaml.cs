using System.Windows;
using System.Security.Principal;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Threading.Tasks;

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
            int pictureId = rand.Next(5);
            //String foto = "./images/" + pictureId + ".jpg";
            String picture = pictureId + ".jpg";
            Debug.WriteLine("deneme: " + picture);
            Image workout1 = new Image();
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(picture, UriKind.Relative);
            //bitmap.UriSource = new Uri("pack://application:,,,/TimerApp;component/TimerApp/images/workout1.png", UriKind.Relative);
            bitmap.EndInit();

            // Set Image.Source  
            workout1.Source = bitmap;
            workout1.Height = 200;
            workout1.Width = 300;
            label1.Content = GetText(pictureId);
            stackPanel1.Children.Add(workout1);
        }
        private String GetText(int pictureId)
        {
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode;
            FileStream fs = new FileStream("workoutDescription.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Picture");
            xmlnode[pictureId].ChildNodes.Item(0).InnerText.Trim();
            return xmlnode[pictureId].ChildNodes.Item(1).InnerText.Trim() + "\n" + xmlnode[pictureId].ChildNodes.Item(2).InnerText.Trim(); 
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            OnButtonClick();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
         
        }
        async void OnButtonClick()
        {
         
             await Task.Run(() =>
             {
                 CmdService cmdService = new CmdService("cmd.exe");
             string output = cmdService.ExecuteCommand("python demo_2d.py");
             Console.WriteLine(">>>>>> {0}", output);
                 /*          ProcessStartInfo pythonInfo = new ProcessStartInfo(@"C:\Users\is96417\AppData\Local\Programs\Python\Python38\python.exe");
                           Process python;
                           pythonInfo.CreateNoWindow = false;
                           pythonInfo.UseShellExecute = false;
                           //pythonInfo.WindowStyle = ProcessWindowStyle.Normal;
                           pythonInfo.Arguments = string.Format("{0} {1} {2}", Path.Combine(Environment.CurrentDirectory, @"demo_2d.py"), 5, 10);

                           Console.WriteLine("Python Starting");
                           python = Process.Start(pythonInfo);


                           python.WaitForExit();
                           //python.Close();

                           Console.ReadLine();
                           //Console.ReadKey();*/

        }); 
        } 
    }
}
