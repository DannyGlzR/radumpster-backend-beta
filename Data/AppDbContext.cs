using Microsoft.EntityFrameworkCore;
using RaDumpsterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaDumpsterAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> option) : base(option) { }

        public DbSet<Dumpster> Dumpster { get; set; }
        public DbSet<DumpsterCategory> DumpsterCategory { get; set; }
        public DbSet<DumpsterPriceDistance> DumpsterPriceDistance { get; set; }
        public DbSet<DumpsterStatus> DumpsterStatus { get; set; }
        public DbSet<SetupParameter> SetupParameter { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<ReserveStatus> ReserveStatus { get; set; }


    }
}
