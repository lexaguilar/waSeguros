using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using waSeguros.Models;

namespace waSeguros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SegurosContext _db = null;


        public HomeController(ILogger<HomeController> logger, SegurosContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.TipoIdentificacions = _db.CatTipoIdentificacions.Select(x => new SelectListItem{
                Value = x.CodTipoIdentificacion,
                Text = x.Descripcion
            });

            ViewBag.Paises = _db.CatPais.Select(x => new SelectListItem{
                Value = x.CodPais.ToString(),
                Text = x.Xpais
            });

            var SelectListItems = new List<SelectListItem>();
            SelectListItems.Add(new SelectListItem{
                Value = "",
                Text = "--Seleccione--"
            });

            ViewBag.Ramos = SelectListItems.ToArray().Concat(_db.CatRamos.Select(x => new SelectListItem{
                Value = x.CodRamo.ToString(),
                Text = x.Xramo
            }).ToArray());

            ViewBag.Monedas = _db.CatMoneda.Select(x => new SelectListItem{
                Value = x.CodMoneda.ToString(),
                Text = x.Descripcion
            });           

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
