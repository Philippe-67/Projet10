using System;

namespace MSUi.Models
{
    public class Note
    {
       // [BsonId] 
        public Object Id { get; set; }
      //  [BsonElement("PatId")]
        public int? PatId { get; set; }
        public string Patient { get; set; }
        public string Notes { get; set; }
    }
}
