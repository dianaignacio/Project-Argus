﻿using System;
using System.Text;
using System.Collections;
using XBee.Utils;

namespace XBee.Frames
{
    public class ATCommandResponse : XBeeFrame
    {
        private readonly PacketParser parser;

        public AT Command { get; private set; }
        public ATValue Value { get; private set; }
        public byte CommandStatus { get; private set; }
        public ArrayList discoveredNodes { get; set; }
        

        public ATCommandResponse(PacketParser parser)
        {
            this.parser = parser;
            CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
            discoveredNodes = new ArrayList();
        }

        public ATCommandResponse()
        {
            CommandId = XBeeAPICommandId.AT_COMMAND_RESPONSE;
            discoveredNodes = new ArrayList();
        }

        public override byte[] ToByteArray()
        {
            return new byte[] { };
        }

        public override void Parse()
        {
            FrameId = (byte)parser.ReadByte();
            Command = parser.ReadATCommand();
            CommandStatus = (byte)parser.ReadByte();

            if (Command == AT.NodeDiscover)
            {
                ParseNetworkDiscovery();
            }

            var type = ((ATAttribute)Command.GetAttr()).ValueType;

            if ((type != ATValueType.None) && parser.HasMoreData()) {
                switch (type) {
                    case ATValueType.Number:
                        var vData = parser.ReadData();
                        Value = new ATLongValue().FromByteArray(vData);
                        break;
                    case ATValueType.HexString:
                        var hexData = parser.ReadData();
                        Value = new ATStringValue(ByteUtils.ToBase16(hexData));
                        break;
                    case ATValueType.String:
                        var str = parser.ReadData();
                        Value = new ATStringValue(Encoding.UTF8.GetString(str));
                        break;
                }
            }
        }

        private void ParseNetworkDiscovery()
        {
            lock (this)
            {
                try
                {
                    //discoveredNodes.Add(new XBeeNode { Address16 = parser.ReadAddress16(), Address64 = parser.ReadAddress64() });
                    var source = new XBeeNode { Address16 = parser.ReadAddress16(), Address64 = parser.ReadAddress64() };
                    var nodeIdentifier = parser.ReadString();
                    

                    var parentAddress = parser.ReadAddress16();
                    var type = (NodeIdentification.DeviceType)parser.ReadByte();
                    var status = parser.ReadByte();
                    var profileId = parser.ReadUInt16();
                    var manufacturerId = parser.ReadUInt16();

                    source.NodeIdentifier = nodeIdentifier;
                    discoveredNodes.Add(source);

                    Console.WriteLine(string.Format("source {0}, id {1}, status {2}", source.Address64, nodeIdentifier, status));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Source);
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
