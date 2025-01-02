using AutoMapper;
using Parking.Adapters.Driven.MongoDB.Model;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Request;
using Parking.Adapters.Driving.Api.Dtos.Vehicle.Response;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Inputs;
using Parking.Core.Domain.Application.UseCase.Vehicle.Dtos.Outputs;
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

            CreateMap<ListVehicleOutput, ListVehicleResponse>().ReverseMap();
            CreateMap<ParkingRecordsEntity, ListVehicleOutput.ListVehicleReponseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Plate, opt => opt.MapFrom(src => src.Plate))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Owner))
                .ForMember(dest => dest.EntryTime, opt => opt.MapFrom(src => src.EntryTime))
                .ForMember(dest => dest.ExitTime, opt => opt.MapFrom(src => (DateTime?)src.ExitTime))
                .ForMember(dest => dest.EmployerId, opt => opt.MapFrom(src => src.EmployerId))
                .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => src.VehicleType));
        }
    }
}
