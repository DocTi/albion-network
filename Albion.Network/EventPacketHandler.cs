// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using System.Collections.Generic;

namespace Albion.Network
{
    internal class EventPacketHandler : PacketHandler<EventPacket>
    {
        protected internal override void OnHandle(EventPacket packet)
        {
            byte code = packet.Code;
            Dictionary<byte, object> parameters = packet.Parameters;

            if (code == 2 || !parameters.TryGetValue(252, out var value))
            {
                return;
            }

            EventCodes eventCode = (EventCodes)value;

            var eventResult = new EventResult(eventCode, parameters);

            Next(eventResult);
        }
    }
}
