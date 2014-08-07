using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Entelect.Encentivize.Sdk.Exceptions
{
    public class EncentivizeException :Exception
    {

       public EncentivizeException()
            : base("")
        {

        }

        public EncentivizeException(string message)
            : base(message)
        {

        }

        public EncentivizeException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected EncentivizeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

    }
}
