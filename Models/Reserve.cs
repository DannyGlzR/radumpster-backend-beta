using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Models
{
    public class Reserve
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int DumpsterId { get; set; }

        [ForeignKey("DumpsterId")]
        public Dumpster Dumpster { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int ReservationDays { get; set; }

        public string Address { get; set; }

        public decimal Distance { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public decimal Price { get; set; }

        public decimal AdditionalCost { get; set; }

        public decimal Total { get; set; }

        public DateTime CreationDate { get; set; }

        [Required]
        public int ReserveStatusId { get; set; }

        [ForeignKey("ReserveStatusId")]
        public ReserveStatus ReserveStatus { get; set; }

        public bool Paid { get; set; }

    }
}