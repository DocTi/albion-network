// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System.Collections.Generic;

namespace Albion.Event
{
    public class NewSimpleHarvestableObjectListEvent : BaseEvent
    {
        public NewSimpleHarvestableObjectListEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            HarvestableObjects = new List<HarvestableObjectEvent>();

            if (parameters[0] is byte[])
            {
                var ids = (byte[])parameters[0];
                var types = (byte[])parameters[1];
                var tiers = (byte[])parameters[2];
                var positions = (float[])parameters[3];
                var sizes = (byte[])parameters[4];

                for (int i = 0; i < ids.Length; i++)
                {
                    var harvestParameters = new Dictionary<byte, object>
                    {
                        { 0, ids[i] },
                        { 1, types[i] },
                        { 2, tiers[i] },
                        { 3, new float[] { positions[i], positions[i + 1] } },
                        { 4, sizes[i] }
                    };

                    var harvestableObject = new HarvestableObjectEvent(harvestParameters);

                    HarvestableObjects.Add(harvestableObject);
                }
            }
            else if (parameters[0] is short[])
            {
                var ids = (short[])parameters[0];
                var types = (byte[])parameters[1];
                var tiers = (byte[])parameters[2];
                var positions = (float[])parameters[3];
                var sizes = (byte[])parameters[4];

                for (int i = 0; i < ids.Length; i++)
                {
                    var harvestParameters = new Dictionary<byte, object>
                    {
                        { 0, ids[i] },
                        { 1, types[i] },
                        { 2, tiers[i] },
                        { 3, new float[] { positions[i], positions[i + 1] } },
                        { 4, sizes[i] }
                    };

                    var harvestableObject = new HarvestableObjectEvent(harvestParameters);

                    HarvestableObjects.Add(harvestableObject);
                }
            }
        }

        public List<HarvestableObjectEvent> HarvestableObjects { get; }
    }
}
