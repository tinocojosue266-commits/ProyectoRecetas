using Microsoft.EntityFrameworkCore;
using Recetas.Domain;

namespace Recetas.Infrastructure
{
    public class RecetasDbContext : DbContext
    {
        public RecetasDbContext(DbContextOptions<RecetasDbContext> options)
            : base(options)
        {
        }

        public DbSet<Receta> Recetas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Receta>().HasData(
                new Receta
                {
                    Id = 1,
                    Nombre = "Baleadas",
                    Descripcion = "Comida tradicional hondureña",
                    Ingredientes = "Tortilla, frijoles, queso y mantequilla",
                    Instrucciones = "Preparar la tortilla y agregar los ingredientes."
                },
                new Receta
                {
                    Id = 2,
                    Nombre = "Pollo con tajadas",
                    Descripcion = "Plato típico hondureño",
                    Ingredientes = "Pollo, plátano, repollo y salsa",
                    Instrucciones = "Cocinar el pollo y servir con tajadas."
                }
            );
        }
    }
}