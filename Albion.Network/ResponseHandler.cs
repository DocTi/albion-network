using Albion.Common;
using Albion.Operation;
using System;

namespace Albion.Network
{
    public class ResponseHandler<TOperation> : PacketHandler<ResponsePacket> where TOperation : BaseOperation, new()
    {
        private readonly OperationCodes operationCode;

        public ResponseHandler(OperationCodes operationCode)
        {
            this.operationCode = operationCode;
        }

        protected internal override void OnHandle(ResponsePacket packet)
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
