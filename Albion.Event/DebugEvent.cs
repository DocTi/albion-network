using Albion.Network;
using System.Collections.Generic;

namespace Albion.Event
{
    public class DebugEvent : BaseEvent
    {
        public DebugEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            Parameters = parameters;
        }

        public Dictionary<byte, object> Parameters { get; }
    }
}
