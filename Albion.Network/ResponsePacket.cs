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
