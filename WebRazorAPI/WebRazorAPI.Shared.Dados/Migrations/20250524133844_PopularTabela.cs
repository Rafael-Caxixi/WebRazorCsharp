using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRazorAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopularTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Cinemas", new string[] {"Nome"}, new object[] {"Cinemark"});

            migrationBuilder.InsertData("Cinemas", new string[] { "Nome" }, new object[] { "Cinépolis" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cinemas");
        }
    }
}
