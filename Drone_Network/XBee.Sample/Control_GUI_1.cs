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
using XBee_Interface;

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

            ports = SerialPort.GetPortNames();
            ATCommand testCommand;
            testCommand = new ATCommand(AT.FirmwareVersion);
            testCommand.FrameId = 1;
            
            foreach (String s in ports)
            {                
                SerialConnection conn = new SerialConnection(s, 9600);
                bee.SetConnection(conn);
                

                bee.Execute(testCommand);
                Thread.Sleep(500);
                conn.Close();
                
            }

            //coord discover is buggy with multiple xbee's connected to same computer
            SerialConnection conn2 = new SerialConnection("COM4", 9600);
            bee.SetConnection(conn2);

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

        private void _btnSend_Click(object sender, EventArgs e)
        {
            String temp = _txtBoxMessage.Text;
            if (temp.Length >= 16)
            {
                temp = temp.Remove(16);
            }

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

            //poll for received data
            do
            {
                if (bee.frameReceived && !bee.statusFrame)
                {
                    _txtBoxMessage.Text = bee.lastFrame.data.ToString();
                }
            } while (bee.statusFrame);
        }
    }
}
