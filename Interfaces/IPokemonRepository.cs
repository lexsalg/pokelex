using System.Collections.Generic;
using System.Threading.Tasks;

using PokeLexApi.Models;

namespace PokeLexApi.Interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllPokemons();

        Task<IEnumerable<Pokemon>> GetPokemons(int pageSize, int pageNum);
        Task<IEnumerable<Pokemon>> SearchPokemon(string name, int pageSize, int pageNum);
        Task<Pokemon> GetPokemon(string id);

        Task AddPokemon(Pokemon item);
        Task AddPokemons(List<Pokemon> list);

        Task<bool> RemovePokemon(string id);

        Task<bool> RemoveAllPokemons();


    }
}
