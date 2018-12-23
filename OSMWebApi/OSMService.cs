using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using OSMWebApi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OSMWebApi.Services
{
    public class OSMService
    {
        private readonly IMongoCollection <Building> _buildings;
        private readonly IMongoCollection <Highway> _highways;
        private readonly IMongoCollection <Landuse> _landuses;
        private readonly IMongoCollection <Waterway> _waterways;

        public OSMService(IConfiguration config)
        {
            string conStr = "mongodb://localhost:27017";
            var client = new MongoClient(conStr);
            var database = client.GetDatabase("OSM");

            _buildings = database.GetCollection<Building>("building");
            _highways = database.GetCollection<Highway>("highway");
            _landuses = database.GetCollection<Landuse>("landuse");
            _waterways = database.GetCollection<Waterway>("waterway");

        }

        public List<Building> GetBuildings()
        {
            return _buildings.Find(osmway => true).ToList();
        }

        public Building GetBuildingById(string id)
        {
            var docId = new ObjectId(id);
            return _buildings.Find<Building>(osmway => osmway.documentId == docId).FirstOrDefault();
        }

        /// <summary>
        /// This method select all the ways elements which has at minimum one coordinate inside the rectangle
        /// </summary>
        /// <param name="minLat">Minimal Longitude (DE: Breitengrad)</param>
        /// <param name="minLon">Minimal Latitiude (DE: Längengrad)</param>
        /// <param name="maxLat">Maximal Longitude (DE: Breitengrad)</param>
        /// <param name="maxLon">Maximal Latitiude (DE: Längengrad)</param>
        /// <returns></returns>
        public List<Building> GetBuildingsByBound(float minLat, float minLon, float maxLat, float maxLon)
        {
            //Längengrad = y = Longitude
            //Breitengrad = x = Latitude
            RectangleF area = new RectangleF(minLat , minLon, maxLat - minLat , maxLon - minLon);
            List<Building> osmways = _buildings.Find(osmway => true).ToList();
            return osmways.FindAll(w => w.osmnds.Exists(n => (area.Contains(n.lat, n.lon)))).ToList();
        }

        public List<Highway> GetHighways()
        {
            return _highways.Find(osmway => true).ToList();
        }

        public Highway GetHighwayById(string id)
        {
            var docId = new ObjectId(id);
            return _highways.Find<Highway>(osmway => osmway.documentId == docId).FirstOrDefault();
        }

        /// <summary>
        /// This method select all the ways elements which has at minimum one coordinate inside the rectangle
        /// </summary>
        /// <param name="minLat">Minimal Longitude (DE: Breitengrad)</param>
        /// <param name="minLon">Minimal Latitiude (DE: Längengrad)</param>
        /// <param name="maxLat">Maximal Longitude (DE: Breitengrad)</param>
        /// <param name="maxLon">Maximal Latitiude (DE: Längengrad)</param>
        /// <returns></returns>
        public List<Highway> GetHighwaysByBound(float minLat, float minLon, float maxLat, float maxLon)
        {
            //Längengrad = y = Longitude
            //Breitengrad = x = Latitude
            RectangleF area = new RectangleF(minLat, minLon, maxLat - minLat, maxLon - minLon);
            List<Highway> highways = _highways.Find(osmway => true).ToList();
            return highways.FindAll(w => w.osmnds.Exists(n => (area.Contains(n.lat, n.lon)))).ToList();
        }
    }
}
