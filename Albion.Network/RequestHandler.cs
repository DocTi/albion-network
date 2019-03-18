using Albion.Common;
using Albion.Operation;
using System;

namespace Albion.Network
{
    public class RequestHandler<TOperation> : PacketHandler<RequestPacket> where TOperation : BaseOperation, new()
    {
        private readonly OperationCodes operationCode;

        public RequestHandler(OperationCodes operationCode)
        {
            this.operationCode = operationCode;
        }

        protected internal override void OnHandle(RequestPacket packet)
        {
            if (operationCode != packet.OperationCode)
            {
                Next(packet);
            }

            object instance = Activator.CreateInstance(typeof(TOperation), packet.Parameters);

            Next(instance);
        }
    }
}
