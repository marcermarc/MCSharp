﻿using System;
using System.Collections.Generic;
using System.Text;

using MCSharp.Network;

namespace MCSharp.Pakets
{
    public class HandshakePaket : IPaket
    {
        public int ProtocolVersion { get; set; }
        public string ServerAddress { get; set; }
        public ushort ServerPort { get; set; }
        public ushort NextState { get; set; }

        public void Decode(MinecraftStream minecraftStream)
        {
            ProtocolVersion = minecraftStream.ReadVarInt();
            ServerAddress = minecraftStream.ReadString();
            ServerPort = minecraftStream.ReadUShort();
            NextState = minecraftStream.ReadUShort();
        }

        public void Encode(MinecraftStream minecraftStream)
        {
            minecraftStream.WriteVarInt(ProtocolVersion);
            minecraftStream.WriteString(ServerAddress);
            minecraftStream.WriteUShort(ServerPort);
            minecraftStream.WriteVarInt(NextState);
        }
    }
}
