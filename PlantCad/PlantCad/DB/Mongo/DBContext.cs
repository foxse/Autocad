using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace PlantCad.DB.Mongo
{
    public class MongoDBContext
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoDBContext(string connection, string db)
        {
            _client = new MongoClient(connection);
            _database = _client.GetDatabase(db);
        }

        public bool Exist(string Name)
        {
            var collection = _database.GetCollection<BsonDocument>("Elements");
            var aggregate = collection.Aggregate()
                .Match(new BsonDocument { { "name", Name } });
            var results =  aggregate.ToString();
            if (results != null)
                return false;
            return true;
        }
    }
}
