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
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly SegurosContext _db = null;


        public ClientesController(ILogger<ClientesController> logger, SegurosContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get(string tipoIdentificacion, string identificacion){

            var cliente = await _db.Clientes.FirstOrDefaultAsync(x => x.CodTipoIdentificacion == tipoIdentificacion && x.Identificacion == identificacion);

            return new JsonResult(cliente);            

        }
    }
}
