using RaDumpsterAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Repository
{
    public interface IDumpsterRepository
    {
        Task<List<DumpsterDTO>> GetAllDupsters();
        Task<DumpsterDTO> GetDupsterById(int Id);
        Task<DumpsterDTO> CreateUpdateDumpster(DumpsterDTO dumpsterDTO);
        Task<bool> DeleteDumpster(int Id);
    }
}
