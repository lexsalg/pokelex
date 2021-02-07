using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PokeLexApi.Models;

namespace PokeLexApi.Interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetAllPokemons();

        Task<Pokemon> GetPokemon(string id);

        Task AddPokemon(Pokemon item);
        Task AddPokemons(List<Pokemon> list);

        Task<bool> RemovePokemon(string id);


        // Task<bool> UpdatePokemon(string id, Pokemon pokemon);

        Task<bool> RemoveAllPokemons();


    }
}
