// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using Albion.Event;
using Albion.Network;

namespace Albion.Handler
{
    class HarvestableObjectHandler : EventHandler
    {
        protected override void OnHandle(EventResult packet)
        {
            if (packet.EventCode != EventCodes.NewHarvestableObject)
            {
                Next(packet);
            }

            var harvestableObjectEvent = new HarvestableObjectEvent(packet.Parameters);

            Next(harvestableObjectEvent);
        }
    }
}
