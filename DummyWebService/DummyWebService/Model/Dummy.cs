using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace DummyWebService.Model
{
    [DataContract]
    public class Dummy
    {
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
