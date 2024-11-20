namespace Parking.Core.Domain.Adapters.Driven.Storage.Repositories
{
    public interface IGenericRepositoryMongo<T> where T : class
    {
        Task InsertAsync(T entity);
        Task<T> UpdateAsync(string id, T entity);
        Task DeleteAsync(string id);
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();


    }
}
