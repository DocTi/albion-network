using System;
using System.Threading.Tasks;

namespace Albion.Network
{
    public abstract class RequestPacketHandler<TOperation> : PacketHandler<RequestPacket> where TOperation : BaseOperation
    {
        private readonly int operationCode;

        public RequestPacketHandler(int operationCode)
        {
            this.operationCode = operationCode;
        }

        protected abstract Task OnActionAsync(TOperation value);

        protected internal override Task OnHandleAsync(RequestPacket packet)
        {
            if (operationCode != packet.OperationCode)
            {
                return NextAsync(packet);
            }
            else
            {
                TOperation instance = (TOperation)Activator.CreateInstance(typeof(TOperation), packet.Parameters);

                return OnActionAsync(instance);
            }
        }
    }
}
