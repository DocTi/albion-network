using Albion.Network;
using System;
using System.Collections.Generic;

namespace Albion.Event
{
    public class NewSimpleItemEvent : BaseEvent
    {
        public NewSimpleItemEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            Id = Convert.ToInt32(parameters[0]);
            ItemId = Convert.ToInt32(parameters[1]);
            Count = Convert.ToInt32(parameters[2]);
        }

        public int Id { get; }
        public int ItemId { get; }
        public int Count { get; }
    }
}
