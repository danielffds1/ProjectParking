using Microsoft.EntityFrameworkCore;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;

namespace Parking.Adapters.Driven.SQLServer.EF
{
    public class ParkingDbContext : DbContext
    {
        public ParkingDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<CreateVehicleInput> Vehicles { get; set; }
    }
}
