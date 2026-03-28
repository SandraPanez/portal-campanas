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
    }
}