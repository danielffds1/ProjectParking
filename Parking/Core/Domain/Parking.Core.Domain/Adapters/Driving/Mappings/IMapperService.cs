namespace Parking.Core.Domain.Adapters.Driving.Mappings
{
    public interface IMapperService
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}
