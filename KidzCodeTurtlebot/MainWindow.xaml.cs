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

        private List<Drive> payload;
        private List<string> cmdTextBox;

        enum Drive
        {
            STRAIGHT = (byte) 0,
            RIGHT = (byte) 1,
            LEFT = (byte) 2,
        }

        public MainWindow()
        {
            InitializeComponent();

            cmdTextBox = new List<string>();
            payload = new List<Drive>();

            cmdTextBox.Add("Turtlebot Drive Commands:\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Hidden;
            right_png.Visibility = Visibility.Hidden;
            left_png.Visibility = Visibility.Hidden;
        }

        private void straightButton_Click(object sender, RoutedEventArgs e)
        {
            payload.Add(Drive.STRAIGHT);

            cmdTextBox.Add("Straight\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Visible;
            right_png.Visibility = Visibility.Hidden;
            left_png.Visibility = Visibility.Hidden;
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            payload.Add(Drive.RIGHT);

            cmdTextBox.Add("Right\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Hidden;
            right_png.Visibility = Visibility.Visible;
            left_png.Visibility = Visibility.Hidden;
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            payload.Add(Drive.LEFT);

            cmdTextBox.Add("Left\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Hidden;
            right_png.Visibility = Visibility.Hidden;
            left_png.Visibility = Visibility.Visible;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (cmdTextBox.Count > 1)
            {
                cmdTextBox.RemoveAt(cmdTextBox.Count - 1);
                driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());
            }

            if (payload.Count > 1)
            {
                payload.RemoveAt(payload.Count - 1);

                switch (payload.ElementAt(payload.Count - 1))
                {
                    case Drive.STRAIGHT:
                        straight_png.Visibility = Visibility.Visible;
                        right_png.Visibility = Visibility.Hidden;
                        left_png.Visibility = Visibility.Hidden;
                        break;
                    case Drive.RIGHT:
                        straight_png.Visibility = Visibility.Hidden;
                        right_png.Visibility = Visibility.Visible;
                        left_png.Visibility = Visibility.Hidden;
                        break;
                    case Drive.LEFT:
                        straight_png.Visibility = Visibility.Hidden;
                        right_png.Visibility = Visibility.Hidden;
                        left_png.Visibility = Visibility.Visible;
                        break;
                }
            }
            else
            {
                if(payload.Count == 1)
                {
                    payload.RemoveAt(payload.Count - 1);
                }
                straight_png.Visibility = Visibility.Hidden;
                right_png.Visibility = Visibility.Hidden;
                left_png.Visibility = Visibility.Hidden;
            }
        }

    }
}
