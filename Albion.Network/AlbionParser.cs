// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using PhotonPackageParser;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Albion.Network
{
    public sealed class AlbionParser : PhotonParser
    {
        private readonly ICollection<IPacketHandler> handlers;

        public AlbionParser()
        {
            handlers = new List<IPacketHandler>();
        }

        private IPacketHandler FirstHandler
        {
            get
            {
                return handlers.FirstOrDefault();
            }
        }

        private IPacketHandler LastHandler
        {
            get
            {
                return handlers.LastOrDefault();
            }
        }

        internal AlbionParser AddHandler(IPacketHandler handler)
        {
            LastHandler?.SetNext(handler);
            handlers.Add(handler);

            return this;
        }

        protected override void OnEvent(byte Code, Dictionary<byte, object> Parameters)
        {
            if (Code == 2)
            {
                Parameters.Add(252, (short)EventCodes.Move);
            }

            EventCodes eventCode = ParseEventCode(Parameters);
            var eventPacket = new EventPacket(eventCode, Parameters);

            FirstHandler?.Handle(eventPacket);
        }

        protected override void OnRequest(byte OperationCode, Dictionary<byte, object> Parameters)
        {
            OperationCodes operationCode = ParseOperationCode(Parameters);
            var requestPacket = new RequestPacket(operationCode, Parameters);

            FirstHandler?.Handle(requestPacket);
        }

        protected override void OnResponse(byte OperationCode, short ReturnCode, string DebugMessage, Dictionary<byte, object> Parameters)
        {
            OperationCodes operationCode = ParseOperationCode(Parameters);
            var responsePacket = new ResponsePacket(operationCode, Parameters);

            FirstHandler?.Handle(responsePacket);
        }

        private OperationCodes ParseOperationCode(Dictionary<byte, object> parameters)
        {
            if (!parameters.TryGetValue(253, out var value))
            {
                throw new AlbionException();
            }

            return (OperationCodes)value;
        }

        private EventCodes ParseEventCode(Dictionary<byte, object> parameters)
        {
            if (!parameters.TryGetValue(252, out var value))
            {
                throw new AlbionException();
            }

            return (EventCodes)value;
        }
    }
}
