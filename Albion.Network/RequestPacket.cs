// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace Albion.Network
{
    internal class RequestPacket
    {
        public RequestPacket(byte OperationCode, Dictionary<byte, object> Parameters)
        {
            this.OperationCode = OperationCode;
            this.Parameters = Parameters;
        }

        public byte OperationCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
