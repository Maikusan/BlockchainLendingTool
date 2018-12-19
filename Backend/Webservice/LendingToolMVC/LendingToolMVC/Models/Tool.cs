using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using Nethereum.ENS;

namespace LendingToolMVC.Models
{
    [BsonDiscriminator("Tool")]
    public class Tool
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("Owner")]
        public User Owner { get; set; }

        [BsonElement("LendingPrice")]
        public int LendingPrice { get; set; }

        [BsonElement("DepoPrice")]
        public int DepoPrice { get; set; }

        [BsonElement("Availible")]
        public bool Availible { get; set; }

        [BsonElement("Name")]
        public string Name { get; set;  }

        [BsonElement("Descriptipon")]
        public string Descriptipon { get; set; }
    }
}