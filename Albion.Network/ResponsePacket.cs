// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using Albion.Common;
using System.Collections.Generic;

namespace Albion.Network
{
    public class ResponsePacket
    {
        public ResponsePacket(OperationCodes operationCode, Dictionary<byte, object> Parameters)
        {
            OperationCode = operationCode;
            this.Parameters = Parameters;
        }

        public OperationCodes OperationCode { get; }
        public Dictionary<byte, object> Parameters { get; }
    }
}
