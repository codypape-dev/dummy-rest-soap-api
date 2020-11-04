using DummyWebService.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DummyWebService.DataAccess
{
    public class DummiesDA
    {
        readonly IMongoDatabase db = new DbConnection().GetDatabase();
        internal List<Dummy> GetDummies()
        {
            return db.GetCollection<Dummy>("dummies").AsQueryable().ToList();
        }

        internal Dummy GetDummyById(string id)
        {
            
            var filter = Builders<Dummy>.Filter.Eq("_id", id);
            return db.GetCollection<Dummy>("dummies").Find(filter).FirstOrDefault();
        }

        internal Dummy Create(Dummy dummy)
        {   
            db.GetCollection<Dummy>("dummies").InsertOne(dummy);

            return dummy;
        }

        internal Dummy UpdateById(Dummy value)
        {
            var filter = Builders<Model.Dummy>.Filter.Eq("_id", value.Id);
            var original = db.GetCollection<Dummy>("dummies").Find(filter).FirstOrDefault();
            if (original != null)
            {
                var options = new FindOneAndReplaceOptions<Model.Dummy, Model.Dummy> { ReturnDocument = ReturnDocument.After };

                original = db.GetCollection<Dummy>("dummies").FindOneAndReplace(filter, value, options);
            }
            return original;
        }

        internal bool DeleteDummyById(string id)
        {
            var filter = Builders<Dummy>.Filter.Eq("_id", id);

            var result = db.GetCollection<Dummy>("dummies").DeleteOne(filter);

            return result.IsAcknowledged;
        }
    }
}
