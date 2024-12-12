using AutoMapper;
using MongoDB.Bson;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;
using Parking.Core.Domain.Entity;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateVehicleRequest, CreateVehicleInput>();
            CreateMap<CreateVehicleOutput, CreateVehicleResponse>();

            CreateMap<RegisterVehicle, RegisterVehicleEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

            CreateMap<RegisterVehicleEntity, RegisterVehicle>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<EntryVehicleRequest, EntryVehicleInput>();
            CreateMap<EntryVehicle, EntryVehicleEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => new ObjectId(src.Id)));

            CreateMap<EntryVehicleEntity, EntryVehicle>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()));

            CreateMap<ExitVehicleRequest, ExitVehicleInput>();

            CreateMap<ExitVehicle, ExitVehicleEntity>();
            CreateMap<ExitVehicleEntity, ExitVehicle>();

        }
    }
}
