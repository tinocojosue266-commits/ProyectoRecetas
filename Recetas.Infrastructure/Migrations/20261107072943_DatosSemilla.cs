using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Recetas.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DatosSemilla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recetas",
                columns: new[] { "Id", "Descripcion", "Ingredientes", "Instrucciones", "Nombre" },
                values: new object[,]
                {
                    { 1, "Comida tradicional hondureña", "Tortilla, frijoles, queso y mantequilla", "Preparar la tortilla y agregar los ingredientes.", "Baleadas" },
                    { 2, "Plato típico hondureño", "Pollo, plátano, repollo y salsa", "Cocinar el pollo y servir con tajadas.", "Pollo con tajadas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recetas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recetas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
