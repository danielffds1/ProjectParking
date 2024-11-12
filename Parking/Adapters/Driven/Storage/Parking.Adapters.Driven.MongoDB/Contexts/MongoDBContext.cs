using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.Adapters.Driven.MongoDB.Contexts
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IMongoClient client, string databaseName)
        {
            _database = client.GetDatabase(databaseName);
        }
    }
}
