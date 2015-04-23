namespace XBee
{
    public abstract class XBeeFrame
    {
        protected XBeeAPICommandId CommandId;
        public byte FrameId { get; set; }
        
        //Eli
        public byte[] data { get; set; }

        public XBeeAPICommandId GetCommandId()
        {
            return CommandId;
        }

        public abstract byte[] ToByteArray();
        public abstract void Parse();
    }
}
