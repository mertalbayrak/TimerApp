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
            //startText.Text += "WELLCOME"; //+ WindowsIdentity.GetCurrent().Name;
            usernameText.Text = WindowsIdentity.GetCurrent().Name;

            //OnButtonClick();
            

            //  using (CmdService cmdService = new CmdService("cmd.exe"))
            //  {
            //      string consoleCommand = string.Empty;
            //      do
            //     {
            //         consoleCommand = Console.ReadLine();
            //         string output = cmdService.ExecuteCommand(consoleCommand);
            //         Console.WriteLine(">>>>>> {0}", output);
            //     }
            //     while (!String.IsNullOrEmpty(consoleCommand));

            //   }




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
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            timerWindow = new TimerWindow();
            timerWindow.Show();
            this.Close();
        }
    }
}
