
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PokeLexApi.Models
{
    public class Image
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Id { get; set; }
        public byte[] ContentImage { get; set; }

    }
}