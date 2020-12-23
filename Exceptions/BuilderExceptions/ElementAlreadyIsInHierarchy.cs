using System;
using System.Runtime.Serialization;

namespace Exceptions.BuilderExceptions
{
    [Serializable]
    public class ElementAlreadyIsInHierarchy : Exception
    {
        public ElementAlreadyIsInHierarchy()
        {
        }

        public ElementAlreadyIsInHierarchy(string message)
            : base(message)
        {
        }

        public ElementAlreadyIsInHierarchy(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected ElementAlreadyIsInHierarchy(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}