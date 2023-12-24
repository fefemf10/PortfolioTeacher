using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MiddleName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateBirthday = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Post = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AcademicDegree = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AcademicTitle = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AwardStudent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAward = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AwardStudent_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Awards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOrganization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAward = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DisciplineTeacher",
                columns: table => new
                {
                    DisciplinesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeachersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineTeacher", x => new { x.DisciplinesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_DisciplineTeacher_Disciplines_DisciplinesId",
                        column: x => x.DisciplinesId,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DisciplineTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dissertations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YearProtection = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dissertations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dissertations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfessionalDevelopments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOrganization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameDocument = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SeriaDocument = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberDocument = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateСompletion = table.Column<DateOnly>(type: "date", nullable: true),
                    ListeningTime = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalDevelopments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Form = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutputData = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    CoAuthor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScienceProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BeginTimeWork = table.Column<DateOnly>(type: "date", nullable: false),
                    EndTimeWork = table.Column<DateOnly>(type: "date", nullable: false),
                    Director = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScienceProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScienceProjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Qualification = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YearGraduation = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universities_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Post = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BeginTimeWork = table.Column<DateOnly>(type: "date", nullable: false),
                    EndTimeWork = table.Column<DateOnly>(type: "date", nullable: true),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("047d52a8-8327-4c61-9d3c-c07ea8e086b0"), "Исследование операций" },
                    { new Guid("0933d3b6-56ad-48ec-9d64-0eda8da495ca"), "Технологическая (учебная) практика" },
                    { new Guid("0a4e059b-f82a-43df-a0f4-2308be63fae9"), "Корпоративные информационные системы" },
                    { new Guid("0d5f77b2-bb04-4802-bca7-08d513064865"), "Управление проектами" },
                    { new Guid("1052553c-8701-42d7-8856-7ca9ac7e781d"), "Управление жизненным циклом информационных систем" },
                    { new Guid("10c955a1-5f0b-4b28-a925-0a1002018d05"), "Операционные системы" },
                    { new Guid("1161cf75-0b13-4ba6-9ba5-9068a2a5231f"), "Высшая математика" },
                    { new Guid("1191ce0a-0412-41b1-b4e9-e99a95a96292"), "Вычислительные системы, сети, телекоммуникации" },
                    { new Guid("138d8787-ea1b-4a2d-bc7d-ea20357e2671"), "Дискретная математика" },
                    { new Guid("1820e674-784b-4132-a02a-9e57d5076154"), "Анализ данных" },
                    { new Guid("2a94ab11-d4e9-49a3-a948-6e27dd213897"), "Русский язык и культура речи" },
                    { new Guid("351d07cc-1231-4e5d-9994-994f8f03a6a3"), "Социология" },
                    { new Guid("376615b9-1738-4ad9-a3e8-4cb258fed042"), "Экономика" },
                    { new Guid("399ef924-57ff-44de-913c-8c2adfe2ae7d"), "Физическая культура и спорт" },
                    { new Guid("39f5d742-9d7d-4b2d-9ce7-4f4582bbc0f4"), "Подготовка к процедуре защиты и защита выпускной квалификационной работы" },
                    { new Guid("3a20ef94-ea3b-466c-aa19-9197e1dd6eb2"), "Программная инженерия" },
                    { new Guid("3d8da6fd-f1c6-4b1f-9e76-93c21ab7f955"), "Информационные системы и технологии в управленческой деятельности" },
                    { new Guid("47054824-41f9-413c-9b64-546251a5d63c"), "Численные методы" },
                    { new Guid("523da6af-68e3-4085-bae6-2efd946fe6d3"), "Развитие информационного общества" },
                    { new Guid("53abfd92-1bcd-4085-bb11-a961a88259a5"), "Специальные главы высшей математики" },
                    { new Guid("5a41ac81-fffe-46ef-b20b-44314b6d5796"), "Физическая культура и спорт" },
                    { new Guid("5a50856f-9087-4dfe-bcab-24ab23aa6b33"), "Математические методы принятия решений" },
                    { new Guid("5e2d6aed-0d8b-4310-9adf-af265bbfc62e"), "Ознакомительная (учебная) практика" },
                    { new Guid("604e6e91-191c-418a-ae04-0430513f21e6"), "Технологии разработки программного продукта" },
                    { new Guid("616ec123-59b3-4c35-aa4a-f6589a1d89a4"), "Стандартизация и сертификация товаров и услуг" },
                    { new Guid("62d3a17d-e46d-4527-9f93-975092005d0d"), "Прогнозирование социальноэкономических процессов" },
                    { new Guid("64626701-555e-4356-befd-c985a3d90c0a"), "Технологическая (производственная) практика" },
                    { new Guid("6783c19c-affb-4673-b078-e650de6e0725"), "Системы поддержки принятия решений" },
                    { new Guid("68e9216d-a80c-4e68-a8b7-95d554023b9d"), "Психология" },
                    { new Guid("6af6d05b-0458-45c2-98e5-e552530d4dba"), "Безопасность жизнедеятельности" },
                    { new Guid("82bcfe2d-d66c-4fcd-87a1-7749c7442aa7"), "Математика криптографии" },
                    { new Guid("89147081-8697-4cc6-a5f1-dd9c4862fb41"), "Научно-исследовательская работа" },
                    { new Guid("8a7fb6d8-d286-403f-bb80-d0a8ca627e8f"), "Правоведение" },
                    { new Guid("8ab32200-0348-4230-b31b-8c947cafbee5"), "Математический инструментарий и модели оценки бизнеса" },
                    { new Guid("8eba311b-76c5-47a6-858d-539388393cae"), "Электронный бизнес" },
                    { new Guid("a45d7569-79ac-483b-8c1f-5ebabe829e89"), "Основы программирования" },
                    { new Guid("a800d8f8-ee66-402a-b5b6-ae134e543101"), "Основы научных исследований" },
                    { new Guid("a88cd626-2d56-4cc6-93fd-b9d74824053c"), "Моделирование бизнеспроцессов" },
                    { new Guid("b05e6b7b-036a-44f7-8024-bf1f242eaabe"), "Теория систем и системный анализ" },
                    { new Guid("b3ad2d68-801e-43ee-b32c-b33a061f1940"), "История России" },
                    { new Guid("bcb67b9a-41b7-4614-a88c-462d7a5df58a"), "Иностранный язык" },
                    { new Guid("c61bc8b3-4817-45d6-ad24-62575da07d48"), "Интернет технологии" },
                    { new Guid("c668255c-4f46-4320-8286-c38ea70fb11f"), "Теория риска и моделирование рисковых ситуаций" },
                    { new Guid("ca2c1cad-6872-49e3-9404-197eff47767a"), "Стандатизация, сертификация и управление качеством программного обеспечения" },
                    { new Guid("cd27d0b9-ffc9-4d33-a9dd-fa934d6dd90e"), "ИТ инфраструкту рапредприятия" },
                    { new Guid("d31150f3-03c1-45da-8bcc-63827e910ceb"), "Основы искусственного интеллекта" },
                    { new Guid("d484aae6-a15d-4544-a989-9aa327113161"), "Основы российской государственности" },
                    { new Guid("d93ce3a2-e6a4-4a12-a55d-c62309e05fa3"), "Философия" },
                    { new Guid("ead5b1a5-8b11-489a-9978-bec9e391e05d"), "Информатика" },
                    { new Guid("f0c15ee1-10f6-44fb-82a8-054034abad08"), "Базы данных" },
                    { new Guid("f93b6226-4149-4f90-8141-b823b43c5c63"), "Информационная безопасность" },
                    { new Guid("fbf7b32e-153b-4b38-919b-a2beb7fc3901"), "Преддипломная (производственная) практика" },
                    { new Guid("fd60802c-f8eb-45ba-981e-3cd09b96a96a"), "Основы военной подготовки" },
                    { new Guid("fe17670b-eed4-453a-8a64-a57b1576e6e9"), "Основы алгоритмизации" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardStudent_StudentId",
                table: "AwardStudent",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardStudent_TeacherId",
                table: "AwardStudent",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Awards_TeacherId",
                table: "Awards",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineTeacher_TeachersId",
                table: "DisciplineTeacher",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_Dissertations_TeacherId",
                table: "Dissertations",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalDevelopments_TeacherId",
                table: "ProfessionalDevelopments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_TeacherId",
                table: "Publications",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ScienceProjects_TeacherId",
                table: "ScienceProjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Universities_TeacherId",
                table: "Universities",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Works_TeacherId",
                table: "Works",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardStudent");

            migrationBuilder.DropTable(
                name: "Awards");

            migrationBuilder.DropTable(
                name: "DisciplineTeacher");

            migrationBuilder.DropTable(
                name: "Dissertations");

            migrationBuilder.DropTable(
                name: "ProfessionalDevelopments");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "ScienceProjects");

            migrationBuilder.DropTable(
                name: "Universities");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
