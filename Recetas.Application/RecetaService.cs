using Recetas.Domain;

namespace Recetas.Application
{
    public class RecetaService
    {
        private readonly IRecetaRepository _recetaRepository;

        public RecetaService(IRecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }

        public List<Receta> ObtenerTodas()
        {
            return _recetaRepository.ObtenerTodas();
        }

        public Receta? ObtenerPorId(int id)
        {
            return _recetaRepository.ObtenerPorId(id);
        }

        public void Agregar(Receta receta)
        {
            _recetaRepository.Agregar(receta);
        }

        public void Actualizar(Receta receta)
        {
            _recetaRepository.Actualizar(receta);
        }

        public void Eliminar(int id)
        {
            _recetaRepository.Eliminar(id);
        }
    }
}