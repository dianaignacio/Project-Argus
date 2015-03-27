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
        XBeeAddress16 dest16;
        XBeeAddress64 dest64;

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

        public void SetTarget(int index)
        {
            dest16 = ((XBeeNode)nodes[index]).Address16;
            dest64 = ((XBeeNode)nodes[index]).Address64;
        }

        //send data
        public void SendData(String data)
        {
            if (dest16 != null && dest64 != null)
            {
               
                n.Address16 = dest16;
                n.Address64 = dest64;
                request = new TransmitDataRequest(n);
                
                request.SetRFData(Parser(data));
                request.FrameId = 1;
                coordinator.Execute(request);
            }
        }

        //receive and interpret data; return relevant data
        public String ReceiveData()
        {
            String data;

            //waits until a frame is received
            while (!coordinator.frameReceived) ;
            if (coordinator.lastFrame.data != null)
            {
                data = System.Text.Encoding.Default.GetString(coordinator.lastFrame.data);
            }
            else
            {
                data = coordinator.lastFrame.GetCommandId().ToString();
            }
            coordinator.frameReceived = false;
            return data;
        }

        //receive last frame without parsing data
        public ATCommandResponse ReceiveNodeDiscoverResponse()
        {
            ATCommandResponse data = new ATCommandResponse();
            
            lock (this)
            {
                bool temp = coordinator.frameReceived;
                
                while (!temp && ((ATCommandResponse)coordinator.lastFrame).Command != AT.NodeDiscover /*&& timer!= null*/)
                {
                    temp = coordinator.frameReceived;
                }
                //while (!coordinator.frameReceived) ;
                //if (coordinator.frameReceived)
                data = (ATCommandResponse)coordinator.lastFrame;
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

            

            timer = new Timer(new TimerCallback(TimerProc));
            //6000 ms is standard timeout of Node Discovery Backoff
            timer.Change(6000, 0);


            coordinator.Execute(getNode);

           
            while (timer != null)
            {
                ATCommandResponse response = (ATCommandResponse)ReceiveNodeDiscoverResponse();
                if (response.discoveredNodes.Count != 0)
                {
                    //allows only unique nodes. need to fix the frameRecieved flag not firing in 'ReciveNodeDiscoverResponse'
                    if (!nodes.Contains(response.discoveredNodes[0]))
                    {
                        nodes.Add(response.discoveredNodes[0]);
                    }
                }
            }

            return;
        }
    }
}
