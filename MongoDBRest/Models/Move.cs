using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBRest.Models
{
    public class Move
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public string Name { get; set; }

        public int Attack { get; set; }
        
        public int Accuracy { get; set; }
    }
}