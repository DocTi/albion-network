using Albion.Common;
using System.Collections.Generic;

namespace Albion.Network
{
    internal class ResponsePacketHandler : PacketHandler<ResponsePacket>
    {
        protected internal override void OnHandle(ResponsePacket packet)
        {
            Dictionary<byte, object> parameters = packet.Parameters;

            if (!parameters.TryGetValue(253, out var value))
            {
                return;
            }

            OperationCodes operationCode = (OperationCodes)value;

            var responseResult = new ResponseResult(operationCode, parameters);

            Next(responseResult);
        }
    }
}
