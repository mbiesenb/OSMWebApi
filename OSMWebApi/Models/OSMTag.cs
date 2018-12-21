using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMWebApi.Models
{
    public class OSMTag
    {
        [BsonElement("k")]
        public string key;

        [BsonElement("v")]
        public string value;
    }
}
