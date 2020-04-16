using System.Windows;
using System.Security.Principal;

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
            startText.Text += "Merhaba, "; //+ WindowsIdentity.GetCurrent().Name;
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
