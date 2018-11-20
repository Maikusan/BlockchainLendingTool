using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace LendingToolMVC.Models
{
    [BsonDiscriminator("Metric")]
    public class User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public ObjectId Id { get; set; }

        [BsonElement("Vorname")]
        public string Vorname { get; set; }

        [BsonElement("Nachname")]
        public string Nachname { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("ETCKonto")]
        public string ETCKonto { get; set; }
    }
}