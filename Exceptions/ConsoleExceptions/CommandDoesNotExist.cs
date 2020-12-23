using System;
using System.Runtime.Serialization;

namespace Exceptions.ConsoleExceptions
{
    [Serializable]
    public class CommandDoesNotExist : Exception
    {
        public CommandDoesNotExist()
        {
        }

        public CommandDoesNotExist(string message)
            : base(message)
        {
        }

        public CommandDoesNotExist(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected CommandDoesNotExist(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}