using System.Threading.Tasks;

namespace Albion.Network
{
    public interface IPacketHandler
    {
        Task HandleAsync(object request);
    }
}
