using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfAppSecond
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // D:\Projects\WPF Sample\WPFWorkSample\WPFWorkSample\bin\Debug

            string uriString = @"D:\Projects\WPF Sample\WPFWorkSample\WPFWorkSample\bin\Debug\WPFWorkSample.exe";
            Uri uri = new Uri(uriString);
            //await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);

            Process myProcess = new Process();
            //MyProcess.StartInfo.FileName = Environment.CurrentDirectory + "\\TestApp.exe";
            myProcess.StartInfo.FileName = uriString;
            myProcess.StartInfo.Arguments = "test1 test2 test3 \"parameter four\"";
            myProcess.Start();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string uriString = @"D:\Projects\WPF Sample\WPFWorkSample\WPFWorkSample\bin\Debug\WPFWorkSample.exe";
            Uri uri = new Uri(uriString);
            //await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);

            Process myProcess = new Process();
            //MyProcess.StartInfo.FileName = Environment.CurrentDirectory + "\\TestApp.exe";
            myProcess.StartInfo.FileName = uriString;
            myProcess.StartInfo.Arguments = "test4";
            myProcess.Start();
        }
    }
}
