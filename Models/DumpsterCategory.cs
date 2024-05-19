using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models
{
    public class DumpsterCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public string Width { get; set; }

        public string Length { get; set; }

        public string Height { get; set; }

        public string BestFor { get; set; }

        public string ImgURL { get; set; }

    }
}
