

using System.Collections.Generic;
using System.Threading.Tasks;

using PokeLexApi.Models;

namespace PokeLexApi.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> GetPokemonImage(string id);

        Task AddPokemonImage(Image item);

        Task AddPokemonImages(List<Image> list);
    }
}
