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
    public class PolizasController : ControllerBase
    {
        private readonly ILogger<PolizasController> _logger;
        private readonly SegurosContext _db = null;


        public PolizasController(ILogger<PolizasController> logger, SegurosContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] Poliza poliza){

            poliza.init(_db);
            _db.Polizas.Add(poliza);
            await _db.SaveChangesAsync();

            return new JsonResult(poliza);            

        }
    }
}
