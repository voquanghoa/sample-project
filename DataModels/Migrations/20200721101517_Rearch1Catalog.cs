using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class Rearch1Catalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchCategory");

            migrationBuilder.AddColumn<int>(
                name: "CatalogId",
                table: "Researches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Researches_CatalogId",
                table: "Researches",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Researches_Catalogs_CatalogId",
                table: "Researches",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Researches_Catalogs_CatalogId",
                table: "Researches");

            migrationBuilder.DropIndex(
                name: "IX_Researches_CatalogId",
                table: "Researches");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Researches");

            migrationBuilder.CreateTable(
                name: "ResearchCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ResearchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchCategory", x => new { x.CategoryId, x.ResearchId });
                    table.ForeignKey(
                        name: "FK_ResearchCategory_Catalogs_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchCategory_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResearchCategory_ResearchId",
                table: "ResearchCategory",
                column: "ResearchId");
        }
    }
}
