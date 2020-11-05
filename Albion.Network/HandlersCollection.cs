using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task HandleAsync(object request)
        {
            if (Last != null)
            {
                await Last.HandleAsync(request);
            }
        }
    }
}
