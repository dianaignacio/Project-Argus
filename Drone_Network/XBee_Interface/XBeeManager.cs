using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using XBee.Frames;
using XBee;



namespace XBee_Interface
{
    public class XBeeManager
    {
        //class variables
        
        XBee.XBee coordinator = new XBee.XBee { ApiType = ApiTypeValue.Enabled };
        XBeeNode n = new XBeeNode();
        TransmitDataRequest request;
        String[] ports;
        
        public XBeeManager()
        {
            request = null;
            ports = null;
        }

        //Scan and set for XBee connections
        public void Scan()
        {
            Boolean found = false;
            ports = SerialPort.GetPortNames();
            ATCommand testCommand;
            testCommand = new ATCommand(AT.FirmwareVersion);
            testCommand.FrameId = 1;
            String correctPort = null;

            foreach (String s in ports)
            {
                SerialConnection conn = new SerialConnection(s, 9600);
                coordinator.SetConnection(conn);


                coordinator.Execute(testCommand);
                Thread.Sleep(500);
                if (coordinator.lastFrame!=null && coordinator.lastFrame.GetCommandId() == XBeeAPICommandId.AT_COMMAND_RESPONSE)
                {
                    //valid connection is found; break from loop
                    found = true;
                    correctPort = s;
                }

                conn.Close();
            }
            SerialConnection correct = new SerialConnection(correctPort, 9600);
            coordinator.SetConnection(correct);
           
        }

        //set XBee connections
        public void SetConnection(string com)
        {
            SerialConnection conn = new SerialConnection(com,9600);
            coordinator.SetConnection(conn);
        }

        //send data
        public void SendData(String data, XBeeAddress16 dest16, XBeeAddress64 dest64)
        {
            n.Address16 = dest16;
            n.Address64 = dest64;
            request = new TransmitDataRequest(n);
            request.SetRFData(Parser(data));
            request.FrameId = 1;
            coordinator.Execute(request);
        }

        //receive and interpret data; return relevant data
        public String ReceiveData()
        {
            String data;

            //waits until a frame is received
            while (!coordinator.frameReceived) ;
            if (coordinator.lastFrame.data != null)
            {
                data = coordinator.lastFrame.data.ToString();
            }
            else
            {
                data = coordinator.lastFrame.GetCommandId().ToString();
            }
            coordinator.frameReceived = false;
            return data;
        }

        //parse string to byte array
        private Byte[] Parser(String s)
        {
            Byte[] t = new Byte[s.Length];
            int i = 0;
            foreach (char c in s)
            {
                t[i] = Convert.ToByte(c);
                i++;
            }

            return t;
        }
    }
}
