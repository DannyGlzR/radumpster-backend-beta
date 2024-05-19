using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Exceptions
{
    public class NoUserException: Exception
    {
        public NoUserException() { }

        public NoUserException(string message)
            : base(message) { }
    }
}
