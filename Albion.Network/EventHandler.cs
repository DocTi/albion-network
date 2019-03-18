using Albion.Common;
using Albion.Event;
using System;

namespace Albion.Network
{
    public class EventHandler<TEvent> : PacketHandler<EventPacket> where TEvent : BaseEvent, new()
    {
        private readonly EventCodes eventCode;

        public EventHandler(EventCodes eventCode)
        {
            this.eventCode = eventCode;
        }

        protected internal override void OnHandle(EventPacket packet)
        {
            if (eventCode != packet.EventCode)
            {
                Next(packet);
            }

            object instance = Activator.CreateInstance(typeof(TEvent), packet.Parameters);

            Next(instance);
        }
    }
}
