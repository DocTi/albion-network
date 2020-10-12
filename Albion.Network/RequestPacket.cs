using System.Collections.Generic;

namespace Albion.Network
{
    public class RequestPacket
    {
        public RequestPacket(OperationCodes operationCode, Dictionary<byte, object> Parameters)
        {
            OperationCode = operationCode;
            this.Parameters = Parameters;
        }

        public OperationCodes OperationCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
