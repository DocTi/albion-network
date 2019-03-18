using Albion.Common;
using Albion.Event;
using Albion.Operation;

namespace Albion.Network
{
    public static class AlbionParserExtensions
    {
        public static AlbionParser AddEventHandler<TEvent>(this AlbionParser albionParser, EventCodes eventCode) where TEvent : BaseEvent, new()
        {
            var handler = new EventHandler<TEvent>(eventCode);

            albionParser.AddHandler(handler);

            return albionParser;
        }

        public static AlbionParser AddRequestHandler<TOpearation>(this AlbionParser albionParser, OperationCodes operationCode) where TOpearation : BaseOperation, new()
        {
            var handler = new RequestHandler<TOpearation>(operationCode);

            albionParser.AddHandler(handler);

            return albionParser;
        }

        public static AlbionParser AddResponseHandler<TOperation>(this AlbionParser albionParser, OperationCodes operationCode) where TOperation : BaseOperation, new()
        {
            var handler = new ResponseHandler<TOperation>(operationCode);

            albionParser.AddHandler(handler);

            return albionParser;
        }
    }
}
