// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using System.Collections.Generic;

namespace Albion.Network
{
    internal class EventPacket
    {
        public EventPacket(EventCodes eventCode, Dictionary<byte, object> parameters)
        {
            EventCode = eventCode;
            Parameters = parameters;
        }

        public EventCodes EventCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
