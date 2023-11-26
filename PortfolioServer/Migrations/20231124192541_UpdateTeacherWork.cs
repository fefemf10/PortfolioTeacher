using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTeacherWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTeacher");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BeginTimeWork",
                table: "Works",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<DateOnly>(
                name: "EndTimeWork",
                table: "Works",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post",
                table: "Works",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherWork");

            migrationBuilder.DropColumn(
                name: "BeginTimeWork",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "EndTimeWork",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Post",
                table: "Works");

            migrationBuilder.CreateTable(
                name: "WorkTeacher",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BeginTimeWork = table.Column<DateOnly>(type: "date", nullable: false),
                    EndTimeWork = table.Column<DateOnly>(type: "date", nullable: true),
                    Post = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    WorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTeacher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTeacher_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkTeacher_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeacher_TeacherId",
                table: "WorkTeacher",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTeacher_WorkId",
                table: "WorkTeacher",
                column: "WorkId");
        }
    }
}
