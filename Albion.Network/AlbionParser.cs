// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using PhotonPackageParser;
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

            AddHandler(new EventPacketHandler());
            AddHandler(new RequestPacketHandler());
            AddHandler(new ResponsePacketHandler());
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

        public AlbionParser AddHandler(IPacketHandler handler)
        {
            LastHandler?.SetNext(handler);
            handlers.Add(handler);

            return this;
        }

        protected override void OnEvent(byte Code, Dictionary<byte, object> Parameters)
        {
            var eventPacket = new EventPacket(Code, Parameters);

            FirstHandler?.Handle(eventPacket);
        }

        protected override void OnRequest(byte OperationCode, Dictionary<byte, object> Parameters)
        {
            var requestPacket = new RequestPacket(OperationCode, Parameters);

            FirstHandler?.Handle(requestPacket);
        }

        protected override void OnResponse(byte OperationCode, short ReturnCode, string DebugMessage, Dictionary<byte, object> Parameters)
        {
            var responsePacket = new ResponsePacket(OperationCode, ReturnCode, DebugMessage, Parameters);

            FirstHandler?.Handle(responsePacket);
        }
    }
}
