using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace HospitalSysWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.Tick += Timer_Tick;
            timer.Start();

            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    btnMax.Content = "☐";
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    btnMax.Content = "❐";
                }

            };
            btnClose.Click += (s, e) =>
            {
                this.Close();
            };

            colorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            colorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                    btnMax.Content = "☐";
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    btnMax.Content = "❐";
                }

            };
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lbl_Time.Content = DateTime.Now.ToString("F"); ;
        }
    }
}
