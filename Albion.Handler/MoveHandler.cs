// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using Albion.Network;
using Albion.Operation;

namespace Albion.Handler
{
    public class MoveHandler : RequestHandler
    {
        protected override void OnHandle(RequestResult packet)
        {
            if (packet.OperationCode != OperationCodes.Move)
            {
                Next(packet);
            }

            var operation = new MoveOperation(packet.Parameters);
        }
    }
}
