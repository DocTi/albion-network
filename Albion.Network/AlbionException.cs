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
