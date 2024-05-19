using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RaDumpsterAPI.Models.DTO;
using RaDumpsterAPI.Repository;

namespace RaDumpsterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase
    {
        private readonly IReserveRepository reserveRepository;
        protected ResponseDTO response;

        public ReserveController(IReserveRepository _reserveRepository)
        {
            reserveRepository = _reserveRepository;
            response = new ResponseDTO();
        }

        [HttpGet("GetTOPAvailableDumpstersByCategoryandDateRange")]
        public async Task<IActionResult> GetTOPAvailableDumpstersByCategoryandDateRange(int CategoryId, string StartDate, string EndDate)
        {
            try
            {
                var result = await reserveRepository.GetTOPAvailableDumpstersByCategoryandDateRange(CategoryId, StartDate, EndDate);


                if (result == 0)
                {
                    response.IsSuccess = false;
                    response.DisplayMessage = "No dumpsters available";
                    return BadRequest(response);
                }

                response.IsSuccess = true;
                response.DisplayMessage = "Dupster Available";
                response.Result = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessages.Add(ex.Message);
                response.DisplayMessage = "Error";
                return BadRequest(response);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(ReserveRegisterDTO reserve)
        {
            ReserveDTO test = new ReserveDTO() {
                UserId = reserve.UserId,
                DumpsterId = reserve.DumpsterId,
                StartDate = Convert.ToDateTime(reserve.StartDate),
                EndDate = Convert.ToDateTime(reserve.EndDate),
                ReservationDays = reserve.ReservationDays,
                Address = reserve.Address,
                Distance = reserve.Distance,
                Latitude = reserve.Latitude,
                Longitude = reserve.Longitude,
                Price = reserve.Price,
                AdditionalCost = reserve.AdditionalCost,
                Total = reserve.Total,
                CreationDate = DateTime.Now,
                ReserveStatusId = 1,
                Paid = reserve.Paid
            };

            var result = await reserveRepository.Register(test);

            if (result == "Error")
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Error Creating Reserve";
                return BadRequest(response);
            }

            response.DisplayMessage = "Reserve Created Successfully";

            return Ok(response);
        }
    }
}
