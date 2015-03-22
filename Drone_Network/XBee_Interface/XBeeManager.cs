using System;
using System.Collections.Generic;
using System.Collections;
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
        public ArrayList nodes;

        private Timer timer;
        
        
        public XBeeManager()
        {
            request = null;
            ports = null;
            nodes = new ArrayList();
        }

        //Scan and set for XBee connections
        public void InitScan()
        {
            Boolean found = false;
            ports = SerialPort.GetPortNames();
            ATCommand testCommand;
            testCommand = new ATCommand(AT.FirmwareVersion);
            testCommand.FrameId = 1;
            String correctPort = null;
            
            //foreach (String s in ports)
            String s;
            for (int i = 0; i < ports.Length && !found; i++ )
            {
                s = ports[i];
                SerialConnection conn = new SerialConnection(s, 9600);
                coordinator.SetConnection(conn);


                coordinator.Execute(testCommand);
                Thread.Sleep(500);
                lock (this)
                {
                    if (coordinator.lastFrame != null && coordinator.lastFrame.GetCommandId() == XBeeAPICommandId.AT_COMMAND_RESPONSE)
                    {
                        byte[] temp = coordinator.lastFrame.data;
                        byte[] coordResponse = { 17, 71 };
                        if (temp != null && temp[0] == coordResponse[0] && temp[1] == coordResponse[1] && temp.Length == 2)
                        {
                            found = true;
                            correctPort = s;
                        }

                        coordinator.frameReceived = false;
                    }
                }
                conn.Close();
                if(found)
                {
                    break;
                }
            }
            
            if (found)
            {
                SerialConnection correct = new SerialConnection(correctPort, 9600);
                coordinator.SetConnection(correct);
                Console.WriteLine("Coordinator on port: " + correctPort);
            }
            else
            {
                Console.WriteLine("Coordinator XBee not found.");
            }
            
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

        //receive last frame without parsing data
        public ATCommandResponse ReceiveCommandResponse()
        {
            ATCommandResponse data = new ATCommandResponse();
            //waits until a frame is received            
            lock (this)
            {
                while (!coordinator.frameReceived && timer!= null) ;
                if (coordinator.frameReceived)
                {
                    if (coordinator.lastFrame != null)
                    {
                        data = (ATCommandResponse)coordinator.lastFrame;
                    }
                    else
                    {
                        data = null;
                    }
                }
                coordinator.frameReceived = false;
            }
            return data;
        }

        private void TimerProc(object state)
        {
            // The state object is the Timer object.
            Timer t = (Timer)state;
            t.Dispose();
            timer.Dispose();
            timer = null;
            Console.WriteLine("The timer callback executes.");
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

        //node discovery function
        public void NodeDiscover()
        {
            
            
            //add array list to call receive frames multiple times w/ multiple xbees? needs testing. code is convouted and may or may not already do this.
            ATCommand getNode = new ATCommand(AT.NodeDiscover);
            getNode.FrameId = 1;
            coordinator.Execute(getNode);

            timer = new Timer(new TimerCallback(TimerProc));
            //6000 ms is standard timeout of Node Discovery Backoff
            timer.Change(6000, 0);
            while (timer != null)
            {
                ATCommandResponse response = (ATCommandResponse)ReceiveCommandResponse();
                if(response.discoveredNodes.Count != 0)
                    nodes.Add(response.discoveredNodes[0]);
            }

            return;
        }
    }
}
