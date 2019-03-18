using Albion.Common;
using Albion.Operation;
using System;

namespace Albion.Network
{
    public class ResponseHandler<TOperation> : PacketHandler<ResponsePacket> where TOperation : BaseOperation
    {
        private readonly OperationCodes operationCode;
        private readonly Action<TOperation> action;

        public ResponseHandler(OperationCodes operationCode, Action<TOperation> action)
        {
            this.operationCode = operationCode;
            this.action = action;
        }

        protected internal override void OnHandle(ResponsePacket packet)
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
