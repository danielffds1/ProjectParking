using MongoDB.Bson;
using MongoDB.Driver;
using Parking.Core.Domain.Adapters.Driven.Storage.Repositories;

namespace Parking.Adapters.Driven.MongoDB.GenericRepositoryMongo
{
    public class GenericRepositoryMongo<T> : IGenericRepositoryMongo<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public GenericRepositoryMongo(IMongoDatabase database)
        {
            _collection = database.GetCollection<T>(typeof(T).Name);
        }
        public async Task InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
        }
        public async Task<T> UpdateAsync(string id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
            var updateResult = await _collection.ReplaceOneAsync(filter, entity);

            if (updateResult.IsAcknowledged && updateResult.ModifiedCount > 0)
            {
                return entity;
            }

            return null;
        }
        public async Task DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.DeleteOneAsync(filter);
        }
        public async Task<T> GetByIdAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<T> GetByPlateAsync(string plate)
        {
            var filter = Builders<T>.Filter.Eq("Plate", plate);

            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
    }
}
