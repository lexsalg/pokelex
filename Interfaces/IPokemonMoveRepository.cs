using System.Collections.Generic;
using System.Threading.Tasks;

using PokeLexApi.Models;

namespace PokeLexApi.Interfaces
{
    public interface IPokemonMoveRepository
    {
        Task<IEnumerable<PokemonMove>> GetAllPokemonMoves();
        Task<PokemonMove> GetPokemonMove(string id);
        Task AddPokemonMoves(List<PokemonMove> list);

        Task<bool> RemoveAll();
    }
}
