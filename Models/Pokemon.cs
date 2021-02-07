using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeLexApi.Models
{
    public class Pokemon
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        public string Id { get; set; }

        // [BsonElement("Language")]
        public Language Name { get; set; }

        public ICollection<string> Type { get; set; }

        public PokemonBase Base { get; set; }
    }
}