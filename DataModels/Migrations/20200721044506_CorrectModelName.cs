using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class CorrectModelName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Topics_TopicId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Topics_TopicId",
                table: "Catalogs");

            migrationBuilder.DropTable(
                name: "TopicMembers");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_TopicId",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_TopicId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Attachment");

            migrationBuilder.AddColumn<int>(
                name: "ResearchId",
                table: "Catalogs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResearchId",
                table: "Attachment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Researches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    MentorId = table.Column<int>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    EndYear = table.Column<int>(nullable: false),
                    Progress = table.Column<int>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ValidatorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Researches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Researches_Employees_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Researches_Employees_ValidatorId",
                        column: x => x.ValidatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResearchMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    ResearchId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResearchMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResearchMembers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResearchMembers_Researches_ResearchId",
                        column: x => x.ResearchId,
                        principalTable: "Researches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_ResearchId",
                table: "Catalogs",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ResearchId",
                table: "Attachment",
                column: "ResearchId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_MentorId",
                table: "Researches",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Researches_ValidatorId",
                table: "Researches",
                column: "ValidatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchMembers_EmployeeId",
                table: "ResearchMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResearchMembers_ResearchId",
                table: "ResearchMembers",
                column: "ResearchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Researches_ResearchId",
                table: "Attachment",
                column: "ResearchId",
                principalTable: "Researches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Researches_ResearchId",
                table: "Catalogs",
                column: "ResearchId",
                principalTable: "Researches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_Researches_ResearchId",
                table: "Attachment");

            migrationBuilder.DropForeignKey(
                name: "FK_Catalogs_Researches_ResearchId",
                table: "Catalogs");

            migrationBuilder.DropTable(
                name: "ResearchMembers");

            migrationBuilder.DropTable(
                name: "Researches");

            migrationBuilder.DropIndex(
                name: "IX_Catalogs_ResearchId",
                table: "Catalogs");

            migrationBuilder.DropIndex(
                name: "IX_Attachment_ResearchId",
                table: "Attachment");

            migrationBuilder.DropColumn(
                name: "ResearchId",
                table: "Catalogs");

            migrationBuilder.DropColumn(
                name: "ResearchId",
                table: "Attachment");

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Catalogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Attachment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MentorId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Progress = table.Column<int>(type: "int", nullable: false),
                    ValidatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topics_Employees_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Topics_Employees_ValidatorId",
                        column: x => x.ValidatorId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TopicMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TopicMembers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicMembers_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_TopicId",
                table: "Catalogs",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_TopicId",
                table: "Attachment",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicMembers_EmployeeId",
                table: "TopicMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicMembers_TopicId",
                table: "TopicMembers",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_MentorId",
                table: "Topics",
                column: "MentorId");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_ValidatorId",
                table: "Topics",
                column: "ValidatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_Topics_TopicId",
                table: "Attachment",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Catalogs_Topics_TopicId",
                table: "Catalogs",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
