using Armandaa.ViewModels;
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
using System.Windows.Shapes;

namespace Armandaa
{
    /// <summary>
    /// Interaction logic for SecondaryWindow.xaml
    /// </summary>
    public partial class SecondaryWindow : Window
    {
        public ViewModel viewModel { get; set; }
        public SecondaryWindow()
        {
            InitializeComponent();
           
        }

        public SecondaryWindow(ViewModel vm)
        {
            InitializeComponent();
            // Set the DataContext to the shared ViewModel instance
            this.DataContext = vm;
        }

        public void UpdateOutputText(string text)
        {
            outputTextBox.Text = text;
        }
    }

}
