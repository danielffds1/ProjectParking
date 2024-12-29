using AutoMapper;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;
using Parking.Core.Domain.Entity;
using Parking.Core.Domain.Enums;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateVehicleRequest, CreateVehicleInput>();
            CreateMap<CreateVehicleOutput, CreateVehicleResponse>();

            CreateMap<CreateVehicleInput, RegisterVehicleEntity>();

            CreateMap<EntryVehicleRequest, EntryVehicleInput>();
            CreateMap<EntryVehicleInput, ParkingRecordsEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => VehicleStatus.Parked));

            CreateMap<ExitVehicleRequest, ExitVehicleInput>();
            CreateMap<ExitVehicleInput, ParkingRecordsEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => VehicleStatus.Exited));

            CreateMap<ExitVehicle, ExitVehicleEntity>();
            CreateMap<ExitVehicleEntity, ExitVehicle>();

        }
    }
}
