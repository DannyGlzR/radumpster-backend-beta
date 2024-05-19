using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models
{
    public class DumpsterPriceDistance
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int DistanceStart { get; set; }

        public int DistanceEnd { get; set; }

        [Required]
        public int DumpsterCategoryId { get; set; }
        [ForeignKey("DumpsterCategoryId")]
        public DumpsterCategory DumpsterCategory { get; set; }


    }
}
