using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RaDumpsterAPI.Data;
using RaDumpsterAPI.Models;
using RaDumpsterAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Repository
{
    public class DumpsterRepository : IDumpsterRepository
    {
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;

        public DumpsterRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DumpsterDTO>> GetAllDupsters()
        {
            List<Dumpster> result = await _dbContext.Dumpster.Include(d => d.DumpsterStatus)
                                                             .Include(d => d.DumpsterCategory).ToListAsync();
            
            return _mapper.Map<List<DumpsterDTO>>(result);
        }

        public async Task<DumpsterDTO> GetDupsterById(int Id)
        {
            Dumpster dumpster = await _dbContext.Dumpster
                                                .Include(d => d.DumpsterStatus)
                                                .Include(d => d.DumpsterCategory)
                                                .FirstOrDefaultAsync(d => d.Id == Id);

            return _mapper.Map<DumpsterDTO>(dumpster);
        }

        public async Task<DumpsterDTO> CreateUpdateDumpster(DumpsterDTO dumpsterDTO)
        {
            Dumpster dumpster = _mapper.Map<DumpsterDTO, Dumpster>(dumpsterDTO);
            
            if (dumpster.Id > 0)
            {
                _dbContext.Update(dumpster);
            }
            else
            {
                await _dbContext.AddAsync(dumpster);
            }

            await _dbContext.SaveChangesAsync();
            
            return _mapper.Map<Dumpster, DumpsterDTO>(dumpster);
        }

        public async Task<bool> DeleteDumpster(int Id)
        {
            try
            {
                Dumpster dumpster = await _dbContext.Dumpster.FindAsync(Id);

                if (dumpster == null)
                    return false;
                
                _dbContext.Dumpster.Remove(dumpster);

                await _dbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
