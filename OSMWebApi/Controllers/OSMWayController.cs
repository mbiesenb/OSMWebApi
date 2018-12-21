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
    public class OSMWayController : ControllerBase
    {
        private readonly OSMWayService _service;
        public OSMWayController(OSMWayService service)
        {
            this._service = service;
        }

        [HttpGet]
        public ActionResult<List<OMSWay>> Get()
        {
            return _service.Get();
        }

    }
}