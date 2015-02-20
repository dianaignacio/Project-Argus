using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace xbee
{
    class Program
    {
        static SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        static void Main(string[] args)
        {
            // Instantiate the communications
            // port with some basic settings 

            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            port.Open(); // Write a string 
            port.Write("+++");
            System.Threading.Thread.Sleep(1000);
            Byte[] b = new byte[] { 0x7E, 0x00, 0x10, 0x17, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFE, 0x02, 0x44, 0x34, 0x05, 0x6D };
            port.Write(b, 0, b.Length);
            //port.Write("Characters:");
            System.Threading.Thread.Sleep(1000);
            //port.Write("&#x7E;&#x00;&#x10;&#x17;&#x01;&#x00;&#x00;&#x00;&#x00;&#x00;&#x00;&#xFF;&#xFF;&#xFF FE;&#x02;&#x44;&#x34;&#x05;&#x6D" + Convert.ToChar(13));
            //port.Write("Characters:");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Press any key to close this app..");
            Console.ReadLine();
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