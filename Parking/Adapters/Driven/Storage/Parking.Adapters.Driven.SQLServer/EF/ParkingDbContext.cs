using Microsoft.EntityFrameworkCore;
using Parking.Core.Domain.Entity;

namespace Parking.Adapters.Driven.SQLServer.EF
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Id);

        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
