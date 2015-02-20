using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;


namespace Proto_XBee
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {   /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Prototype());
             * */

            SerialPort SerialPort1 = new SerialPort();
            SerialPort1.PortName = "COM4";
            SerialPort1.BaudRate = 9600;
            SerialPort1.Parity = System.IO.Ports.Parity.None;
            SerialPort1.DataBits = 8;
            SerialPort1.StopBits = System.IO.Ports.StopBits.One;
            SerialPort1.Handshake = System.IO.Ports.Handshake.None;
            SerialPort1.RtsEnable = true;

            SerialPort1.Open();
            
            Byte[] buf = {Convert.ToByte('a')};
            Byte[] buf2 = new Byte[SerialPort1.ReadBufferSize];

            while (true)
            {
                if ((SerialPort1.IsOpen == true))
                {
                    //SerialPort1.Write(buf, 0, buf.Length);
                    SerialPort1.Read(buf2, 0, buf2.Length);
                    var temp = buf2[0];
                    Console.WriteLine(Convert.ToChar(buf2[0]));
                }
            }

        }
    }
}
