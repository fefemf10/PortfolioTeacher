using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacherWork2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherWork");

            migrationBuilder.AddColumn<Guid>(
                name: "TeacherId",
                table: "Works",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TeacherId",
                table: "Works",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Teachers_TeacherId",
                table: "Works",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_Teachers_TeacherId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_TeacherId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Works");

            migrationBuilder.CreateTable(
                name: "TeacherWork",
                columns: table => new
                {
                    TeachersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherWork", x => new { x.TeachersId, x.WorksId });
                    table.ForeignKey(
                        name: "FK_TeacherWork_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherWork_Works_WorksId",
                        column: x => x.WorksId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherWork_WorksId",
                table: "TeacherWork",
                column: "WorksId");
        }
    }
}
