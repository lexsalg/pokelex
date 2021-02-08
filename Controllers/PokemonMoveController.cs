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
    public class PokemonMoveController : ControllerBase
    {
        private readonly IPokemonMoveRepository _pokemonMoveRepository;

        private readonly ILogger<PokemonController> _logger;

        public PokemonMoveController(ILogger<PokemonController> logger, IPokemonMoveRepository pokemonMoveRepository)
        {
            _logger = logger;
            _pokemonMoveRepository = pokemonMoveRepository;
        }

        [HttpGet("{id}")]
        public async Task<PokemonMove> Get(string id)
        {
            return await _pokemonMoveRepository.GetPokemonMove(id);
        }
    }
}
