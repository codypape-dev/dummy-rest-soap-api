using System;
using DummyWebService.Model;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace DummyWebService.DataAccess
{
    public class DbConnection
    {
        static readonly string connString = AppVariables.DBConnection;
        static readonly string dbName = AppVariables.DatabaseName;
        readonly MongoClient client = new MongoClient(connString);

        public DbConnection()
        {
        }

        public MongoClient Client => client;

        public IMongoDatabase GetDatabase()
        {
            return Client.GetDatabase(dbName);
        }

        
    }
}
