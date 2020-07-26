using Albion.Common;
using Albion.Event;
using System;

namespace Albion.Network.Example
{
    public class NewCharacterEventHandler : EventPacketHandler<NewCharacterEvent>
    {
        public NewCharacterEventHandler() : base(EventCodes.NewCharacter) { }

        protected override void OnAction(NewCharacterEvent value)
        {
            Console.WriteLine($"New ch Id: {value.Id}");
        }
    }
}
