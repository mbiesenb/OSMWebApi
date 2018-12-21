using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using OSMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSMWebApi.Services
{
    public class OSMWayService
    {
        private readonly IMongoCollection <OMSWay> _ways;

        public OSMWayService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("WaystoreDb"));
            var database = client.GetDatabase("WaystoreDb");

            _ways = database.GetCollection<OMSWay>("Data");

        }
        public List<OMSWay> Get()
        {
            return _ways.Find(osmway => true).ToList();
        }
        public OMSWay Get(string id)
        {
            var docId = new ObjectId(id);
            return _ways.Find<OMSWay>(osmway => osmway.Id == docId).FirstOrDefault();
        }

    }
}
