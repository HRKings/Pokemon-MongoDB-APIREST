using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBRest.Interfaces;
using MongoDBRest.Models;

namespace MongoDBRest.Services
{
    public class SpeciesService
    {
        private readonly IMongoCollection<Species> _species;

        public SpeciesService(IPokemonDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _species = database.GetCollection<Species>(settings.SpeciesCollectionName);
        }

        public async Task<List<Species>> Get() =>
            await _species.Find(Builders<Species>.Filter.Empty).ToListAsync();

        public async Task<Species> Get(string id) =>
            await _species.Find(species => species.ID == id).FirstOrDefaultAsync();

        public async Task<List<Species>> Search(string query) =>
            await _species.Find(Builders<Species>.Filter.Text(query)).ToListAsync();

        public async Task<Species> Create(Species species)
        {
            await _species.InsertOneAsync(species).ConfigureAwait(false);
            return species;
        }

        public async Task Update(string id, Species species) =>
            await  _species.ReplaceOneAsync(toReplace => toReplace.ID == id, species);

        public async Task Remove(string id) =>
            await _species.DeleteOneAsync(toReplace => toReplace.ID == id);
    }
}