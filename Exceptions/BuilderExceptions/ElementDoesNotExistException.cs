using System;
using System.Runtime.Serialization;

namespace Exceptions.BuilderExceptions
{
    [Serializable]
    public class ElementDoesNotExistException : Exception
    {
        public ElementDoesNotExistException()
        {
        }

        public ElementDoesNotExistException(string message)
            : base(message)
        {
        }

        public ElementDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected ElementDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}