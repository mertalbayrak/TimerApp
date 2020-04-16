using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
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
        private String text;
        public TimerWindow()
        {
            SystemEvents.SessionSwitch += new SessionSwitchEventHandler(SystemEventsSessionSwitch);
            InitializeComponent();
            sectorList.Clear();
            totalWorkedHour = new List<string>();
            totalWorkedHour.Clear();
            second = 1;
            sectorNo = 0;
            //dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
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

            if (second == 30)
            {
                MessageBox.Show("Zaman Geldi :)");
            }
            timerText.Text = GetTimerFormat(dateTime);
            text = timerText.Text;
            if (timerText.Text == "00:00:10")
            {
                
                sectorNo++;
                sectorList.Add(sectorNo.ToString("00"), timerText.Text);
                foreach (KeyValuePair<string, string> item in sectorList)
                {
                    Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                    Console.ReadLine();
                    Debug.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                }

                this.popup.IsOpen = true; //opens our custom msgbox

           //     if (this.popup.IsOpen == true)
             //   {
               //     scrollviewerCustom.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled; //disables the scrollviewer
                 //   this.ApplicationBar.Disable(); //disables the application bar
              //  }

                MessageBox.Show("Mola vermen gerekiyor :)" + sectorList);

                
            }
        }

        //on click of OK button
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.popup.IsOpen = false; //closes our msgbox
        //    scrollviewerCustom.VerticalScrollBarVisibility = ScrollBarVisibility.Visible; //enables the scrollviewer
         //  this.ApplicationBar.Enable(); //enables the application bar
        }

        private string GetTimerFormat(DateTime dateTime)
        {
            dateTime = dateTime.AddSeconds(second++);
            timelbl.Content = dateTime.ToLongTimeString();
            datelbl.Content = DateTime.Now.ToLongDateString();
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

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
    }


}
