using System;

namespace Albion.Network.Handler
{
    public class MoveHandler : RequestHandler
    {
        protected override void OnHandle(RequestResult packet)
        {
            if (packet.OperationCode != OperationCodes.Move)
            {
                Next(packet);
            }
            else
            {
                Console.WriteLine("Request: Move");
            }
        }
    }
}
