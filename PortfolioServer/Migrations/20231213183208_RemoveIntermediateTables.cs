using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIntermediateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScienceProjectTeacher");

            migrationBuilder.DropTable(
                name: "UniversityTeacher");

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Universities",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Specialization",
                table: "Universities",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Universities",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<int>(
                name: "YearGraduation",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "BeginTimeWork",
                table: "ScienceProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "Director",
                table: "ScienceProjects",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndTimeWork",
                table: "ScienceProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "ScienceProjects",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_TeacherId",
                table: "Universities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ScienceProjects_TeacherId",
                table: "ScienceProjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScienceProjects_Teachers_TeacherId",
                table: "ScienceProjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Teachers_TeacherId",
                table: "Universities",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScienceProjects_Teachers_TeacherId",
                table: "ScienceProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Teachers_TeacherId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_Universities_TeacherId",
                table: "Universities");

            migrationBuilder.DropIndex(
                name: "IX_ScienceProjects_TeacherId",
                table: "ScienceProjects");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Specialization",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "YearGraduation",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "BeginTimeWork",
                table: "ScienceProjects");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "ScienceProjects");

            migrationBuilder.DropColumn(
                name: "EndTimeWork",
                table: "ScienceProjects");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "ScienceProjects");

            migrationBuilder.CreateTable(
                name: "ScienceProjectTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeginTimeWork = table.Column<DateOnly>(type: "date", nullable: false),
                    Director = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EndTimeWork = table.Column<DateOnly>(type: "date", nullable: false),
                    ScienceProjectId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScienceProjectTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScienceProjectTeacher_ScienceProjects_ScienceProjectId",
                        column: x => x.ScienceProjectId,
                        principalTable: "ScienceProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScienceProjectTeacher_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UniversityTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Qualification = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UniversityId = table.Column<int>(type: "int", nullable: false),
                    YearGraduation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityTeacher_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniversityTeacher_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ScienceProjectTeacher_ScienceProjectId",
                table: "ScienceProjectTeacher",
                column: "ScienceProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ScienceProjectTeacher_TeacherId",
                table: "ScienceProjectTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeacher_TeacherId",
                table: "UniversityTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityTeacher_UniversityId",
                table: "UniversityTeacher",
                column: "UniversityId");
        }
    }
}
