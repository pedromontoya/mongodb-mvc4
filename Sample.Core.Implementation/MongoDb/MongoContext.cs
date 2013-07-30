using MongoDB.Bson;
using MongoDB.Driver;
using Sample.Core.Models;
using Sample.Core.MongoDb;
using System.Configuration;

namespace Sample.Core.Implementation.MongoDb
{
    /// <summary>
    /// Concrete implementation of a mongo context bound to the database named 'test'
    /// </summary>
    public class MongoContext : IMongoDbContext
    {
        private MongoServer _mongoServer;
        private MongoDatabase _mongoDatabase;
        private const string DATABASE_NAME = "test";

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoContext"/> class.
        /// </summary>
        public MongoContext()
        {
            //Get the MongoDB connection string/URI.
            var connectionString = ConfigurationManager.ConnectionStrings["mongoDbConnection"].ConnectionString;

            //Create a connection to the mongo server specified in the connection string.
            _mongoServer = MongoServer.Create(connectionString);

            //Gets the specified database instance on the connected server.
            _mongoDatabase = _mongoServer.GetDatabase(DATABASE_NAME);
        }

        /// <summary>
        /// Gets a MongoCollection for Note entries.
        /// </summary>
        public MongoCollection<Note> Notes
        {
            get
            {
                return _mongoDatabase.GetCollection<Note>("notes");
            }
        }

        /// <summary>
        /// Gets the mongo collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns></returns>
        public MongoCollection<T> GetMongoCollection<T>(string collectionName)
        {
            return _mongoDatabase.GetCollection<T>(collectionName);
        }

        public MongoCollection<BsonDocument> GetBsonMongoCollection(string collectionName)
        {
           return _mongoDatabase.GetCollection<BsonDocument>(collectionName);
        }
    }
}
