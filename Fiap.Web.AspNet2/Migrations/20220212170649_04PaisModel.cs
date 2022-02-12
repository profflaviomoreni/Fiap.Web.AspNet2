using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Web.AspNet2.Migrations
{
    public partial class _04PaisModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    PaisId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePais = table.Column<string>(maxLength: 30, nullable: false),
                    Continente = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.PaisId);
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "PaisId", "Continente", "NomePais" },
                values: new object[] { 1, "America do Sul", "Brasil" });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "PaisId", "Continente", "NomePais" },
                values: new object[] { 2, "Europa", "Alemanha" });

            migrationBuilder.CreateIndex(
                name: "IX_Pais_NomePais",
                table: "Pais",
                column: "NomePais");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pais");
        }
    }
}
