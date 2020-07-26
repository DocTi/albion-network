// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using System;

namespace Albion.Network
{
    public abstract class ResponsePacketHandler<TOperation> : PacketHandler<ResponsePacket> where TOperation : BaseOperation
    {
        private readonly OperationCodes operationCode;

        public ResponsePacketHandler(OperationCodes operationCode)
        {
            this.operationCode = operationCode;
        }

        protected abstract void OnAction(TOperation value);

        protected internal override void OnHandle(ResponsePacket packet)
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
