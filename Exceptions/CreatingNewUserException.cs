using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Exceptions
{
    public class CreatingNewUserException : Exception
    {
        public CreatingNewUserException() { }

        public CreatingNewUserException(string message)
            : base(message) { }
    }
}
