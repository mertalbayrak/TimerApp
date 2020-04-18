using System.Windows;
using System.Security.Principal;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
