using Microsoft.AspNetCore.Mvc;
using Recetas.Application;
using Recetas.Application.DTOs;

namespace Recetas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecetasController : ControllerBase
    {
        private readonly RecetaService _recetaService;

        public RecetasController(RecetaService recetaService)
        {
            _recetaService = recetaService;
        }

        // GET: api/recetas
        // Permite buscar por nombre, filtrar por ingrediente y paginar
        [HttpGet]
        public IActionResult ObtenerTodas(
            string? buscar,
            string? ingrediente,
            int pagina = 1,
            int tamanioPagina = 10)
        {
            var recetas = _recetaService.Buscar(
                buscar,
                ingrediente,
                pagina,
                tamanioPagina);

            return Ok(recetas);
        }

        // GET: api/recetas/1
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var receta = _recetaService.ObtenerPorId(id);

            if (receta == null)
            {
                return NotFound(new { mensaje = "Receta no encontrada." });
            }

            return Ok(receta);
        }

        // POST: api/recetas
        [HttpPost]
        public IActionResult Agregar(CrearRecetaDto dto)
        {
            if (_recetaService.ExisteNombre(dto.Nombre))
            {
                return Conflict(new
                {
                    mensaje = "Ya existe una receta con ese nombre."
                });
            }

            var receta = _recetaService.Agregar(dto);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = receta.Id },
                receta);
        }

        // PUT: api/recetas/1
        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, ActualizarRecetaDto dto)
        {
            var recetaExistente = _recetaService.ObtenerPorId(id);

            if (recetaExistente == null)
            {
                return NotFound(new { mensaje = "Receta no encontrada." });
            }

            if (_recetaService.ExisteNombre(dto.Nombre, id))
            {
                return Conflict(new
                {
                    mensaje = "Ya existe otra receta con ese nombre."
                });
            }

            _recetaService.Actualizar(id, dto);

            return NoContent();
        }

        // DELETE: api/recetas/1
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var eliminada = _recetaService.Eliminar(id);

            if (!eliminada)
            {
                return NotFound(new { mensaje = "Receta no encontrada." });
            }

            return NoContent();
        }
    }
}