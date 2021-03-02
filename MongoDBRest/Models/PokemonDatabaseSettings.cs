using MongoDBRest.Interfaces;

namespace MongoDBRest.Models
{
    public class PokemonDatabaseSettings : IPokemonDatabaseSettings
    {
        public string SpeciesCollectionName { get; set; }
        public string MovesCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}