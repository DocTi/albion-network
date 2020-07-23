using Albion.Common;
using System;

namespace Albion.Network
{
    public class ReceiverBuilder
    {
        private readonly AlbionParser parser;

        public ReceiverBuilder()
        {
            parser = new AlbionParser();
        }

        public static ReceiverBuilder Create()
        {
            return new ReceiverBuilder();
        }

        public ReceiverBuilder AddEventHandler<TEvent>(EventCodes code, Action<TEvent> action) where TEvent : BaseEvent
        {
            parser.AddHandler(new EventPacketHandler<TEvent>(code, action));

            return this;
        }

        public ReceiverBuilder AddRequestHandler<TOperation>(OperationCodes code, Action<TOperation> action) where TOperation : BaseOperation
        {
            parser.AddHandler(new RequestPacketHandler<TOperation>(code, action));

            return this;
        }

        public ReceiverBuilder AddResponseHandler<TOperation>(OperationCodes code, Action<TOperation> action) where TOperation : BaseOperation
        {
            parser.AddHandler(new ResponsePacketHandler<TOperation>(code, action));

            return this;
        }

        public IPhotonReceiver Build()
        {
            return parser;
        }
    }
}
