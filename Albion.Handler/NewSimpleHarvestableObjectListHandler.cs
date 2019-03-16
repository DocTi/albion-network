// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Event;
using Albion.Network;

namespace Albion.Handler
{
    public class NewSimpleHarvestableObjectListHandler : EventResultHandler
    {
        protected override void OnHandle(EventResult packet)
        {
            if (packet.EventCode != Common.EventCodes.NewSimpleHarvestableObjectList)
            {
                Next(packet);
            }

            var newSimpleHarvestableObjectListEvent = new NewSimpleHarvestableObjectListEvent(packet.Parameters);

            Next(newSimpleHarvestableObjectListEvent);
        }
    }
}
