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

namespace KidzCodeTurtlebot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<string> cmdTextBox;

        public MainWindow()
        {
            InitializeComponent();

            cmdTextBox = new List<string>();
            cmdTextBox.Add("Turtlebot Drive Commands:\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());
        }

        private void straightButton_Click(object sender, RoutedEventArgs e)
        {
            cmdTextBox.Add("Straight\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            cmdTextBox.Add("Right\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            cmdTextBox.Add("Left\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (cmdTextBox.Count > 1)
            {
                cmdTextBox.RemoveAt(cmdTextBox.Count - 1);
                driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());
            }
        }
    }
}
