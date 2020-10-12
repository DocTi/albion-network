using System;

namespace Albion.Network
{
    public abstract class EventPacketHandler<TEvent> : PacketHandler<EventPacket> where TEvent : BaseEvent
    {
        private readonly EventCodes eventCode;

        public EventPacketHandler(EventCodes eventCode)
        {
            this.eventCode = eventCode;
        }

        protected abstract void OnAction(TEvent value);

        protected internal override void OnHandle(EventPacket packet)
        {
            if (eventCode != packet.EventCode)
            {
                Next(packet);
            }
            else
            {
                TEvent instance = (TEvent)Activator.CreateInstance(typeof(TEvent), packet.Parameters);

                OnAction(instance);
            }
        }
    }
}
