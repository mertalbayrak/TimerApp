using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Security.Principal;
using System.Net;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        private int second, sectorNo;
        private Dictionary<string, string> sectorList = new Dictionary<string, string>();
        private DateTime dateTime;
        public TimerWindow()
        {
            InitializeComponent();
            sectorList.Clear();
            second = 1;
            sectorNo = 0;
            dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();
        }

        public void TimerTick(object sender, EventArgs e)
        {
            timerText.Text = GetTimerFormat(dateTime);
            if (timerText.Text == "02:00:00")
            {
                MessageBox.Show("Mola vermen gerekiyor :)");
                sectorNo++;
                sectorList.Add(sectorNo.ToString("00"), timerText.Text);
            }
        }

        private string GetTimerFormat(DateTime dateTime)
        {
            dateTime = dateTime.AddSeconds(second++);
            string calculatedTime = String.Format("{0}:{1}:{2}", dateTime.Hour.ToString("00"), dateTime.Minute.ToString("00"), dateTime.Second.ToString("00"));
            return calculatedTime;
        }
     
    }

   
}
