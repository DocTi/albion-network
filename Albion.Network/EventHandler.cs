using System.Collections.Generic;

namespace Albion.Network
{
    public abstract class EventHandler : PacketHandler<EventPacket>
    {
        protected abstract void OnEvent(EventCodes eventCodes, Dictionary<byte, object> parameters);

        protected internal override void OnHandle(EventPacket packet)
        {
            byte code = packet.Code;
            Dictionary<byte, object> parameters = packet.Parameters;

            if (code == 2 || !parameters.TryGetValue(252, out var value))
            {
                return;
            }

            EventCodes eventCode = (EventCodes)value;

            OnEvent(eventCode, parameters);
        }
    }
}
