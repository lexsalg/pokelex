using System.Collections.Generic;

namespace PokeLexApi.Models.Seed
{
    public class PokemonSeed
    {

        public string Id { get; set; }

        public Language Name { get; set; }

        public ICollection<string> Type { get; set; }

        public PokemonBaseSeed Base { get; set; }
    }
}