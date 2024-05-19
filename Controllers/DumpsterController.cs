
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
    //[Authorize]
    public class DumpsterController : ControllerBase
    {
        private readonly IDumpsterRepository dumpsterRepository;
        protected ResponseDTO response;

        public DumpsterController(IDumpsterRepository _dumpsterRepository)
        {
            dumpsterRepository = _dumpsterRepository;
            response = new ResponseDTO();
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Dumpster>))]
        [ProducesResponseType(400)] // Bad Request
        public async Task<IActionResult> GetAllDumpsters()
        {
            try
            {
                var result = await dumpsterRepository.GetAllDupsters();
                response.Result = result;
                response.DisplayMessage = "Dumpster List";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
                throw;
            }

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetDumpsterById")]
        [ProducesResponseType(200, Type = typeof(List<Dumpster>))]
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(404)] // Not Found
        public async Task<IActionResult> GetDumpsterById(int id)
        {
            try
            {
                var result = await dumpsterRepository.GetDupsterById(id);
                if (result == null)
                {
                    response.IsSuccess = false;
                    response.DisplayMessage = "Not Found";
                    return NotFound(response);
                }

                response.Result = result;
                response.DisplayMessage = "Dumpster Found";
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(response);
            }
        }

        // PUT: api/Dumpster
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDumpster(int id, DumpsterDTO dumpsterDTO)
        {
            try
            {
                DumpsterDTO result = await dumpsterRepository.CreateUpdateDumpster(dumpsterDTO);
                response.Result = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "An error occurred while Updating the Record";
                response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(response);
            }
        }

        // Post: api/Dumpster
        [HttpPost]
        public async Task<IActionResult> PostDumpster(DumpsterDTO dumpsterDTO)
        {
            try
            {
                DumpsterDTO result = await dumpsterRepository.CreateUpdateDumpster(dumpsterDTO);
                response.Result = result;
                return CreatedAtAction("GetDumpsterById", new { id = result.Id }, response);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "An error occurred while Creating the Record";
                response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(response);
            }
        }

        // Delete: api/Dumpster
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDumpster(int id)
        {
            try
            {
                bool result = await dumpsterRepository.DeleteDumpster(id);
                if (result)
                {
                    response.Result = result;
                    response.DisplayMessage = "Record Deleted Successfully";
                    return Ok(response);
                }
                else 
                {
                    response.IsSuccess = false;
                    response.DisplayMessage = "Error Deleting Record";
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.DisplayMessage = "Error Deleting Record";
                response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(response);
            }
        }

        //private readonly AppDbContext _dbContext;

        //public DumpsterController(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        //[HttpGet]
        //[ProducesResponseType(200, Type = typeof(List<Dumpster>))]
        //[ProducesResponseType(400)] // Bad Request
        //public async Task<IActionResult> GetDumpster() {
        //    var result = await _dbContext.Dumpster.OrderBy(d => d.Description)
        //                                    .Include(d => d.DumpsterCategory)
        //                                    .Include(d => d.DumpsterStatus)
        //                                    .ToListAsync();

        //    return Ok(result);
        //}

        //[HttpGet("{id}", Name = "GetDumpsterById")]
        //[ProducesResponseType(200, Type = typeof(List<Dumpster>))]
        //[ProducesResponseType(400)] // Bad Request
        //[ProducesResponseType(404)] // Not Found
        //public async Task<IActionResult> GetDumpsterById(int id)
        //{
        //    var result = await _dbContext.Dumpster.Include(d => d.DumpsterCategory)
        //                                    .Include(d => d.DumpsterStatus)
        //                                    .FirstOrDefaultAsync(d => d.Id == id);

        //    if (result == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(result);
        //}

        //[HttpPost]
        //[ProducesResponseType(201)] // Created Response
        //[ProducesResponseType(400)] // Bad Request
        //[ProducesResponseType(500)] // Internal Error
        //public async Task<IActionResult> CreateDumpster([FromBody] Dumpster dumpster)
        //{
        //    if (dumpster == null)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    await _dbContext.AddAsync(dumpster);
        //    await _dbContext.SaveChangesAsync();

        //    return CreatedAtRoute("GetDumpsterById", new { id = dumpster.Id }, dumpster);
        //}
    }
}
