using System.Collections.Generic;

namespace Albion.Network
{
    internal class RequestPacketHandler : PacketHandler<RequestPacket>
    {
        protected internal override void OnHandle(RequestPacket packet)
        {
            Dictionary<byte, object> parameters = packet.Parameters;

            if (!parameters.TryGetValue(253, out var value))
            {
                return;
            }

            OperationCodes operationCode = (OperationCodes)value;

            var requestResult = new RequestResult(operationCode, parameters);

            Next(requestResult);
        }
    }
}
