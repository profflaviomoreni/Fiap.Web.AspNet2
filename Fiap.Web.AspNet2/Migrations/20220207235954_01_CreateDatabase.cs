using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiap.Web.AspNet2.Migrations
{
    public partial class _01_CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Representante",
                columns: table => new
                {
                    RepresentanteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeRepresentante = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representante", x => x.RepresentanteId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Representante");
        }
    }
}
