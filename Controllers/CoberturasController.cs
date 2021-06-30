using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using waSeguros.Models;

namespace waSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoberturasController : ControllerBase
    {
        private readonly ILogger<CoberturasController> _logger;
        private readonly SegurosContext _db = null;


        public CoberturasController(ILogger<CoberturasController> logger, SegurosContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("[action]")]
        public IActionResult Get(){

            var coberturas = _db.CatCoberturas;

            return new JsonResult(coberturas);            

        }
    }
}
