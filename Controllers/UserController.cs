using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RaDumpsterAPI.Data;
using RaDumpsterAPI.Exceptions;
using RaDumpsterAPI.Models;
using RaDumpsterAPI.Models.DTO;
using RaDumpsterAPI.Models.Security;
using RaDumpsterAPI.Repository;

namespace RaDumpsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        protected ResponseDTO response;

        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
            response = new ResponseDTO();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDTO user)
        {
            try
            {
                var result = await userRepository.Register(
               new User
               {
                   Email = user.Email,
                   UserName = user.UserName,
                   FirstName = user.FirstName,
                   LastName = user.LastName,
                   Phone = user.Phone,
                   Zipcode = user.Zipcode,
                   Address = user.Address
               }, user.Password);

                response.DisplayMessage = "User Created Successfully";

                JwtPakage jwt = new JwtPakage();
                jwt.UserId = result.Id;
                jwt.UserName = result.Email;
                jwt.Token = result.Token;

                response.Result = jwt;

                return Ok(response);
            }
            catch (UserAlreadyExistException)
            {
                //System.Diagnostics.Trace.WriteLine("user already exists");
                response.IsSuccess = false;
                response.DisplayMessage = "That user already exists";
                return BadRequest(response);
            }
            catch (CreatingNewUserException)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Error Creating User";
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                //if (ex. == "User Exists")
                //{
                //    response.IsSuccess = false;
                //    response.DisplayMessage = "That user already exists";
                //    return BadRequest(response);
                //}

                //if (result == "Error")
                //{
                //    response.IsSuccess = false;
                //    response.DisplayMessage = "Error Creating User";
                //    return BadRequest(response);
                //}

                response.IsSuccess = false;
                response.DisplayMessage = "Error";
                response.ErrorMessages.Add(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserDTO user)
        {
            try
            {
                var result = await userRepository.Login(user);

                //if (result == "NoUser")
                //{
                //    response.IsSuccess = false;
                //    response.DisplayMessage = "User does not exist";
                //    return BadRequest(response);
                //}

                //if (result == "WrongPassword")
                //{
                //    response.IsSuccess = false;
                //    response.DisplayMessage = "Password Incorrect";
                //    return BadRequest(response);
                //}

                JwtPakage jwt = new JwtPakage();
                jwt.UserId = result.Id;
                jwt.UserName = user.UserName;
                jwt.UserEmail = user.Email;
                jwt.Token = result.Token;

                response.Result = jwt;
                response.DisplayMessage = "User Connected";
                return Ok(response);
            }
            catch (NoUserException)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "User does not exist";
                return BadRequest(response);
            }
            catch (WrongPasswordException)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Password Incorrect";
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Error";
                response.ErrorMessages.Add(ex.Message);
                return BadRequest(response);
            }
            
        }
    }
}
