using Microsoft.Extensions.Options;
using MongoDB.Driver;

using PokeLexApi.Models;

namespace PokeLexApi.Data
{
    public class PokemonContext
    {
        private readonly IMongoDatabase _database = null;

        public PokemonContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Pokemon> Pokemons
        {
            get
            {
                return _database.GetCollection<Pokemon>("Pokemons");
            }
        }

        public IMongoCollection<PokemonMove> PokemonMoves
        {
            get
            {
                return _database.GetCollection<PokemonMove>("PokemonMoves");
            }
        }

        public IMongoCollection<PokemonType> PokemonTypes
        {
            get
            {
                return _database.GetCollection<PokemonType>("PokemonTypes");
            }
        }

        public IMongoCollection<Image> PokemonImages
        {
            get
            {
                return _database.GetCollection<Image>("PokemonImages");
            }
        }

    }
}
