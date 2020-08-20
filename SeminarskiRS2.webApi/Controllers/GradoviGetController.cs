﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeminarskiRS2.Model.Requests;
using SeminarskiRS2.webApi.Services;

namespace SeminarskiRS2.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoviGetController : ControllerBase
    {
        private readonly GradoviService _service;

        public GradoviGetController(GradoviService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Model.Grad>> Get([FromQuery] GradoviSearchRequest req)
        {
            return _service.Get(req);
        }
        [HttpPost]
        public Model.Grad Insert(GradoviInsertRequest request)
        {
            return _service.Insert(request);
        }
    }
}
