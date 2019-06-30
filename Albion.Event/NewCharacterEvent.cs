// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using Albion.Network;
using System.Collections.Generic;

namespace Albion.Event
{
    public class NewCharacterEvent : BaseEvent
    {
        public NewCharacterEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            float[] position = (float[])parameters[12];

            Id = parameters[0].ToString();
            Name = parameters[1].ToString();
            GuildName = parameters.TryGetValue(8, out object guildName) ? guildName.ToString() : null;
            Position = new Position(position[0], position[1]);
        }

        public string Id { get; }
        public string Name { get; }
        public string GuildName { get; }
        public Position Position { get; }
    }
}
