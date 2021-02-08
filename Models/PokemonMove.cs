
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeLexApi.Models
{
    public class PokemonMove
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string InternalId { get; set; }
        public string Id { get; set; }
        public int? Accuracy { get; set; } = 0;
        public string Category { get; set; }
        public string Cname { get; set; }
        public string Ename { get; set; }
        public string Jname { get; set; }
        public int? Power { get; set; } = 0;
        public int? Pp { get; set; } = 0;
        public string Type { get; set; }
    }
}