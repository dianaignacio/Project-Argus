using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proto_XBee
{
    public partial class Prototype : Form
    {

        /*
        static SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        Boolean led = false;
        Byte[] commands = new byte[] { 0x30, 0x31};

        public Prototype()
        {
            InitializeComponent();
            try
            {
                port.DataReceived += serialPort1_DataReceived;
                port.Open();
                Console.WriteLine("Opened");
                
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry! " + ex);
            }

            
            
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (port.IsOpen == true)
            {
                string RxString = port.ReadExisting();
                Console.WriteLine(RxString);
            }
        }

        private void _btnBlink_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(1000);

            if (led)
                port.Write(commands, 0, 1);
            else
                port.Write(commands,1,1);

            System.Threading.Thread.Sleep(1000);

            Console.WriteLine(led);

            led = !led;

        }
        */
        public Prototype()
        {
            InitializeComponent();
        }

        private string inputData = "";
        public event System.IO.Ports.SerialDataReceivedEventHandler DataReceived;
        static SerialPort SerialPort1 = new SerialPort();

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                // Set values for some properties 
                SerialPort1.PortName = "COM4";
                SerialPort1.BaudRate = 9600;
                SerialPort1.Parity = System.IO.Ports.Parity.None;
                SerialPort1.DataBits = 8;
                SerialPort1.StopBits = System.IO.Ports.StopBits.One;
                SerialPort1.Handshake = System.IO.Ports.Handshake.None;
                SerialPort1.RtsEnable = true;

                SerialPort1.Open();
                // Writes data to the Serial Port output buffer 
                while (true)
                {
                    if ((SerialPort1.IsOpen == true))
                    {
                        String temp = "hello";
                        SerialPort1.Write(temp);
                        //SerialPort1.BaseStream.WriteAsync(Encoding.ASCII.GetBytes(temp), 0, temp.Length);
                    }
                }
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        //  Receive data from the Serial Port
        private void SerialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            inputData = SerialPort1.ReadExisting();
            // or SerialPort1.ReadLine
            this.Invoke((MethodInvoker)delegate { DoUpdate(); });
        }

        // Show received data on UI controls and do something
        public void DoUpdate()
        {
            Console.WriteLine(inputData);
        }

        private void Form1_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            //  Close the Serial Port
            SerialPort1.Close();
        }

    }
}
/*
namespace xbee
{
    class Program
    {
        static SerialPort port = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);
        static void Main(string[] args)
        {
            // Instantiate the communications
            // port with some basic settings 

            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Open the port for communications 
            port.Open(); // Write a string 
            port.Write("+++");
            System.Threading.Thread.Sleep(1000);
            // port.ReadLine();
            //port.WriteLine("AT" + Convert.ToChar(13));
            //System.Threading.Thread.Sleep(1000);
            Byte[] b = new byte[] { 0x7E, 0x00, 0x10, 0x17, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x02, 0x44, 0x34, 0x05, 0x6D };
            port.Write(b, 0, b.Length);
            System.Threading.Thread.Sleep(1000);
            port.Write("&#x7E;&#x00;&#x10;&#x17;&#x01;&#x00;&#x00;&#x00;&#x00;&#x00;&#x00;&#xFF;&#xFF;&#xFF FE;&#x02;&#x44;&#x34;&#x05;&#x6D" + Convert.ToChar(13));
            //port.Write("0x7E00101701000000000000FFFFFFFE024434056D"+Convert.ToChar(13));
            System.Threading.Thread.Sleep(1000);
            //port.ReadLine();
            //Console.WriteLine(port.ReadLine());
            // port.Write(new byte[] {0x0A, 0xE2, 0xFF}, 0, 3);

            Console.WriteLine("Press any key to close this app..");
            Console.ReadLine();
            // Close the port
            port.Close();
        }

        static void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine(e.EventType.ToString());
            Console.WriteLine(port.ReadExisting());
            // Console.WriteLine((char)port.ReadByte());
        }
    }
}
*/