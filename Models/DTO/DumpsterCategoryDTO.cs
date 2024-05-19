using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models.DTO
{
    public class DumpsterCategoryDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Width { get; set; }

        public string Length { get; set; }

        public string Height { get; set; }

        public string BestFor { get; set; }

        public string ImgURL { get; set; }
    }
}
