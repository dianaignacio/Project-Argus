using System;
using System.IO;
using System.Linq;
using XBee.Exceptions;
using XBee.Frames;

namespace XBee
{
    public class PacketReader : IPacketReader
    {
        public event FrameReceivedHandler FrameReceived;

        protected MemoryStream Stream = new MemoryStream();
        private uint packetLength = 0;

        public void ReceiveData(byte[] data)
        {
            try
            {
                if (data.Length != 0)
                {
                    if (packetLength == 0 && data[0] == (byte)XBeeSpecialBytes.StartByte)
                    {
                        Stream = new MemoryStream();
                        packetLength = 0;
                    }
                    CopyAndProcessData(data);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Out of bounds exception in Received Data.");
            }
        }

        private void CopyAndProcessData(byte[] data)
        {
            foreach (var b in data.Where(b => Stream.Length != 0 || b != (byte) XBeeSpecialBytes.StartByte)) {
                Stream.WriteByte(b);
            }

            if (packetLength == 0 && Stream.Length > 2) {
                var packet = Stream.ToArray();
                packetLength = (uint) (packet[0] << 8 | packet[1]) + 3;
            }

            if (Stream.Length < 3)
                return;

            if (packetLength != 0 && Stream.Length < packetLength)
                return;

            ProcessReceivedData();
        }

        protected virtual void ProcessReceivedData()
        {
            try {
                //Eli - edited to only work with series 2 XBee
                // was simply 'XBeeFrame' instead of ZigBeeReceivePacket
                //ZigBeeReceivePacket frame = (ZigBeeReceivePacket)XBeePacketUnmarshaler.Unmarshal(Stream.ToArray());
                XBeeFrame frame = XBeePacketUnmarshaler.Unmarshal(Stream.ToArray());
                packetLength = 0;
                if (FrameReceived != null)
                {
                    if (frame.GetCommandId() == XBeeAPICommandId.RECEIVE_PACKET_RESPONSE)
                    {
                        FrameReceived.Invoke(this, new FrameReceivedArgs((ZigBeeReceivePacket)frame));
                    }
                    else
                    {
                        FrameReceived.Invoke(this, new FrameReceivedArgs(frame));
                    }
                }
            } catch (XBeeFrameException ex) {
                //throw new XBeeException("Unable to unmarshal packet.", ex);
                Console.WriteLine("Too many incoming packets. Overflow.");
            }
        }
    }
}
