using RaDumpsterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaDumpsterAPI.Models.DTO;

namespace RaDumpsterAPI.Repository
{
    public interface IUserRepository
    {
        Task<UserDTO> Register(User user, string password);
        Task<UserDTO> Login(UserDTO user);
        Task<bool> UserExists(string email);
    }
}
