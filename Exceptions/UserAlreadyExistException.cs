using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Exceptions
{
    public class UserAlreadyExistException : Exception
    {
        public UserAlreadyExistException() { }

        public UserAlreadyExistException(string message)
            : base(message) { }
    }
}
