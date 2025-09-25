using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PGERP.Migrations
{
    public partial class RftTabelaLocatii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RftModelLocatiiSet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DenumireLocatie = table.Column<string>(type: "TEXT", nullable: true),
                    Latitudine = table.Column<double>(type: "REAL", nullable: false),
                    Longitudine = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RftModelLocatiiSet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RftModelLocatiiSet");
        }
    }
}
