using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PokeLexApi.Interfaces;
using PokeLexApi.Models;
using PokeLexApi.Models.Seed;

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

        [HttpGet("{id}")]
        public async Task<Pokemon> Get(string id)
        {
            return await _pokemonRepository.GetPokemon(id);
        }
    }
}
