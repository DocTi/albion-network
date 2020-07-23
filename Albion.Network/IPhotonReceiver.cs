namespace Albion.Network
{
    public interface IPhotonReceiver
    {
        void ReceivePacket(byte[] payload);
    }
}
