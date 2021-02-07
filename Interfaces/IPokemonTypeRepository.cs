using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PokeLexApi.Models;

namespace PokeLexApi.Interfaces
{
    public interface IPokemonTypeRepository
    {
        Task<IEnumerable<PokemonType>> GetAllPokemonTypes();

        Task AddPokemonTypes(List<PokemonType> list);

        Task<bool> RemoveAll();
    }
}
