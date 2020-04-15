using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.DirectoryServices;
using System.Security.Principal;
using System.Net;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PasswordDirectory passwordDirectory;
        private TimerWindow timerWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timerWindow = new TimerWindow();
            timerWindow.Show();
            this.Close();
            //if (usernameBox.Text == WindowsIdentity.GetCurrent().Name)
            //{
            //    passwordDirectory = new PasswordDirectory(usernameBox.Text);
            //    timerWindow = new TimerWindow();
            //    timerWindow.Show();
            //    this.Close();
            //}
            //else
            //{
            //    MessageBox.Show("Yasak giremezsin");
            //}
        }

     
    }

    //public DateTime? GetLastLoginToMachine(string machineName, string userName)
    //{
    //    PrincipalContext c = new PrincipalContext(ContextType.Machine, machineName);
    //    UserPrincipal uc = UserPrincipal.FindByIdentity(c, userName);
    //    return uc.LastLogon;
    //}
}
