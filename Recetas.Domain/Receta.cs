using System;
using System.Collections.Generic;
using System.Text;

namespace Recetas.Domain
{
    public class Receta
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public string Ingredientes { get; set; } = string.Empty;

        public string Instrucciones { get; set; } = string.Empty;
    }
}
