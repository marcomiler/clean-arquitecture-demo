using AtlanticCity.Infraestructure.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace AtlanticCity.Infraestructure.Connections
{
    public class MongoDBContext : IMongoDBContext
    {
        private IMongoDatabase _db { get; set; }
        private MongoClient _mongoClient { get; set; }
        public MongoDBContext(IOptions<MongoOptions> configuration)
        {
            _mongoClient = new MongoClient(configuration.Value.ConnectionMongoDBServer);
            
        }

        public IMongoCollection<T> GetCollection<T>(string name, string databaseName)
        {
            _db = _mongoClient.GetDatabase(databaseName);
            return _db.GetCollection<T>(name);
        }
    }

    public interface IMongoDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name, string databaseName);
    }
}
