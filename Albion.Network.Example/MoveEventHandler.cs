using Albion.Common;
using Albion.Event;
using System;

namespace Albion.Network.Example
{
    public class MoveEventHandler : EventPacketHandler<MoveEvent>
    {
        public MoveEventHandler() : base(EventCodes.Move) { }

        protected override void OnAction(MoveEvent value)
        {
            Console.WriteLine($"Id: {value.Id} x: {value.Position[0]} y: {value.Position[1]}");
        }
    }
}
