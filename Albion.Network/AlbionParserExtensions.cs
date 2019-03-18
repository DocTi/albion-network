using Albion.Common;
using Albion.Event;
using Albion.Operation;
using System;

namespace Albion.Network
{
    public static class AlbionParserExtensions
    {
        public static AlbionParser AddEventHandler<TEvent>(this AlbionParser albionParser, EventCodes eventCode, Action<TEvent> action) where TEvent : BaseEvent
        {
            var handler = new EventHandler<TEvent>(eventCode, action);

            albionParser.AddHandler(handler);

            return albionParser;
        }

        public static AlbionParser AddRequestHandler<TOpearation>(this AlbionParser albionParser, OperationCodes operationCode, Action<TOpearation> action) where TOpearation : BaseOperation
        {
            var handler = new RequestHandler<TOpearation>(operationCode, action);

            albionParser.AddHandler(handler);

            return albionParser;
        }

        public static AlbionParser AddResponseHandler<TOperation>(this AlbionParser albionParser, OperationCodes operationCode, Action<TOperation> action) where TOperation : BaseOperation
        {
            var handler = new ResponseHandler<TOperation>(operationCode, action);

            albionParser.AddHandler(handler);

            return albionParser;
        }
    }
}
