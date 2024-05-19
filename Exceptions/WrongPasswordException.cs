using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Exceptions
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException() { }

        public WrongPasswordException(string message)
            : base(message) { }
    }
}
