// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

namespace Albion.Network
{
    public interface IPacketHandler
    {
        IPacketHandler SetNext(IPacketHandler handler);
        void Handle(object request);
    }
}
