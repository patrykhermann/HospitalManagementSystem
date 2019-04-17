using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    [Serializable]
    public class WrongPeselException : Exception
    {
        public WrongPeselException() { }
        public WrongPeselException(string message) : base(message) { }
        public WrongPeselException(string message, Exception inner) : base(message, inner) { }
        protected WrongPeselException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
