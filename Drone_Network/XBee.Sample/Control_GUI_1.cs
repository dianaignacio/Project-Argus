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
            coms.SetTarget(0);
            coms.SendData("H");
            _txtBoxMessage.Text = coms.ReceiveData();//status
            //_txtBoxMessage.Text = coms.ReceiveData();//data
           
        }

        private void _btnOff_Click(object sender, EventArgs e)
        {
            coms.SetTarget(0);
            coms.SendData("L");
            _txtBoxMessage.Text = coms.ReceiveData();//receive status
            //_txtBoxMessage.Text = coms.ReceiveData();//receive data
        }

        private void _btnSend_Click(object sender, EventArgs e)
        {
            coms.SetTarget(0);
            coms.SendData("Hello World");
            _txtBoxMessage.Text = coms.ReceiveData();//status
            _txtBoxMessage.Text = coms.ReceiveData();//data
        }


    }
}
