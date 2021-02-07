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
    public class PokemonMoveRepository : IPokemonMoveRepository
    {
        private readonly PokemonContext _context = null;

        public PokemonMoveRepository(IOptions<Settings> settings)
        {
            _context = new PokemonContext(settings);
        }

        public async Task<IEnumerable<PokemonMove>> GetAllPokemonMoves()
        {
            try
            {
                return await _context.PokemonMoves.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PokemonMove> GetPokemonMove(string id)
        {
            try
            {
                return await _context.PokemonMoves
                .Find(move => move.Id == id)
                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddPokemonMoves(List<PokemonMove> list)
        {
            try
            {
                await _context.PokemonMoves.InsertManyAsync(list);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

    }
}
