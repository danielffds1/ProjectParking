using Microsoft.EntityFrameworkCore;
using Parking.Adapters.Driven.SQLServer.EF;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories.VehicleRepository;
using Parking.Core.Domain.Entity;
using System.Data;
using Dapper;

namespace Parking.Adapters.Driven.SQLServer.Repositories.VehicleRepository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IDbConnection _dbConnection;
        private readonly ParkingDbContext _dbContext;

        public VehicleRepository(IDbConnection dbConnection, ParkingDbContext dbContext)
        {
            _dbConnection = dbConnection;
            _dbContext = dbContext;
        }

        //Dapper implementation
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Vehicles WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Vehicle>(sql, new { Id = id });
        }
        //EF implementation
        public async Task<Vehicle> AddAsync(Vehicle vehicle)
        {
            _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();
            return vehicle;
        }
    }
}
