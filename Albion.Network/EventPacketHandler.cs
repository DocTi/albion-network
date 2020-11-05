using System;
using System.Threading.Tasks;

namespace Albion.Network
{
    public abstract class EventPacketHandler<TEvent> : PacketHandler<EventPacket> where TEvent : BaseEvent
    {
        private readonly int eventCode;

        public EventPacketHandler(int eventCode)
        {
            this.eventCode = eventCode;
        }

        protected abstract Task OnActionAsync(TEvent value);

        protected internal override Task OnHandleAsync(EventPacket packet)
        {
            if (eventCode != packet.EventCode)
            {
                return NextAsync(packet);
            }
            else
            {
                TEvent instance = (TEvent)Activator.CreateInstance(typeof(TEvent), packet.Parameters);

                return OnActionAsync(instance);
            }
        }
    }
}
