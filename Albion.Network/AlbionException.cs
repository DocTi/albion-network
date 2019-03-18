// This is an open source non-commercial project. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++ and C#: http://www.viva64.com

using System;
using System.Runtime.Serialization;

namespace Albion.Network
{
    public class AlbionException : Exception
    {
        internal AlbionException() { }

        internal AlbionException(string message) : base(message) { }

        internal AlbionException(string message, Exception innerException) : base(message, innerException) { }

        internal AlbionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
