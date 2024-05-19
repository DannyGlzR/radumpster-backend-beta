using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models
{
    public class Dumpster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int DumpsterCategoryId { get; set; }

        [ForeignKey("DumpsterCategoryId")]
        public DumpsterCategory DumpsterCategory { get; set; }

        [Required]
        public int DumpsterStatusId { get; set; }

        [ForeignKey("DumpsterStatusId")]
        public DumpsterStatus DumpsterStatus { get; set; }
    }
}
