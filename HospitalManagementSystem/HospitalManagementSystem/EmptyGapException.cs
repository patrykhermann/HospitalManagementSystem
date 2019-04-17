using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem
{

    [Serializable]
    public class EmptyGapException : Exception
    {
        public EmptyGapException() { }
        public EmptyGapException(string message) : base(message) { }
        public EmptyGapException(string message, Exception inner) : base(message, inner) { }
        protected EmptyGapException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
