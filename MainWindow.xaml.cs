using Armandaa.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace Armandaa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SecondaryWindow secondaryWindow;

        public ViewModel viewModel { get; set; }
        // Declare a timer object
        private DispatcherTimer countdownTimer;
        private DateTime endTime;

        public MainWindow()
        {
            InitializeComponent();

            // Create a new instance of the ViewModel class
            viewModel = new ViewModel();

            // Set the DataContext to the ViewModel instance
            this.DataContext = viewModel;
            
        }

        // Timer tick event handler
        private void Timer_Tick(object sender, EventArgs e)
        {

            // Calculate the time remaining
            TimeSpan remainingTime = endTime - DateTime.Now;

            // Update the text block
            timeTextBlock.Content = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                                     remainingTime.Hours,
                                                     remainingTime.Minutes,
                                                     remainingTime.Seconds);

            // Check if the time is up
            if (remainingTime.TotalSeconds <= 0)
            {
                // Stop the timer
                //countdownTimer.Stop();
                timeTextBlock.Background = Brushes.Firebrick;timeTextBlock.Foreground = Brushes.White;
                // Show a message box
                responseTextBlock.Background = Brushes.Red; responseTextBlock.Foreground = Brushes.White;
                responseTextBlock.Content = "Time's up!";
            }


            
           
           
           
        }

        private void GoLive_Click(object sender, RoutedEventArgs e)
        {
            if (secondaryWindow == null)
            {
                secondaryWindow = new SecondaryWindow
                {
                    Title = "Monitor Window",
                    //WindowState = WindowState.Maximized,
                    Topmost = true,
                    //WindowStyle = WindowStyle.None,
                    //AllowsTransparency = true,
                    Background = Brushes.Transparent
                };
                secondaryWindow.Closed += MonitorScreenCloseBtn;

                // Set the window to be displayed on the secondary monitor
                secondaryWindow.WindowStartupLocation = WindowStartupLocation.Manual;
                // Add a TextBlock to display the text

                // Update the TextValue property of the view model
                viewModel.TextValue = inputTextBox2.Text;
                // Update the value of TextValue
                //TextValue = inputTextBox2.Text;
                secondaryWindow.UpdateOutputText(viewModel.TextValue);
                //if (secondaryWindow == null)
                //{
                //    secondaryWindow = new SecondaryWindow();
                //    secondaryWindow.Closed += MyWindow_Closed;
                //}
                //// Create an instance of the MainWindow class
                //MainWindow mainWindow = new MainWindow();
                //secondaryWindow.DataContext = mainWindow;
                secondaryWindow.Show();


            }
        }
        private void MyWindow_Closed(object sender, EventArgs e)
        {
            secondaryWindow = null;
        }
        private void MonitorScreenCloseBtn(object sender, EventArgs e)
        {
            //secondaryWindow = null;
            // Close the secondary window
           // secondaryWindow.Close();

            // Get a reference to the window you want to close
            Window windowToClose = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.Name == "SecondaryWindow");

            // Check if the window is open
            if (windowToClose != null)
            {
                // Clear the TextValue property of the view model
                //viewModel.TextValue = "";
                // Close the window
               windowToClose.Close();
            }
        }

        // Button click event handler to start the timer
        private void Start_Timer_Click(object sender, RoutedEventArgs e)
        {

            // Set the end time to 10 minutes from now
            int setMinutes = Convert.ToInt16(TxtTimer.Text);
            endTime = DateTime.Now.AddMinutes(setMinutes);

            // Create the DispatcherTimer
            countdownTimer = new DispatcherTimer();
            countdownTimer.Interval = TimeSpan.FromSeconds(1);
            countdownTimer.Tick += Timer_Tick;
            timeTextBlock.Background =Brushes.White; timeTextBlock.Foreground = Brushes.Black;
            // Show a message box
            responseTextBlock.Background = Brushes.White; responseTextBlock.Foreground = Brushes.Black;
            responseTextBlock.Content = "";
            // Start the timer
            countdownTimer.Start();
        }

        private void StopBtnTimer_Click(object sender, RoutedEventArgs e)
        {
            TxtTimer.Text = "";
            countdownTimer.Stop();
           
        }
    }

}
