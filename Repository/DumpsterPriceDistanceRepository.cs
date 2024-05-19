using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaDumpsterAPI.Data;
using RaDumpsterAPI.Models;
using RaDumpsterAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Repository
{
    public class DumpsterPriceDistanceRepository : IDumpsterPriceDistanceRepository
    {
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;

        public DumpsterPriceDistanceRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DumpsterPriceDistanceDTO>> GetAllDumpsterPriceDistance()
        {
            List<DumpsterPriceDistance> result = await _dbContext.DumpsterPriceDistance.Include(d => d.DumpsterCategory).ToListAsync();

            return _mapper.Map<List<DumpsterPriceDistanceDTO>>(result);
        }
    }
}
