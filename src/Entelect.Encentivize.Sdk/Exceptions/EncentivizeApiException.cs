using System;
using System.Runtime.Serialization;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public abstract class EncentivizeApiException : Exception
    {
        protected EncentivizeApiException(string message)
            : base(message)
        {
        }

        protected EncentivizeApiException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected EncentivizeApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
