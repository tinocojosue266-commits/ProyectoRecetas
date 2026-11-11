using Recetas.Application.DTOs;
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

        public List<RecetaRespuestaDto> ObtenerTodas()
        {
            var recetas = _recetaRepository.ObtenerTodas();

            return recetas.Select(r => new RecetaRespuestaDto
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Ingredientes = r.Ingredientes,
                Instrucciones = r.Instrucciones
            }).ToList();
        }

        public List<RecetaRespuestaDto> Buscar(
            string? buscar,
            string? ingrediente,
            int pagina = 1,
            int tamanioPagina = 10)
        {
            var recetas = _recetaRepository.ObtenerTodas().AsQueryable();

            // Buscar por nombre
            if (!string.IsNullOrWhiteSpace(buscar))
            {
                recetas = recetas.Where(r =>
                    r.Nombre.Contains(buscar, StringComparison.OrdinalIgnoreCase));
            }

            // Filtrar por ingrediente
            if (!string.IsNullOrWhiteSpace(ingrediente))
            {
                recetas = recetas.Where(r =>
                    r.Ingredientes.Contains(
                        ingrediente,
                        StringComparison.OrdinalIgnoreCase));
            }

            // Evitar valores incorrectos
            if (pagina < 1)
            {
                pagina = 1;
            }

            if (tamanioPagina < 1)
            {
                tamanioPagina = 10;
            }

            // Aplicar paginación
            recetas = recetas
                .Skip((pagina - 1) * tamanioPagina)
                .Take(tamanioPagina);

            return recetas.Select(r => new RecetaRespuestaDto
            {
                Id = r.Id,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Ingredientes = r.Ingredientes,
                Instrucciones = r.Instrucciones
            }).ToList();
        }

        public RecetaRespuestaDto? ObtenerPorId(int id)
        {
            var receta = _recetaRepository.ObtenerPorId(id);

            if (receta == null)
            {
                return null;
            }

            return new RecetaRespuestaDto
            {
                Id = receta.Id,
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                Ingredientes = receta.Ingredientes,
                Instrucciones = receta.Instrucciones
            };
        }

        public bool ExisteNombre(string nombre, int? idExcluir = null)
        {
            var recetas = _recetaRepository.ObtenerTodas();

            return recetas.Any(r =>
                r.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                (!idExcluir.HasValue || r.Id != idExcluir.Value));
        }

        public RecetaRespuestaDto Agregar(CrearRecetaDto dto)
        {
            var receta = new Receta
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Ingredientes = dto.Ingredientes,
                Instrucciones = dto.Instrucciones
            };

            _recetaRepository.Agregar(receta);

            return new RecetaRespuestaDto
            {
                Id = receta.Id,
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                Ingredientes = receta.Ingredientes,
                Instrucciones = receta.Instrucciones
            };
        }

        public RecetaRespuestaDto? Actualizar(int id, ActualizarRecetaDto dto)
        {
            var receta = _recetaRepository.ObtenerPorId(id);

            if (receta == null)
            {
                return null;
            }

            receta.Nombre = dto.Nombre;
            receta.Descripcion = dto.Descripcion;
            receta.Ingredientes = dto.Ingredientes;
            receta.Instrucciones = dto.Instrucciones;

            _recetaRepository.Actualizar(receta);

            return new RecetaRespuestaDto
            {
                Id = receta.Id,
                Nombre = receta.Nombre,
                Descripcion = receta.Descripcion,
                Ingredientes = receta.Ingredientes,
                Instrucciones = receta.Instrucciones
            };
        }

        public bool Eliminar(int id)
        {
            var receta = _recetaRepository.ObtenerPorId(id);

            if (receta == null)
            {
                return false;
            }

            _recetaRepository.Eliminar(id);
            return true;
        }
    }
}