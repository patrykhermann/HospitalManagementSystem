using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{

    [Serializable]
    public class TooMuchDutiedInTheMonthException : Exception
    {
        public TooMuchDutiedInTheMonthException() { }
        public TooMuchDutiedInTheMonthException(string message) : base(message) { }
        public TooMuchDutiedInTheMonthException(string message, Exception inner) : base(message, inner) { }
        protected TooMuchDutiedInTheMonthException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
