using System.Collections.Generic;

namespace Albion.Network
{
    public class EventResult
    {
        internal EventResult(EventCodes eventCode, Dictionary<byte, object> parameters)
        {
            EventCode = eventCode;
            Parameters = parameters;
        }

        public EventCodes EventCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
