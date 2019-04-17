using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{

    [Serializable]
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() { }
        public WrongPasswordException(string message) : base(message) { }
        public WrongPasswordException(string message, Exception inner) : base(message, inner) { }
        protected WrongPasswordException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
