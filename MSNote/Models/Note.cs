using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MSNote.Model
{
    public class Note
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)] 
        //public string? Id { get; set; }
        //[BsonElement("PatId")]
        //public int? PatId { get; set; } = null!;
        //public string Patient { get; set; }
        //public string? Notes { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("PatId")]
        public int? PatId { get; set; }
        public string Patient { get; set; }
        public string Notes { get; set; }
    }
}
