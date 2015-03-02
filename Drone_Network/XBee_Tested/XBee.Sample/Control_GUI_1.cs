using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
        
        public Control_GUI_1()
        {
            InitializeComponent();
            SerialConnection conn = new SerialConnection("COM4", 9600);
            //conn.Close();
            bee.SetConnection(conn);
            
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
