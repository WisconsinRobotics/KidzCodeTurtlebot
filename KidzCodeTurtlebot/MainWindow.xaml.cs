using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
        private const int TURTLEBOT_SUBSYSTEM_PORT = 40000;


        private List<Drive> payload;
        private List<string> cmdTextBox;
        private UdpClient socket;



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

            socket = new UdpClient(TURTLEBOT_SUBSYSTEM_PORT);
        }

        private void straightButton_Click(object sender, RoutedEventArgs e)
        {
            driveCmdTextBox.Background = Brushes.White;

            payload.Add(Drive.STRAIGHT);

            cmdTextBox.Add("Straight\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Visible;
            right_png.Visibility = Visibility.Hidden;
            left_png.Visibility = Visibility.Hidden;
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            driveCmdTextBox.Background = Brushes.White;

            payload.Add(Drive.RIGHT);

            cmdTextBox.Add("Right\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Hidden;
            right_png.Visibility = Visibility.Visible;
            left_png.Visibility = Visibility.Hidden;
        }

        private void leftButton_Click(object sender, RoutedEventArgs e)
        {
            driveCmdTextBox.Background = Brushes.White;

            payload.Add(Drive.LEFT);

            cmdTextBox.Add("Left\n");
            driveCmdTextBox.Text = String.Join(" ", cmdTextBox.ToArray());

            straight_png.Visibility = Visibility.Hidden;
            right_png.Visibility = Visibility.Hidden;
            left_png.Visibility = Visibility.Visible;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            driveCmdTextBox.Background = Brushes.White;

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

        private void executeButton_Click(object sender, RoutedEventArgs e)
        {
            bool valid = ValidateSelection();

            driveCmdTextBox.Background = valid ? Brushes.Green : Brushes.Red;

            if (valid)
            {
                SendSelection(this.payload);
            }
        }


        private bool ValidateSelection()
        {
            List<Drive> path1 = Path.getPath1().Data;

            if (path1.Count != this.payload.Count)
            {
                return false;
            }

            for (int i = 0; i < path1.Count; i++)
            {
                if (!path1[i].Equals(this.payload[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private byte[] SendSelection(List<Drive> selection)
        {
            byte[] packet = DataPacker(selection);
            socket.Send(packet, packet.Length, new IPEndPoint(IPAddress.Loopback, TURTLEBOT_SUBSYSTEM_PORT));

            return packet;
        }


        private byte[] DataPacker(List<Drive> selection)
        {
            List<byte> packed = new List<byte>();

            packed.Add(0xBA);
            packed.Add((byte)selection.Count);

            foreach (Drive drive in selection)
            {
                packed.Add((byte)drive);
            }

            packed.Add(0xBE);

            return packed.ToArray();
        }
    }


    /// <summary>
    /// Enum to represent drive directions for Turtlebot
    /// </summary>
    public enum Drive
    {
        STRAIGHT = (byte)0,
        RIGHT = (byte)1,
        LEFT = (byte)2,
    }

}
