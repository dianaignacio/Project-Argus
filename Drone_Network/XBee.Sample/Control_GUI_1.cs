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
         * 'Send' button will send the message in the text box.
         * */

        XBeeManager coms;
        
        public Control_GUI_1()
        {
            InitializeComponent();
            
            coms = new XBeeManager();
            coms.InitScan();
            coms.NodeDiscover();
           

        }

        private void Control_GUI_1_Load(object sender, EventArgs e)
        {
            

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



           /*
            //poll for received data
            do
            {
                if (bee.frameReceived && !bee.statusFrame)
                {
                    _txtBoxMessage.Text = bee.lastFrame.data.ToString();
                }
            } while (bee.statusFrame);
            * */
        }


    }
}
