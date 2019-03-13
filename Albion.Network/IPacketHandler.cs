namespace Albion.Network
{
    public interface IPacketHandler
    {
        IPacketHandler SetNext(IPacketHandler handler);
        void Handle(object request);
    }
}
