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
