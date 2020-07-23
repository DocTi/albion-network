using System.Collections.Generic;
using System.Linq;

namespace Albion.Network
{
    internal class HandlersCollection
    {
        private readonly List<IPacketHandler> handlers;

        public HandlersCollection()
        {
            handlers = new List<IPacketHandler>();
        }

        private IPacketHandler Last
        {
            get
            {
                return handlers.LastOrDefault();
            }
        }

        public void Add<TPacket>(PacketHandler<TPacket> handler)
        {
            handler.SetNext(Last);
            handlers.Add(handler);
        }

        public void Handle(object request)
        {
            Last?.Handle(request);
        }
    }
}
