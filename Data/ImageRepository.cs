using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

using MongoDB.Driver;

using PokeLexApi.Interfaces;
using PokeLexApi.Models;
using MongoDB.Bson;

namespace PokeLexApi.Data
{
    public class ImageRepository : IImageRepository
    {
        private readonly PokemonContext _context = null;

        public ImageRepository(IOptions<Settings> settings)
        {
            _context = new PokemonContext(settings);
        }

        public async Task<Image> GetPokemonImage(string id)
        {
            try
            {
                return await _context.PokemonImages.Find(image => image.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddPokemonImage(Image item)
        {
            try
            {
                await _context.PokemonImages.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task AddPokemonImages(List<Image> list)
        {
            try
            {
                await _context.PokemonImages.InsertManyAsync(list);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}