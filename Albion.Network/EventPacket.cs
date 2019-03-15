// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace Albion.Network
{
    internal class EventPacket
    {
        public EventPacket(byte code, Dictionary<byte, object> parameters)
        {
            Code = code;
            Parameters = parameters;
        }

        public byte Code { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
