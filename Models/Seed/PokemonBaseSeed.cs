
using Newtonsoft.Json;

namespace PokeLexApi.Models
{
    public class PokemonBaseSeed
    {

        [JsonProperty(PropertyName ="HP")]
        public int? Hp { get; set; } = 0;

        [JsonProperty(PropertyName ="Attack")]
        public int? Attack { get; set; } = 0;
        public int? Defense { get; set; } = 0;

        [JsonProperty(PropertyName ="Sp. Attack")]
        public int? SpAttack { get; set; } = 0;

        [JsonProperty(PropertyName ="Sp. Defense")]
        public int? SpDefense { get; set; } = 0;
        public int? Speed { get; set; } = 0;

    }
}