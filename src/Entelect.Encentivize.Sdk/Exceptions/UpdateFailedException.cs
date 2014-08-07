using System;
using System.Runtime.Serialization;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class UpdateFailedException : EncentivizeApiException
    {
         public UpdateFailedException(string message)
            : base(message)
        {
        }

        public UpdateFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UpdateFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}