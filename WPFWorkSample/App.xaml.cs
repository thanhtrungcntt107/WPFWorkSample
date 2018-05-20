using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WPFWorkSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);
        private const int SW_MAXIMIZE = 3;
        private const int SW_SHOWNORMAL = 1;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        static readonly IntPtr HWND_TOP = new IntPtr(0);

        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);

        const UInt32 SWP_NOSIZE = 0x0001;

        const UInt32 SWP_NOMOVE = 0x0002;

        const UInt32 TOPMOST_FLAGS = SWP_NOMOVE | SWP_NOSIZE;

        /// <summary>
        /// /d
        /// </summary>
        [DllImport("user32", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string cls, string win);
        [DllImport("user32")]
        static extern IntPtr SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32")]
        static extern bool OpenIcon(IntPtr hWnd);


        // give the mutex a  unique name
        private string MutexName = "##||ThisApp||##";
        // declare the mutex
        private Mutex _mutex;
        // overload the constructor
        bool createdNew;
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //this.StartupUri = new Uri("Views/Dashboard.xaml", UriKind.Relative);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (e.Args.Length > 0)
                MutexName = e.Args[0];
            // overloaded mutex constructor which outs a boolean
            // telling if the mutex is new or not.
            // see http://msdn.microsoft.com/en-us/library/System.Threading.Mutex.aspx
            _mutex = new Mutex(true, MutexName, out createdNew);
            if (!createdNew)
            {
                // if the mutex already exists, notify and quit
                MessageBox.Show("This program is already running");
                //Application.Current.Shutdown(0);
            }


            if (!createdNew)
            {
                ActivateOtherWindow();
                //var procs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
                //foreach (var p in procs.Where(p => p.MainWindowHandle != IntPtr.Zero))
                //{
                //    ShowWindow(p.MainWindowHandle, SW_MAXIMIZE);
                //    SetWindowPos(p.Handle, HWND_TOPMOST, 0, 0, 0, 0, TOPMOST_FLAGS);
                //    Application.Current.Shutdown(0);
                //    return;
                //}
                Application.Current.Shutdown(0);
                return;
                // overload the OnStartup so that the main window 
                // is constructed and visible
            }

            //String[] args = System.Environment.GetCommandLineArgs();
            // opened by double clicking project file (passed in filename as command line arguments)
            if (e.Args.Length > 0)
            {
                StringBuilder msg = new StringBuilder();
                for(int i = 0; i< e.Args.Length; i++)
                {
                    msg.AppendLine(string.Format("Param {0}: {1}", i, e.Args[i]));
                }

                MessageBox.Show(msg.ToString(), "e.Args");
                this.MainWindow.Title = MutexName;
                this.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);

            }
            // open application directly
            else
            {
                this.StartupUri = new Uri("Views/Dashboard.xaml", UriKind.Relative);
            }
        }

        private void ActivateOtherWindow()
        {
            var other = FindWindow(null, MutexName);
            if (other != IntPtr.Zero)
            {
                SetForegroundWindow(other);
                if (IsIconic(other))
                    OpenIcon(other);
            }
        }

        public bool  CheckSingleInstanceCheck(string saleOrder)
        {
            bool isExisted = false;
            // get all app open
            Application current = App.Current;

            return isExisted;
        }

        //public Application RunApp(string path)
        //{
        //    Application app = Application.AttachOrLaunch(new System.Diagnostics.ProcessStartInfo(path));
        //    return app;
        //}

        public void GetAllsWindowInApplication()
        {
            foreach (Window window in Application.Current.Windows)
            {
                Console.WriteLine(window.Title);
            }
        }
    }
}
