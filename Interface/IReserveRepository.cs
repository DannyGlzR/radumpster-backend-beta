using RaDumpsterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaDumpsterAPI.Models.DTO;

namespace RaDumpsterAPI.Repository
{
    public interface IReserveRepository
    {
        Task<int> GetTOPAvailableDumpstersByCategoryandDateRange(int CategoryId, string StartDate, string EndDate);
        Task<string> Register(ReserveDTO reserve);
    }
}
