using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models.Security
{
    public class JwtPakage
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
