using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;
using System.Management;

using XBee.Frames;

namespace XBee.Sample
{
    public partial class Control_GUI_1 : Form
    {
        /*
         * A simple control GUI that will turn the Arduino pin 13 on and off
         * */
        XBee bee = new XBee {ApiType = ApiTypeValue.Enabled};
        XBeeNode n = new XBeeNode();
        TransmitDataRequest request;
        String[] ports;
        ManagementObjectCollection results;
        ManagementObjectSearcher search;

        public Control_GUI_1()
        {
            InitializeComponent();

            //search serial ports for 
            //SerialConnection conn = new SerialConnection("COM4", 9600);
            //conn.Close();
            //bee.SetConnection(conn);

            //search = new ManagementObjectSearcher("Select * from Win32_PnPEntity");
            //search = new ManagementObjectSearcher("Select * from Win32_USBController");
            //search = new ManagementObjectSearcher("Select * from Win32_POTSModemToSerialPort");
            //search = new ManagementObjectSearcher("Select * from Win32_USBHub");
            /*
            search = new ManagementObjectSearcher("Select * from Win32_PnPDevice");
            results = search.Get();
            foreach(ManagementObject obj in results)
            {
                Console.WriteLine(obj["DeviceID"].ToString());
                Console.WriteLine(obj["PNPDeviceID"].ToString());
                Console.WriteLine(obj["Name"].ToString());
                Console.WriteLine(obj["Description"].ToString());
                

            }
            */
            ports = SerialPort.GetPortNames();
            ATCommand testCommand;
            testCommand = new ATCommand(AT.FirmwareVersion);
            testCommand.FrameId = 1;
            

            ATCommandResponse testResponse;
            foreach (String s in ports)
            {                
                SerialConnection conn = new SerialConnection(s, 9600);
                bee.SetConnection(conn);
                

                bee.Execute(testCommand);
                Thread.Sleep(500);
                //conn.Close();
            }

            n.Address16 = new XBeeAddress16(0xFFFE);
            n.Address64 = new XBeeAddress64(0x0013A20040C4555D);
            request = new TransmitDataRequest(n);


        }

        private void _btnOn_Click(object sender, EventArgs e)
        {
            String temp = "H";
            Byte[] t = new Byte[temp.Length];
            int i = 0;
            foreach (char c in temp)
            {
                t[i] = Convert.ToByte(c);
                i++;
            }

            request.SetRFData(t);
            request.FrameId = 1;
            bee.Execute(request); 
            
            //use public last frame to perform analysis
        }

        private void _btnOff_Click(object sender, EventArgs e)
        {
            String temp = "L";
            Byte[] t = new Byte[temp.Length];
            int i = 0;
            foreach (char c in temp)
            {
                t[i] = Convert.ToByte(c);
                i++;
            }

            request.SetRFData(t);
            request.FrameId = 1;
            bee.Execute(request); 
        }
    }
}
