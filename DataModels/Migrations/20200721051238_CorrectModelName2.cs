using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class CorrectModelName2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Researches_ResearchId",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_ResearchId",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "ResearchId",
                table: "Catalogs");

            migrationBuilder.CreateTable(
                name: "ResearchCategory",
                columns: table => new
                {
                    ResearchId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResearchCategory");

            migrationBuilder.AddColumn<int>(
                name: "ResearchId",
                table: "Catalogs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_ResearchId",
                table: "Catalogs",
                column: "ResearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Researches_ResearchId",
                table: "Catalogs",
                column: "ResearchId",
                principalTable: "Researches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
