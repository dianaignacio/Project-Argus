using System;
using System.Threading;
using XBee.Frames;

namespace XBee.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var bee = new XBee {ApiType = ApiTypeValue.Enabled};
            bee.SetConnection(new SerialConnection("COM4", 9600));
          
            /*  
            var request = new ATCommand(AT.ApiEnable) { FrameId = 1 };
            var frame = bee.ExecuteQuery(request, 1000);
            var value = ((ATCommandResponse) frame).Value;
            Console.WriteLine(String.Format("API type: {0}", ((ATLongValue) value).Value));
           
            request = new ATCommand(AT.BaudRate) { FrameId = 1 };
            frame = bee.ExecuteQuery(request, 1000);
            value = ((ATCommandResponse) frame).Value;
            Console.WriteLine(String.Format("Baud rate: {0}", ((ATLongValue) value).Value));

            request = new ATCommand(AT.MaximumPayloadLenght) { FrameId = 1 };
            frame = bee.ExecuteQuery(request, 1000);
            if (((ATCommandResponse)frame).Value != null)
                value = ((ATCommandResponse)frame).Value;

            Console.WriteLine(String.Format("Maximum Payload is: {0}", ((ATLongValue) value).Value));

            request = new ATCommand(AT.FirmwareVersion) { FrameId = 1 };
            frame = bee.ExecuteQuery(request, 1000);
            value = ((ATCommandResponse) frame).Value;
            Console.WriteLine(String.Format("Firmware Version: {0:X4}", ((ATLongValue) value).Value));
            
            var ATrequest = new ATCommand(AT.NodeDiscover) { FrameId = 1 };
            bee.Execute(ATrequest);
            */

            //Thread.Sleep(2500);
            //Eli
            
            XBeeNode n = new XBeeNode();
            n.Address16 = new XBeeAddress16(0xFFFE);
            //test 1
            //n.Address64 = new XBeeAddress64(0x0013A20040C1BC66);
            //test 2
            n.Address64 = new XBeeAddress64(0x0013A20040C4555D);
            //n.Address64 = new XBeeAddress64(0);
            TransmitDataRequest request = new TransmitDataRequest(n);
            
            //ZigBeeReceivePacket response;

            String temp = "Hello World";
            Byte[] t = new Byte[temp.Length];
            int i = 0;
            foreach (char c in temp)
            {
                t[i] = Convert.ToByte(c);
                i++;
            }
            
            //Console.WriteLine("Sent by PC: " + temp);
            
            //will send on start.
            request.SetRFData(t);
            
            //set to 0 to disable status response
            request.FrameId = 1;


            bee.Execute(request); 

            while (true)
            {
                
                Thread.Sleep(2500);
                   
                    /*
                    //prepare the packet for transmit
                    request.SetRFData(t);
                    request.FrameId = 1;
                
                    var frame = bee.ExecuteQuery(request, 250);

                    Console.WriteLine("This is PC");
                    */
                
            }
            
        }
    }
}
