using Dapper;
using Parking.Adapters.Driven.SQLServer.EF;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories.VehicleRepository;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using System.Data;

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
        public async Task<CreateVehicleInput> GetByIdAsync(int id)
        {
            string sql = "SELECT * FROM Vehicles WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<CreateVehicleInput>(sql, new { Id = id });
        }
        //EF implementation
        public async Task<CreateVehicleInput> AddAsync(CreateVehicleInput vehicle)
        {
            _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();
            return vehicle;
        }
    }
}
