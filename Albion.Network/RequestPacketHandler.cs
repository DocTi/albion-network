// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using System;

namespace Albion.Network
{
    public class RequestPacketHandler<TOperation> : PacketHandler<RequestPacket> where TOperation : BaseOperation
    {
        private readonly OperationCodes operationCode;
        private readonly Action<TOperation> action;

        public RequestPacketHandler(OperationCodes operationCode, Action<TOperation> action)
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
            else
            {
                TOperation instance = (TOperation)Activator.CreateInstance(typeof(TOperation), packet.Parameters);

                action.Invoke(instance);
            }
        }
    }
}
