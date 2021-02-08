
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeLexApi.Interfaces;
using PokeLexApi.Models;

namespace PokeLexApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepository _pokemonRepository;

        private readonly ILogger<PokemonController> _logger;

        public PokemonController(ILogger<PokemonController> logger, IPokemonRepository pokemonRepository)
        {
            _logger = logger;
            _pokemonRepository = pokemonRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pokemon>> GetAll()
        {
            return await _pokemonRepository.GetAllPokemons();
        }

        [HttpGet("filter")]
        public async Task<IEnumerable<Pokemon>> Filter([FromQuery] int psize, [FromQuery] int pnum)
        {
            return await _pokemonRepository.GetPokemons(psize, pnum);
        }

        [HttpGet("search")]
        public async Task<IEnumerable<Pokemon>> Search([FromQuery] string name, [FromQuery] int psize, [FromQuery] int pnum)
        {
            return await _pokemonRepository.SearchPokemon(name, psize, pnum);
        }

        [HttpGet("{id}")]
        public async Task<Pokemon> Get(string id)
        {
            return await _pokemonRepository.GetPokemon(id);
        }
    }
}
