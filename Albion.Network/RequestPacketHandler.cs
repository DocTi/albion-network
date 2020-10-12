using System;

namespace Albion.Network
{
    public abstract class RequestPacketHandler<TOperation> : PacketHandler<RequestPacket> where TOperation : BaseOperation
    {
        private readonly OperationCodes operationCode;

        public RequestPacketHandler(OperationCodes operationCode)
        {
            this.operationCode = operationCode;
        }

        protected abstract void OnAction(TOperation value);

        protected internal override void OnHandle(RequestPacket packet)
        {
            if (operationCode != packet.OperationCode)
            {
                Next(packet);
            }
            else
            {
                TOperation instance = (TOperation)Activator.CreateInstance(typeof(TOperation), packet.Parameters);

                OnAction(instance);
            }
        }
    }
}
