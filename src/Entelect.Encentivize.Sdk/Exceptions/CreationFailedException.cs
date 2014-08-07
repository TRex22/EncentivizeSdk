using System;
using System.Runtime.Serialization;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class CreationFailedException: EncentivizeApiException
    {
         public CreationFailedException(string message)
            : base(message)
        {
        }

        public CreationFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected CreationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}