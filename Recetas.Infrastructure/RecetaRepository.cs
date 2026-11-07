using Microsoft.EntityFrameworkCore;
using Recetas.Domain;

namespace Recetas.Infrastructure
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasDbContext _context;

        public RecetaRepository(RecetasDbContext context)
        {
            _context = context;
        }

        public List<Receta> ObtenerTodas()
        {
            return _context.Recetas.ToList();
        }

        public Receta? ObtenerPorId(int id)
        {
            return _context.Recetas.FirstOrDefault(r => r.Id == id);
        }

        public void Agregar(Receta receta)
        {
            _context.Recetas.Add(receta);
            _context.SaveChanges();
        }

        public void Actualizar(Receta receta)
        {
            _context.Recetas.Update(receta);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var receta = ObtenerPorId(id);

            if (receta != null)
            {
                _context.Recetas.Remove(receta);
                _context.SaveChanges();
            }
        }
    }
}