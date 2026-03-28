using PortalCampanas.Models;

namespace PortalCampanas.Services
{
    public class CampanaService
    {
        private static List<Campana> _campanas = new List<Campana>
        {
            new Campana { Id = 1, Nombre = "Black Friday Electro", Categoria = "Electro", Estado = "Vigente", FechaInicio = new DateTime(2026,3,1), FechaFin = new DateTime(2026,4,30), DescuentoPct = 25, Canal = "Web", Descripcion = "Descuentos en televisores y laptops." },
            new Campana { Id = 2, Nombre = "Verano Hogar", Categoria = "Hogar", Estado = "Finalizada", FechaInicio = new DateTime(2026,1,1), FechaFin = new DateTime(2026,2,28), DescuentoPct = 15, Canal = "Tienda", Descripcion = "Liquidación de muebles y decoración." },
            new Campana { Id = 3, Nombre = "Moda Primavera", Categoria = "Moda", Estado = "Próxima", FechaInicio = new DateTime(2026,5,1), FechaFin = new DateTime(2026,6,30), DescuentoPct = 20, Canal = "App", Descripcion = "Nueva colección primavera-verano." },
            new Campana { Id = 4, Nombre = "Tech Week", Categoria = "Tecnología", Estado = "Vigente", FechaInicio = new DateTime(2026,3,15), FechaFin = new DateTime(2026,4,15), DescuentoPct = 30, Canal = "Web", Descripcion = "Ofertas en celulares y accesorios." },
            new Campana { Id = 5, Nombre = "Hogar Inteligente", Categoria = "Hogar", Estado = "Próxima", FechaInicio = new DateTime(2026,4,1), FechaFin = new DateTime(2026,5,31), DescuentoPct = 10, Canal = "App", Descripcion = "Domótica y electrodomésticos smart." },
        };

        public List<Campana> ObtenerTodas() => _campanas;

        public Campana ObtenerPorId(int id) => _campanas.FirstOrDefault(c => c.Id == id);

        public List<Campana> Filtrar(string categoria, string estado)
        {
            var resultado = _campanas.AsQueryable();
            if (!string.IsNullOrEmpty(categoria))
                resultado = resultado.Where(c => c.Categoria == categoria);
            if (!string.IsNullOrEmpty(estado))
                resultado = resultado.Where(c => c.Estado == estado);
            return resultado.ToList();
        }
    }
}