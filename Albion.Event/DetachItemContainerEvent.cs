using Albion.Network;
using System;
using System.Collections.Generic;

namespace Albion.Event
{
    public class DetachItemContainerEvent : BaseEvent
    {
        public DetachItemContainerEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            ContainerId = new Guid((byte[])parameters[0]);
        }

        public Guid ContainerId { get; }
    }
}
