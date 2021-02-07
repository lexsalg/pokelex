using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

using MongoDB.Bson;
using MongoDB.Driver;

using MongoDB.Driver.Linq;
using PokeLexApi.Interfaces;
using PokeLexApi.Models;

namespace PokeLexApi.Data
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonContext _context = null;

        public PokemonRepository(IOptions<Settings> settings)
        {
            _context = new PokemonContext(settings);
        }

        public async Task<IEnumerable<Pokemon>> GetAllPokemons()
        {
            try
            {
                return await _context.Pokemons.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Pokemon>> GetPokemons(int pageSize, int pageNum)
        {
            try
            {
                var skips = pageSize * (pageNum - 1);
                var query = _context.Pokemons.Find(_ => true).SortBy(p => p.InternalId).Skip(skips).Limit(pageSize);
                var items = await query.ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<IEnumerable<Pokemon>> SearchPokemon(string name, int pageSize, int pageNum)
        {
            try
            {
                var skips = pageSize * (pageNum - 1);
                var query = _context.Pokemons.Find(x => x.Name.English.Contains(name)).SortBy(p => p.InternalId).Skip(skips).Limit(pageSize);
                var items = await query.ToListAsync();
                return items;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<Pokemon> GetPokemon(string id)
        {
            try
            {
                ObjectId internalId = GetInternalId(id);
                return await _context.Pokemons
                                // .Find(Pokemon => Pokemon.Id == id || Pokemon.InternalId == internalId)
                                .Find(Pokemon => Pokemon.Id == id)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
        private ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task AddPokemon(Pokemon item)
        {
            try
            {
                await _context.Pokemons.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddPokemons(List<Pokemon> list)
        {
            try
            {
                await _context.Pokemons.InsertManyAsync(list);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemovePokemon(string id)
        {
            try
            {
                DeleteResult actionResult = await _context.Pokemons.DeleteOneAsync(
                     Builders<Pokemon>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAllPokemons()
        {
            try
            {
                DeleteResult actionResult = await _context.Pokemons.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
