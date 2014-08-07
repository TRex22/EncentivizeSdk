using System;
using System.Runtime.Serialization;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class DataRetrievalFailedException: EncentivizeApiException
    {
         public DataRetrievalFailedException(string message)
            : base(message)
        {
        }

        public DataRetrievalFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected DataRetrievalFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}