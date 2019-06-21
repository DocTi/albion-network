// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Network;
using System.Collections.Generic;

namespace Albion.Event
{
    public class JoinFinishedEvent : BaseEvent
    {
        public JoinFinishedEvent(Dictionary<byte, object> parameters) : base(parameters) { }
    }
}
