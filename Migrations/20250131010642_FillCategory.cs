using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class FillCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"CategoryName\", \"CategoryImage\") VALUES ('Bebidas', 'bebidas.jpg');");
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"CategoryName\", \"CategoryImage\") VALUES ('Lanches', 'lanches.jpg');");
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"CategoryName\", \"CategoryImage\") VALUES ('Sobremesas', 'sobremesas.jpg');");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
