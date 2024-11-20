using AutoMapper;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class MappingProfile : Profile
    {
        private readonly IMapper _mapper;

        public MappingProfile()
        {
            CreateMap<CreateVehicleRequest, CreateVehicleInput>();
            CreateMap<CreateVehicleOutput, CreateVehicleResponse>();
        }
    }
}
