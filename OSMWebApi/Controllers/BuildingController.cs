using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OSMWebApi.Models;
using OSMWebApi.Services;

namespace OSMWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly OSMService _service;
        public BuildingController(OSMService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<Building>> Get()
        {
            return _service.GetBuildings();
        }

        [HttpGet]
        [Route("bounds")]
        public ActionResult<List<Building>> Get([FromQuery]float minLat, [FromQuery]float minLon , [FromQuery]float maxLat, [FromQuery]float maxLon)
        {
            //https://localhost:44308/api/osmway/bounds?minLat=50.9393463&minLon=6.97327328&maxLat=50.9393500&maxLon=6.97327400
            if (maxLon < minLon ) return StatusCode(412, "Bound is not correct ( maxLat < minLat )");
            if (maxLat < minLat) return StatusCode(412, "Bound is not correct ( maxLon < minLon )");
            return _service.GetBuildingsByBound(minLat, minLon, maxLat, maxLon);
        }

    }
}