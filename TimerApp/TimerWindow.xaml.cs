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
using System.DirectoryServices.AccountManagement;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TimerWindow : Window
    {
        private UserPrincipal userPrincipal;
        private PrincipalContext principalContext;
        private int second, sectorNo;
        private Dictionary<string, string> sectorList = new Dictionary<string, string>();
        private DateTime dateTime;
        private DateTime? loggedDateTime;
        public TimerWindow()
        {
            InitializeComponent();
            sectorList.Clear();
            second = 1;
            sectorNo = 0;
            //loggedDateTime = GetLastLoginToMachine();
            dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTick;
            timer.Start();
        }

        public void TimerTick(object sender, EventArgs e)
        {
            //MessageBox.Show(loggedDateTime.ToString());
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

        //public static DateTime? GetLastLoginToMachine()
        //{
        //    string username = WindowsIdentity.GetCurrent().Name.Split(@"\")[0];
        //    string machineName = WindowsIdentity.GetCurrent().Name.Split(@"\")[1];
        //    PrincipalContext principalContext = new PrincipalContext(ContextType.Machine, username);
        //    UserPrincipal userPrincipal = UserPrincipal.FindByIdentity(principalContext, machineName);
        //    return userPrincipal.LastLogon;
        //}



    }


}
