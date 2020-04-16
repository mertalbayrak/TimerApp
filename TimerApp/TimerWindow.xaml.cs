using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using Microsoft.Win32;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        private int second, sectorNo;
        private Dictionary<string, string> sectorList = new Dictionary<string, string>();
        private DispatcherTimer timer;
        private DateTime dateTime;
        private List<string> totalWorkedHour;
        public TimerWindow()
        {
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEventsSessionSwitch);
            InitializeComponent();
            sectorList.Clear();
            totalWorkedHour = new List<string>();
            totalWorkedHour.Clear();
            second = 1;
            sectorNo = 0;
            dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();
        }
        ~TimerWindow()
        {
            SystemEvents.SessionSwitch -= new SessionSwitchEventHandler(SystemEventsSessionSwitch);
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
            return dateTime.ToString("HH:mm:ss");
        }

        private void SystemEventsSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //I left my desk
                //toplam çalışma süresi için şimdilik sırf listeye ekleme yapılıyor. Bu eklenen süreler toplanıp kullanıcıya çalışma süresi gösterilebilir.
                totalWorkedHour.Add(timerText.Text);
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                //I returned to my desk
                dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                second = 1;
            }
        }
    }
}
