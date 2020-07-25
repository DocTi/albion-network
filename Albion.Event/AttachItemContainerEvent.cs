using Albion.Network;
using System;
using System.Collections.Generic;

namespace Albion.Event
{
    public class AttachItemContainerEvent : BaseEvent
    {
        public AttachItemContainerEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            ObjectId = Convert.ToInt32(parameters[0]);
            ContainerId = new Guid((byte[])parameters[1]);
            ItemIds = GetItemIds(parameters[3]);
            Length = Convert.ToInt32(parameters[4]);
        }

        public int ObjectId { get; }
        public Guid ContainerId { get; }
        public short[] ItemIds { get; }
        public int Length { get; }

        private short[] GetItemIds(object obj)
        {
            if (obj is byte[])
            {
                return new short[] { };
            }
            else if (obj is short[])
            {
                return (short[])obj;
            }

            throw new NotSupportedException();
        }
    }
}
