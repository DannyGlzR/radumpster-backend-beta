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
using Microsoft.Data.SqlClient;
using System.Data;
using AutoMapper;

namespace RaDumpsterAPI.Repository
{
    public class ReserveRepository : IReserveRepository
    {
        private readonly AppDbContext DbContext;
        private readonly IConfiguration Configuration;
        private IMapper mapper;

        public ReserveRepository(AppDbContext _DbContext, IConfiguration _configuration, IMapper _mapper)
        {
            DbContext = _DbContext;
            Configuration = _configuration;
            mapper = _mapper;
        }

        public async Task<int> GetTOPAvailableDumpstersByCategoryandDateRange(int CategoryId, string StartDate, string EndDate) 
        {
            SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
            conn.Open();

            SqlCommand cmd = new SqlCommand("GetTOPAvailableDumpstersByCategoryandDateRange", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CategoryId", CategoryId));
            cmd.Parameters.Add(new SqlParameter("@StartDate", StartDate));
            cmd.Parameters.Add(new SqlParameter("@EndDate", EndDate));

            SqlDataReader rdr = await cmd.ExecuteReaderAsync();

            var availableDumpsterId = 0;
            while (rdr.Read())
            {
                availableDumpsterId = (int)rdr["Id"];
            }

            return availableDumpsterId;
        }

        public async Task<string> Register(ReserveDTO reserveDTO)
        {
            try
            {
                Reserve reserve = mapper.Map<ReserveDTO, Reserve>(reserveDTO);

                await DbContext.Reserve.AddAsync(reserve);
                await DbContext.SaveChangesAsync();

                return "success";

            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
