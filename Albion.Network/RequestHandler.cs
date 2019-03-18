using Albion.Common;
using Albion.Operation;
using System;

namespace Albion.Network
{
    public class RequestHandler<TOperation> : PacketHandler<RequestPacket> where TOperation : BaseOperation
    {
        private readonly OperationCodes operationCode;
        private readonly Action<TOperation> action;

        public RequestHandler(OperationCodes operationCode, Action<TOperation> action)
        {
            this.operationCode = operationCode;
            this.action = action;
        }

        protected internal override void OnHandle(RequestPacket packet)
        {
            if (operationCode != packet.OperationCode)
            {
                Next(packet);
            }

            TOperation instance = (TOperation)Activator.CreateInstance(typeof(TOperation), packet.Parameters);

            action.Invoke(instance);
        }
    }
}
