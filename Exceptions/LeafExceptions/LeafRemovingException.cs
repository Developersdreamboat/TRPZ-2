using System;
using System.Runtime.Serialization;

namespace Exceptions.LeafExceptions
{
    [Serializable]
    public class LeafRemovingException : Exception
    {
        public LeafRemovingException()
        {
        }

        public LeafRemovingException(string message)
            : base(message)
        {
        }

        public LeafRemovingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected LeafRemovingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}