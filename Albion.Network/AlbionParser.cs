// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using PhotonPackageParser;
using System;
using System.Collections.Generic;

namespace Albion.Network
{
    internal sealed class AlbionParser : PhotonParser, IPhotonReceiver
    {
        private readonly HandlersCollection handlers;

        public AlbionParser()
        {
            handlers = new HandlersCollection();
        }

        public void AddHandler<TPacket>(PacketHandler<TPacket> handler)
        {
            handlers.Add(handler);
        }

        protected override void OnEvent(byte Code, Dictionary<byte, object> Parameters)
        {
            if (Code == 2)
            {
                Parameters.Add(252, (short)EventCodes.Move);
            }

            EventCodes eventCode = ParseEventCode(Parameters);
            var eventPacket = new EventPacket(eventCode, Parameters);

            handlers.Handle(eventPacket);
        }

        protected override void OnRequest(byte OperationCode, Dictionary<byte, object> Parameters)
        {
            OperationCodes operationCode = ParseOperationCode(Parameters);
            var requestPacket = new RequestPacket(operationCode, Parameters);

            handlers.Handle(requestPacket);
        }

        protected override void OnResponse(byte OperationCode, short ReturnCode, string DebugMessage, Dictionary<byte, object> Parameters)
        {
            OperationCodes operationCode = ParseOperationCode(Parameters);
            var responsePacket = new ResponsePacket(operationCode, Parameters);

            handlers.Handle(responsePacket);
        }

        private OperationCodes ParseOperationCode(Dictionary<byte, object> parameters)
        {
            if (!parameters.TryGetValue(253, out var value))
            {
                throw new InvalidOperationException();
            }

            return (OperationCodes)value;
        }

        private EventCodes ParseEventCode(Dictionary<byte, object> parameters)
        {
            if (!parameters.TryGetValue(252, out var value))
            {
                throw new InvalidOperationException();
            }

            return (EventCodes)value;
        }
    }
}
