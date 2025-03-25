using ApiCatalogo.Models;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCatalogo.Migrations
{
    /// <inheritdoc />
    public partial class FillProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO \"Products\" (\"ProductName\", \"ProductDescription\", \"Price\", \"ProductImage\", \"ProductStock\", \"ProductDate\", \"CategoryId\")" +
                "Values('Coca-cola', 'Refrigerante Coca 350ml', '4.50', 'cocacola.jpg', 100, now(),1)");

            mb.Sql("INSERT INTO \"Products\" (\"ProductName\", \"ProductDescription\", \"Price\", \"ProductImage\", \"ProductStock\", \"ProductDate\", \"CategoryId\")" +
                "Values('Big-Mac', 'Big mac 200g', '30.00', 'bigmac.jpg', 1000, now(),2)");

            mb.Sql("INSERT INTO \"Products\" (\"ProductName\", \"ProductDescription\", \"Price\", \"ProductImage\", \"ProductStock\", \"ProductDate\", \"CategoryId\")" +
                "Values('Brigadeiro', 'Brigadeiro de nutella', '5.00', 'brigadeiro.jpg', 50, now(),3)");

        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Products");
        }
    }
}
