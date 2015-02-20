using XBee.Frames;
namespace XBee
{
    public class FrameReceivedArgs
    {
        public XBeeFrame Response { get; private set; }
        public ZigBeeReceivePacket rxResponse { get; private set; }
        public bool rxFrame { get; private set; }

        public FrameReceivedArgs(XBeeFrame response)
        {
            rxFrame = false;
            Response = response;
        }

        public FrameReceivedArgs(ZigBeeReceivePacket response)
        {
            rxFrame = true;
            rxResponse = response;
        }
    }
}