using Microsoft.AspNetCore.Mvc;
using RaDumpsterAPI.Models.DTO;
using RaDumpsterAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupParameterController: ControllerBase
    {
        private readonly ISetupParameterRepository setupParametersRepository;
        protected ResponseDTO response;

        public SetupParameterController(ISetupParameterRepository _dumpsterRepository)
        {
            setupParametersRepository = _dumpsterRepository;
            response = new ResponseDTO();
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetParameterByName(string name) 
        {
            var result = await setupParametersRepository.GetParameterByName(name);

            if (result == null)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Not Found";
                return NotFound(response);
            }

            response.Result = result;
            response.DisplayMessage = "Success";
            return Ok(response);

        }
    }
}
