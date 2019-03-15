// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Event;
using Albion.Network;

namespace Albion.Handler
{
    public class LeaveHandler : EventHandler
    {
        protected override void OnHandle(EventResult packet)
        {
            if (packet.EventCode != Common.EventCodes.Leave)
            {
                Next(packet);
            }

            var leaveEvent = new LeaveEvent(packet.Parameters);

            Next(leaveEvent);
        }
    }
}
