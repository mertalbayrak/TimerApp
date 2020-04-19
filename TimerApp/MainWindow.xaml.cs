using System.Windows;
using System.Security.Principal;
using System.Diagnostics;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TimerWindow timerWindow;
        public MainWindow()
        {
            InitializeComponent();
            usernameText.Text = WindowsIdentity.GetCurrent().Name;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            timerWindow = new TimerWindow();
            timerWindow.Show();
            this.Close();
        }
    }
}
