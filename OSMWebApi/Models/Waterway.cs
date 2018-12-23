using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMWebApi.Models
{
    public class Waterway
    {

        [BsonElement("_id")]
        public ObjectId documentId { get; set; }

        [BsonElement("id")]
        public string osmid { get; set; }


        [BsonElement("osm_type")]
        public string osmtype { get; set; } 
     

        [BsonElement("nds")]
        public List<OSMNd> osmnds { get; set; }
        //public OSMNd[] osmnds { get; set; }


        [BsonElement("tags")]
        public List<OSMTag> osmtags { get; set; }
        //public OSMTag[] osmtags { get; set; }



    }
}
