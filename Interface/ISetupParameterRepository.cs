using RaDumpsterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RaDumpsterAPI.Models.DTO;

namespace RaDumpsterAPI.Repository
{
    public interface ISetupParameterRepository
    {
        Task<SetupParameterDTO> GetParameterByName(string name);
    }
}