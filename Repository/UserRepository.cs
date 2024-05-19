
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RaDumpsterAPI.Data;
using RaDumpsterAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using RaDumpsterAPI.Models.DTO;
using RaDumpsterAPI.Exceptions;

namespace RaDumpsterAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AppDbContext DbContext;
        private readonly IConfiguration configuration;

        public UserRepository(AppDbContext _DbContext, IConfiguration _configuration) {
            DbContext = _DbContext;
            configuration = _configuration;
        }

        public async Task<UserDTO> Login(UserDTO _user)
        {
            var user = await DbContext.User.FirstOrDefaultAsync(u => u.Email.ToLower().Equals(_user.Email.ToLower()));

            if (user == null)
            {
                //return "NoUser";
                throw new NoUserException();
            }
            else if (!VerifyPasswordHash(_user.Password, user.PasswordHash, user.PasswordSalt))
            {
                //return "WrongPassword";
                throw new WrongPasswordException();
            }
            else
            {
                _user.Id = user.Id;
                _user.UserName = user.UserName;
                _user.Token = CreateToken(user);
                return _user;
            }
        }

        public async Task<UserDTO> Register(User user, string password)
        {
            try
            {
                if (await UserExists(user.Email))
                {
                    throw new UserAlreadyExistException();
                }

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await DbContext.User.AddAsync(user);
                await DbContext.SaveChangesAsync();

                UserDTO userDTO = new UserDTO();
                userDTO.Id = user.Id;
                userDTO.Email = user.Email;
                userDTO.Token = CreateToken(user);

                return userDTO;
            }
            catch (Exception)
            {

                throw new CreatingNewUserException();
            }
            
        }

        public async Task<bool> UserExists(string email)
        {
            if (await DbContext.User.AnyAsync(u => u.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                    Subject = new ClaimsIdentity(claims),
                    Expires = System.DateTime.Now.AddDays(1),
                    SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
