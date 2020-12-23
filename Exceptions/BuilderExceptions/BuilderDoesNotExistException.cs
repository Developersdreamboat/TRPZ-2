using System;
using System.Runtime.Serialization;

namespace Exceptions.BuilderExceptions
{
    [Serializable]
    public class BuilderDoesNotExistException : Exception
    {
        public BuilderDoesNotExistException()
        {
        }

        public BuilderDoesNotExistException(string message)
            : base(message)
        {
        }

        public BuilderDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected BuilderDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}