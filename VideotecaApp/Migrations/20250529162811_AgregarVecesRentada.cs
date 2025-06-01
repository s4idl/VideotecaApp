using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideotecaApp.Migrations
{
    /// <inheritdoc />
    public partial class AgregarVecesRentada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VecesRentada",
                table: "Peliculas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VecesRentada",
                table: "Peliculas");
        }
    }
}
