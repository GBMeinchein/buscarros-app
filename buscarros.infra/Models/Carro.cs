using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace buscarros.infra.Models
{
    public class Carro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("href")]
        public string Href { get; set; }

        [BsonElement("adress")]
        public string Adress { get; set; }

        [BsonElement("image")]
        public string Image { get; set; }

        [BsonElement("site")]
        public string Site { get; set; }

        [BsonElement("brand")]
        public string Brand { get; set; }
    }
}
