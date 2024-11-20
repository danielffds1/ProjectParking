using AutoMapper;
using Parking.Core.Domain.Adapters.Driving.Mappings;

namespace Parking.Adapters.Driving.Api.Mapppings
{
    public class MapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
