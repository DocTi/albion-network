using Albion.Common;
using Albion.Operation;
using System;

namespace Albion.Network.Example
{
    public class MoveRequestHandler : RequestPacketHandler<MoveOperation>
    {
        public MoveRequestHandler() : base(OperationCodes.Move) { }

        protected override void OnAction(MoveOperation value)
        {
            Console.WriteLine($"Move request");
        }
    }
}
