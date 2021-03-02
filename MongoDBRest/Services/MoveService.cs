using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDBRest.Interfaces;
using MongoDBRest.Models;

namespace MongoDBRest.Services
{
    public class MoveService
    {
        private readonly IMongoCollection<Move> _moves;

        public MoveService(IPokemonDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _moves = database.GetCollection<Move>(settings.MovesCollectionName);
        }

        public async Task<List<Move>> Get() =>
            await _moves.Find(Builders<Move>.Filter.Empty).ToListAsync();

        public async Task<Move> Get(string id) =>
            await _moves.Find(move => move.ID == id).FirstOrDefaultAsync();

        public async Task<List<Move>> Search(string query) =>
           await _moves.Find(Builders<Move>.Filter.Text(query)).ToListAsync();

        public async Task<Move> Create(Move move)
        {
            await _moves.InsertOneAsync(move).ConfigureAwait(false);
            return move;
        }

        public async Task Update(string id, Move move) =>
            await  _moves.ReplaceOneAsync(toReplace => toReplace.ID == id, move);

        public async Task Remove(string id) =>
            await _moves.DeleteOneAsync(toReplace => toReplace.ID == id);
    }
}