using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBRest.Models
{
    public class Species
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Name { get; set; }
        
        public double CatchRate { get; set; }
    }
}