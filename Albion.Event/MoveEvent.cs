using Albion.Common;
using Albion.Network;
using System;
using System.Collections.Generic;

namespace Albion.Event
{
    public class MoveEvent : BaseEvent
    {
        public MoveEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            byte[] bytes = (byte[])parameters[1];
            float x = BitConverter.ToSingle(bytes, 9);
            float y = BitConverter.ToSingle(bytes, 13);

            Id = parameters[0].ToString();
            Position = new Position(x, y);
        }

        public string Id { get; }
        public Position Position { get; }
    }
}
