// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

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

        public void Handle(object request)
        {
            if (request is TPacket)
            {
                OnHandle((TPacket)request);
            }
            else if (nextHandler != null)
            {
                Next(request);
            }
        }

        protected internal abstract void OnHandle(TPacket packet);

        protected void Next(object request)
        {
            nextHandler?.Handle(request);
        }
    }
}
