using Microsoft.EntityFrameworkCore;
using Parking.Core.Domain.Entity;

namespace Parking.Adapters.Driven.SQLServer.EF
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<RegisterVehicle> Vehicles { get; set; }
    }
}
