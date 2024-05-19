
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
using AutoMapper;

namespace RaDumpsterAPI.Repository
{
    public class SetupParameterRepository : ISetupParameterRepository
    {
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;

        public SetupParameterRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<SetupParameterDTO> GetParameterByName(string name)
        {
            SetupParameter parameter = await _dbContext.SetupParameter.FirstOrDefaultAsync(u => u.Name.ToLower() == name.ToString().ToLower());

            return _mapper.Map<SetupParameterDTO>(parameter);

        }
    }
}
