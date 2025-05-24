using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarColunaCinemaId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CinemaId",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "Filmes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_CinemaId",
                table: "Filmes",
                column: "CinemaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Cinemas_CinemaId",
                table: "Filmes",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Cinemas_CinemaId",
                table: "Filmes");

            migrationBuilder.DropIndex(
                name: "IX_Filmes_CinemaId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "CinemaId",
                table: "Filmes");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "Filmes");
        }
    }
}
