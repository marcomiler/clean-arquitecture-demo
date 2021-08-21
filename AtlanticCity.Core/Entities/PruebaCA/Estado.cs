using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Entities.PruebaCA
{
    public class Estado
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonElement("members")]
        //public IEnumerable<User> Members { get; set; } = new List<User>();

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("Empresa")]
        public string Empresa { get; set; }
    }
}
