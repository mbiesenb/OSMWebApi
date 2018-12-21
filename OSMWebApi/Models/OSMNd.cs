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
        public double lon;

        [BsonElement("lat")]
        public double lat;
    }
}
