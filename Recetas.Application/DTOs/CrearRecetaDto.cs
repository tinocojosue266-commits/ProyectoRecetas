using System.ComponentModel.DataAnnotations;

namespace Recetas.Application.DTOs
{
    public class CrearRecetaDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500, ErrorMessage = "La descripción no puede superar los 500 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los ingredientes son obligatorios.")]
        public string Ingredientes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Las instrucciones son obligatorias.")]
        public string Instrucciones { get; set; } = string.Empty;
    }
}