using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFotoPerfilCinema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoPerfil",
                table: "Cinemas",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "Cinemas");
        }
    }
}
