using System.Threading.Tasks;

namespace Albion.Network
{
    public abstract class PacketHandler<TPacket> : IPacketHandler
    {
        private IPacketHandler nextHandler;

        public IPacketHandler SetNext(IPacketHandler handler)
        {
            nextHandler = handler;

            return handler;
        }

        public Task HandleAsync(object request)
        {
            if (request is TPacket packet)
            {
                return OnHandleAsync(packet);
            }
            else if (nextHandler != null)
            {
                return NextAsync(request);
            }

            return Task.CompletedTask;
        }

        protected internal abstract Task OnHandleAsync(TPacket packet);

        protected Task NextAsync(object request)
        {
            return nextHandler?.HandleAsync(request) ?? Task.CompletedTask;
        }
    }
}
