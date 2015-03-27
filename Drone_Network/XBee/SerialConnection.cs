using System.IO;
using System.IO.Ports;
//using NLog;
using XBee.Utils;
using System;

namespace XBee
{
    public class SerialConnection : IXBeeConnection
    {
        //private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private SerialPort serialPort;
        private IPacketReader reader;

        public SerialConnection(string port, int baudRate)
        {
            serialPort = new SerialPort(port, baudRate);
            serialPort.DataReceived += ReceiveData;
        }

        private void ReceiveData(object sender, SerialDataReceivedEventArgs e)
        {
            var length = serialPort.BytesToRead;
            var buffer = new byte[length];

            serialPort.Read(buffer, 0, length);

            Console.WriteLine("Receiving data: [" + ByteUtils.ToBase16(buffer) + "]");
            reader.ReceiveData(buffer);
        }

        public void Write(byte[] data)
        {
            Console.WriteLine("Sending data: [" + ByteUtils.ToBase16(data) + "]");
            serialPort.Write(data, 0, data.Length);
        }

        public Stream GetStream()
        {
            return serialPort.BaseStream;
        }

        public void Open()
        {
            serialPort.Open();
        }

        public void Close()
        {
            serialPort.Close();
            serialPort.Dispose();
        }

        public void SetPacketReader(IPacketReader reader)
        {
            this.reader = reader;
        }

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (serialPort != null)
                {
                    serialPort.Dispose();
                    serialPort = null;
                }
            }
            // free native resources if there are any.
        }
    }
}
