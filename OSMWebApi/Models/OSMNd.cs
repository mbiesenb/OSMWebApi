using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMWebApi.Models
{
    public class OSMNd
    {
        [BsonElement("lon")]
        public float lon;

        [BsonElement("lat")]
        public float lat;
    }
}
