using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBRest.Dto
{
    public class SpeciesDto
    {
        public string Name { get; set; }
        
        public double CatchRate { get; set; }
    }
}