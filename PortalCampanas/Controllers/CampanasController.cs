using Microsoft.AspNetCore.Mvc;
using PortalCampanas.Services;

namespace PortalCampanas.Controllers
{
    public class CampanasController : Controller
    {
        private readonly CampanaService _service;

        public CampanasController(CampanaService service)
        {
            _service = service;
        }

        public IActionResult Index(string categoria, string estado)
        {
            var campanas = _service.Filtrar(categoria, estado);

            ViewBag.Categorias = new List<string> { "Electro", "Hogar", "Moda", "Tecnología" };
            ViewBag.Estados = new List<string> { "Vigente", "Próxima", "Finalizada" };
            ViewBag.CategoriaSeleccionada = categoria;
            ViewBag.EstadoSeleccionado = estado;

            return View(campanas);
        }

        public IActionResult Detalle(int id)
        {
            var campana = _service.ObtenerPorId(id);
            if (campana == null) return NotFound();
            return View(campana);
        }

        // ACCIÓN NUEVA - Resumen
        public IActionResult Resumen()
        {
            var todas = _service.ObtenerTodas();

            ViewBag.Total = todas.Count;
            ViewBag.Vigentes = todas.Count(c => c.Estado == "Vigente");
            ViewBag.Proximas = todas.Count(c => c.Estado == "Próxima");
            ViewBag.Finalizadas = todas.Count(c => c.Estado == "Finalizada");
            ViewBag.PromedioDescuento = todas.Average(c => c.DescuentoPct).ToString("F1");
            ViewBag.PorCanal = todas.GroupBy(c => c.Canal)
                                    .Select(g => new { Canal = g.Key, Cantidad = g.Count() })
                                    .ToList();

            return View();
        }
    }
}