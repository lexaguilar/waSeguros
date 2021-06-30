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
    public class CatalogosController : ControllerBase
    {
        private readonly ILogger<CatalogosController> _logger;
        private readonly SegurosContext _db = null;


        public CatalogosController(ILogger<CatalogosController> logger, SegurosContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("[action]")]
        public IActionResult Departamentos(int codPais){

            var coberturas = _db.CatDepartamentos.Where(x => x.CodPais == codPais);

            return new JsonResult(coberturas);            

        }

        [HttpGet("[action]")]
        public IActionResult Municipios(int codDepartamento){

            var coberturas = _db.CatMunicipios.Where(x => x.CodDepartamento == codDepartamento);

            return new JsonResult(coberturas);            

        }
    }
}
