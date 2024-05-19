using RaDumpsterAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Repository
{
    public interface IDumpsterPriceDistanceRepository
    {
        Task<List<DumpsterPriceDistanceDTO>> GetAllDumpsterPriceDistance();
    }
}
