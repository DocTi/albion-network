// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace Albion.Network
{
    internal class ResponsePacket
    {
        public ResponsePacket(byte OperationCode, short ReturnCode, string DebugMessage, Dictionary<byte, object> Parameters)
        {
            this.OperationCode = OperationCode;
            this.ReturnCode = ReturnCode;
            this.DebugMessage = DebugMessage;
            this.Parameters = Parameters;
        }

        public byte OperationCode { get; }
        public short ReturnCode { get; }
        public string DebugMessage { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
