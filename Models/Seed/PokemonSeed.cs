using System;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

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