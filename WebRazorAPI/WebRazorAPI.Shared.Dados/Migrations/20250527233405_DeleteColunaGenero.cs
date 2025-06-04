using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeleteColunaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Filmes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
