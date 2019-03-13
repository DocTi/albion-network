using System.Collections.Generic;

namespace Albion.Network
{
    public abstract class RequestHandler : PacketHandler<RequestPacket>
    {
        protected abstract void OnRequest(OperationCodes operationCodes, Dictionary<byte, object> parameters);

        protected internal override void OnHandle(RequestPacket packet)
        {
            Dictionary<byte, object> parameters = packet.Parameters;

            if (!parameters.TryGetValue(253, out var value))
            {
                return;
            }

            OperationCodes operationCode = (OperationCodes)value;

            OnRequest(operationCode, parameters);
        }
    }
}
