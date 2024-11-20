using MongoDB.Driver;

namespace Parking.Adapters.Driven.MongoDB.Contexts
{
    public class MongoDBContext
    {
        public IMongoDatabase Database { get; }

        public MongoDBContext(IMongoClient client, string databaseName)
        {
            Database = client.GetDatabase(databaseName);
        }
    }
}
