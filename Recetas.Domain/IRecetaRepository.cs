using System.Collections.Generic;

namespace Recetas.Domain
{
    public interface IRecetaRepository
    {
        List<Receta> ObtenerTodas();

        Receta? ObtenerPorId(int id);

        void Agregar(Receta receta);

        void Actualizar(Receta receta);

        void Eliminar(int id);
    }
}