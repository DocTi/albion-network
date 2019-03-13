using System.Collections.Generic;

namespace Albion.Network
{
    public abstract class ResponseHandler : PacketHandler<ResponsePacket>
    {
        protected abstract void OnResponse(OperationCodes operationCodes, Dictionary<byte, object> parameters);

        protected internal override void OnHandle(ResponsePacket packet)
        {
            Dictionary<byte, object> parameters = packet.Parameters;

            if (!parameters.TryGetValue(253, out var value))
            {
                return;
            }

            OperationCodes operationCode = (OperationCodes)value;

            OnResponse(operationCode, parameters);
        }
    }
}
