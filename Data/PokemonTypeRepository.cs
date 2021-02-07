using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

using MongoDB.Driver;

using PokeLexApi.Interfaces;
using PokeLexApi.Models;

namespace PokeLexApi.Data
{
    public class PokemonTypeRepository : IPokemonTypeRepository
    {
        private readonly PokemonContext _context = null;

        public PokemonTypeRepository(IOptions<Settings> settings)
        {
            _context = new PokemonContext(settings);
        }

        public async Task<IEnumerable<PokemonType>> GetAllPokemonTypes()
        {
            try
            {
                return await _context.PokemonTypes.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddPokemonTypes(List<PokemonType> list)
        {
            try
            {
                await _context.PokemonTypes.InsertManyAsync(list);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }


    }
}