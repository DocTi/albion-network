using Albion.Network;
using System.Collections.Generic;

namespace Albion.Operation
{
    public class DebugOperation : BaseOperation
    {
        public DebugOperation(Dictionary<byte, object> parameters) : base(parameters)
        {
            Parameters = parameters;
        }

        public Dictionary<byte, object> Parameters { get; }
    }
}
