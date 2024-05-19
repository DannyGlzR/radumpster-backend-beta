using Microsoft.AspNetCore.Mvc;
using RaDumpsterAPI.Models;
using RaDumpsterAPI.Models.DTO;
using RaDumpsterAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DumpsterPriceDistanceController : ControllerBase
    {
        private readonly IDumpsterPriceDistanceRepository dumpsterPriceDistanceRepository;
        protected ResponseDTO response;

        public DumpsterPriceDistanceController(IDumpsterPriceDistanceRepository _dumpsterPriceDistanceRepository)
        {
            dumpsterPriceDistanceRepository = _dumpsterPriceDistanceRepository;
            response = new ResponseDTO();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Dumpster>))]
        [ProducesResponseType(400)] // Bad Request
        public async Task<IActionResult> GetAllDumpsterPriceDistance()
        {
            try
            {
                var result = await dumpsterPriceDistanceRepository.GetAllDumpsterPriceDistance();
                response.Result = result;
                response.DisplayMessage = "Dumpster Price Distance List";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
                throw;
            }

            return Ok(response);
        }
    }
}
