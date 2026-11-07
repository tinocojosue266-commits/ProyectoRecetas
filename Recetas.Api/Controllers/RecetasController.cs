using Microsoft.AspNetCore.Mvc;
using Recetas.Application;
using Recetas.Domain;

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

        
        [HttpGet]
        public IActionResult ObtenerTodas()
        {
            var recetas = _recetaService.ObtenerTodas();
            return Ok(recetas);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var receta = _recetaService.ObtenerPorId(id);

            if (receta == null)
            {
                return NotFound();
            }

            return Ok(receta);
        }

     
        [HttpPost]
        public IActionResult Agregar(Receta receta)
        {
            _recetaService.Agregar(receta);
            return Ok(receta);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, Receta receta)
        {
            var recetaExistente = _recetaService.ObtenerPorId(id);

            if (recetaExistente == null)
            {
                return NotFound();
            }

            receta.Id = id;
            _recetaService.Actualizar(receta);

            return Ok(receta);
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            var recetaExistente = _recetaService.ObtenerPorId(id);

            if (recetaExistente == null)
            {
                return NotFound();
            }

            _recetaService.Eliminar(id);

            return Ok(new { mensaje = "Receta eliminada correctamente" });
        }
    }
}