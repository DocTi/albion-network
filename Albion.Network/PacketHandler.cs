namespace Albion.Network
{
    public abstract class PacketHandler<TPacket> : IPacketHandler
    {
        protected IPacketHandler NextHandler { get; private set; }

        protected abstract void OnHandle(TPacket packet);

        public IPacketHandler SetNext(IPacketHandler handler)
        {
            NextHandler = handler;

            return handler;
        }

        public void Handle(object request)
        {
            if (request is TPacket)
            {
                OnHandle((TPacket)request);
            }
            else if (NextHandler != null)
            {
                NextHandler.Handle(request);
            }
        }
    }
}
