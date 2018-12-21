using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMWebApi.Models
{
    public class OMSWay
    {
        
        public ObjectId Id { get; set; }

        [BsonElement("nds")]
        public OSMNd[] osmnds { get; set; }

        [BsonElement("tags")]
        public OSMTag[] osmtags { get; set; }
    }
}
