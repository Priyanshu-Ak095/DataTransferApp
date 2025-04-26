using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace DataTransferApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort;

        public MainWindow()
        {
            InitializeComponent();
            // Set up serial port (update COM3 to match Hercules Terminal)
            serialPort = new SerialPort("COM3", 9600);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        // Allow only numbers
        private void TextBox1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^\d+$");
        }

        // Send data when button clicked OR when 16 digits entered
        private void SendData_Click(object sender, RoutedEventArgs e)
        {
            SendToHercules();
        }

        private void SendToHercules()
        {
            string data = TextBox1.Text;

            if (data.Length == 16)
            {
                try
                {
                    if (!serialPort.IsOpen) serialPort.Open();
                    serialPort.WriteLine(data);
                }
                catch
                {
                    MessageBox.Show("Failed to send data. Check COM port.");
                }
            }
            else
            {
                MessageBox.Show("Please enter exactly 16 digits.");
            }
        }

        // Read from Hercules
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string incomingData = serialPort.ReadExisting();

            // Update the UI from the background thread
            Dispatcher.Invoke(() =>
            {
                TextBox2.Text += incomingData + Environment.NewLine;
            });
        }

        private void ReceiveData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                    serialPort.Open();
                MessageBox.Show("Ready to receive data from Hercules.");
            }
            catch
            {
                MessageBox.Show("Could not open COM port. Check connection.");
            }
        }
    }
}
