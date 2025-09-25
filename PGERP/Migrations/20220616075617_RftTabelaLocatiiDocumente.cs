using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGERP.Migrations
{
    public partial class RftTabelaLocatiiDocumente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RftModelLocatieDocumenteSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Denumire = table.Column<string>(type: "TEXT", nullable: true),
                    Locatie = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelLocatieDocumenteSet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RftModelLocatieDocumenteSet");
        }
    }
}
