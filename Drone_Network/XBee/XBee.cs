using System;
using System.Threading;
using NLog;
using XBee.Exceptions;
using XBee.Frames;


namespace XBee
{
    public enum ApiTypeValue : byte
    {
        Disabled = 0x00,
        Enabled = 0x01,
        EnabledWithEscape = 0x02,
        Unknown = 0xFF
    }

    public class XBee
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IXBeeConnection connection;

        private Thread receiveThread;
        private bool stopThread;

        private byte frameId = byte.MinValue;

        public bool frameReceived = false;
        public bool statusFrame = false;
        public XBeeFrame lastFrame = null;
        private IPacketReader reader;
        private ApiTypeValue apiType;

        public ApiTypeValue ApiType
        {
            get { return apiType; }
            set
            {
                apiType = value;
                reader = PacketReaderFactory.GetReader(apiType);
                reader.FrameReceived += FrameReceivedEvent;
            }
        }

        public void SetConnection(IXBeeConnection connection)
        {
            this.connection = connection;
            this.connection.Open();
            this.connection.SetPacketReader(reader);

            /*
            receiveThread = new Thread(new ThreadStart(ReceiveData));
            receiveThread.Name = "Receive Data Thread";
            receiveThread.IsBackground = true;
            receiveThread.Start();
             */
        }

        public void Execute(XBeeFrame frame)
        {
            if (frame.FrameId != 0) {
                if (frameId == byte.MaxValue)
                    frameId = byte.MinValue;

                frame.FrameId = ++frameId;
            }

            var packet = new XBeePacket(frame);
            packet.Assemble();
            connection.Write(packet.Data);
        }

        public T ExecuteQuery<T>(XBeeFrame frame) where T : XBeeFrame
        {
            return (T) ExecuteQuery(frame);
        }

        public T ExecuteQuery<T>(XBeeFrame frame, int timeout) where T : XBeeFrame
        {
            return (T) ExecuteQuery(frame, timeout);
        }

        public XBeeFrame ExecuteQuery(XBeeFrame frame)
        {
            return ExecuteQuery(frame, 3000);
        }

        public XBeeFrame ExecuteQuery(XBeeFrame frame, int timeout)
        {
            if (frame.FrameId == 0)
                throw new XBeeFrameException("FrameId cannot be zero on a synchronous request.");

            lastFrame = null;
            frameReceived = false;

            lock (this) {
                Execute(frame);
            }

            while (!frameReceived && timeout > 0) {
                Thread.Sleep(10);
                timeout -= 10;
            }

            return lastFrame;
        }

        public void StopReceiveDataThread()
        {
            try {
                if (receiveThread != null) {
                    stopThread = true;
                    receiveThread.Join(2000);
                    receiveThread.Abort();
                    receiveThread.Join(2000);
                }
            } catch (Exception e) {
                logger.Info(e);
            } finally {
                receiveThread = null;
            }
        }

        public void FrameReceivedEvent(object sender, FrameReceivedArgs args)
        {
            lock (this)
            {
                frameReceived = true;
                if(!args.rxFrame)
                {
                    statusFrame = true;
                }
                else
                {
                    statusFrame = false;
                }
                lastFrame = args.Response;
                var data = lastFrame.ToString();
                Console.WriteLine(args.Response);    

                if(lastFrame.GetCommandId() == XBeeAPICommandId.AT_COMMAND_RESPONSE)
                {
                    lastFrame.data = ((ATLongValue)((ATCommandResponse)args.Response).Value).ToByteArray();
                    lastFrame.nodes = ((ATCommandResponse)args.Response).discoveredNodes;
                    //lastFrame.raw = args.Response.
                }
            }
            

           /*
            if (!args.rxFrame)
            {
                lastFrame = args.Response;
                var data = lastFrame.ToString();
                Console.WriteLine(args.Response);
            }
            else if (args.rxFrame)
            {
                lastFrame = args.rxResponse;
                var data = lastFrame.ToString();
                Console.WriteLine(args.Response);
                //pass Response.Data to program.cs or perform decode here...
                char[] t = new char[args.rxResponse.Data.Length];
                int i = 0;
                foreach (byte b in args.rxResponse.Data)
                {
                    t[i] = Convert.ToChar(b);
                    i++;
                }
                String temp = new string(t);
                try
                {
                    Console.WriteLine("Received on PC: " + temp);
                }
                catch
                {
                    Console.WriteLine("Bad Frame");
                }
            }
            * */
        }

        private void ReceiveData()
        {
            try {
                while (!stopThread) {

                }
            } catch {
            }
        }
    }
}
