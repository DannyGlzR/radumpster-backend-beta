using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models.DTO
{
    public class DumpsterDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int DumpsterCategoryId { get; set; }

        public DumpsterCategoryDTO DumpsterCategory { get; set; }

        public int DumpsterStatusId { get; set; }

        public DumpsterStatusDTO DumpsterStatus { get; set; }
    }
}
