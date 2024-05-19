using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models.DTO
{
    public class DumpsterPriceDistanceDTO
    {
        
        public int Id { get; set; }

        public decimal Price { get; set; }

        public int DistanceStart { get; set; }

        public int DistanceEnd { get; set; }

        public int DumpsterCategoryId { get; set; }
      
        public DumpsterCategoryDTO DumpsterCategory { get; set; }

    }
}
