namespace Albion.Network
{
    public interface IPacketHandler
    {
        void Handle(object request);
    }
}
