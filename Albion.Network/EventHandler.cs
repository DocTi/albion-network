using Albion.Common;
using Albion.Event;
using System;

namespace Albion.Network
{
    public class EventHandler<TEvent> : PacketHandler<EventPacket> where TEvent : BaseEvent
    {
        private readonly EventCodes eventCode;
        private readonly Action<TEvent> action;

        public EventHandler(EventCodes eventCode, Action<TEvent> action)
        {
            this.eventCode = eventCode;
            this.action = action;
        }

        protected internal override void OnHandle(EventPacket packet)
        {
            if (eventCode != packet.EventCode)
            {
                Next(packet);
            }

            TEvent instance = (TEvent)Activator.CreateInstance(typeof(TEvent), packet.Parameters);

            action.Invoke(instance);
        }
    }
}
