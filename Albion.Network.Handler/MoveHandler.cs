using System;

namespace Albion.Network.Handler
{
    public class MoveHandler : RequestHandler
    {
        protected override void OnHandle(RequestResult packet)
        {
            Console.WriteLine("Request: Move");
        }
    }
}
