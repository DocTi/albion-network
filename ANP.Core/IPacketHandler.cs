namespace ANP.Core
{
    public interface IPacketHandler
    {
        IPacketHandler SetNext(IPacketHandler handler);
        void Handle(object request);
    }
}
