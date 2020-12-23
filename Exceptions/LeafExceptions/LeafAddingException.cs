using System;
using System.Runtime.Serialization;

namespace Exceptions.LeafExceptions
{
    [Serializable]
    public class LeafAddingException : Exception
    {
        public LeafAddingException()
        {
        }

        public LeafAddingException(string message)
            : base(message)
        {
        }

        public LeafAddingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected LeafAddingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}