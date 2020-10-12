using System.Collections.Generic;

namespace Albion.Network
{
    public class ResponsePacket
    {
        public ResponsePacket(OperationCodes operationCode, Dictionary<byte, object> Parameters)
        {
            OperationCode = operationCode;
            this.Parameters = Parameters;
        }

        public OperationCodes OperationCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
