using System.Collections.Generic;

namespace Albion.Network
{
    public class RequestResult
    {
        internal RequestResult(OperationCodes operationCode, Dictionary<byte, object> parameters)
        {
            OperationCode = operationCode;
            Parameters = parameters;
        }

        public OperationCodes OperationCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
