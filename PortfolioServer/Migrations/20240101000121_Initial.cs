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
                    StudentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAward = table.Column<DateOnly>(type: "date", nullable: true),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardStudent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AwardStudent_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameOrganization = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateAward = table.Column<DateOnly>(type: "date", nullable: true),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Awards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Awards_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YearProtection = table.Column<DateOnly>(type: "date", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dissertations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dissertations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProfessionalDevelopments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
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
                    ListeningTime = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalDevelopments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalDevelopments_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PublicActivities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicActivities_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Form = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutputData = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    CoAuthor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publications_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    EndTimeWork = table.Column<DateOnly>(type: "date", nullable: true),
                    Director = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScienceProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScienceProjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Universities_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TeacherId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("012a4602-836b-4ca5-acbf-2711d8356bb3"), "Моделирование бизнеспроцессов" },
                    { new Guid("0380e4ba-9dfc-42b9-9c40-10a870e7e41b"), "Стандартизация и сертификация товаров и услуг" },
                    { new Guid("06bdd2ce-0c7c-47e1-be9a-3b714794b871"), "Научно-исследовательская работа" },
                    { new Guid("0c137718-bb65-47e9-9aaf-3fed05185782"), "Управление проектами" },
                    { new Guid("0ca6c201-57d1-46a5-9a87-c0475bec8cba"), "Исследование операций" },
                    { new Guid("14999546-cfcb-4830-9fda-95be3f0d2a3a"), "Социология" },
                    { new Guid("16494a50-7142-4503-bc9a-893048258a0e"), "Основы программирования" },
                    { new Guid("1841ef02-1e49-4fae-a5d7-33b7c946a159"), "Высшая математика" },
                    { new Guid("18c8db64-23c8-43e7-8618-5a46f8588c98"), "Философия" },
                    { new Guid("25ea064c-4651-4681-b832-f0638c12e974"), "Электронный бизнес" },
                    { new Guid("298d0948-18ae-4741-a292-e7c1b385cece"), "Прогнозирование социальноэкономических процессов" },
                    { new Guid("2fed4e2d-9b9e-41df-b125-9c628ac0dfb7"), "Основы алгоритмизации" },
                    { new Guid("31107ce0-6ed5-4332-81e7-96b90c14a526"), "Информатика" },
                    { new Guid("3289bf2d-52e4-4969-89c9-da4755d39019"), "Основы российской государственности" },
                    { new Guid("331d0429-ec4c-4af5-96a4-c80043cd579f"), "ИТ инфраструкту рапредприятия" },
                    { new Guid("34b655e7-bb7b-441f-972f-df5d50636f70"), "Технологическая (учебная) практика" },
                    { new Guid("34b77929-e275-497b-9bf6-62612d7a804d"), "Базы данных" },
                    { new Guid("35492a5b-b565-46c9-9670-a51daf18a58e"), "Информационная безопасность" },
                    { new Guid("377d40f4-42d9-497f-a566-4ce48e810747"), "Управление жизненным циклом информационных систем" },
                    { new Guid("39838905-55a9-485e-8c83-f75a67543fc0"), "Технологии разработки программного продукта" },
                    { new Guid("3b76dd8f-7561-4341-a08b-0c16310f7e0f"), "Вычислительные системы, сети, телекоммуникации" },
                    { new Guid("3e645787-1fc0-4457-b606-6b64cd21c6c9"), "Системы поддержки принятия решений" },
                    { new Guid("3f992657-924e-4174-87ad-89e5dd9ace8d"), "Математика криптографии" },
                    { new Guid("4a8a17c3-12d6-4dc2-b9dc-91ff5ead501f"), "Основы научных исследований" },
                    { new Guid("4fc529bb-3023-4245-a619-4eeb4031d203"), "Основы военной подготовки" },
                    { new Guid("5148bf9d-52c1-4da4-936d-59637fc13060"), "Психология" },
                    { new Guid("5a8f707c-d9ea-4335-a929-0f0ecadac2b4"), "Развитие информационного общества" },
                    { new Guid("66fdd7c5-0382-4b80-959b-d1a655e520db"), "Ознакомительная (учебная) практика" },
                    { new Guid("6c2ede09-05c1-480b-a386-06d31baa20ec"), "Информационные системы и технологии в управленческой деятельности" },
                    { new Guid("6c556744-6875-4bc1-9537-f178af1400d6"), "Физическая культура и спорт" },
                    { new Guid("76a30eac-9b28-42c0-852c-b7d418c6d35a"), "Преддипломная (производственная) практика" },
                    { new Guid("7a2fbb10-7056-4f4f-8b60-67b94f23cf9c"), "Операционные системы" },
                    { new Guid("82aeaed6-bce2-4733-9bfa-bffcc096a679"), "Корпоративные информационные системы" },
                    { new Guid("87c014a3-4a4c-4c79-9575-5bf449221c23"), "Численные методы" },
                    { new Guid("96ca4c5e-235c-4bd2-8b4d-13faa2608f09"), "Физическая культура и спорт" },
                    { new Guid("9a6639af-c7e4-4aaa-bb2f-9c9e6f7c579d"), "Математические методы принятия решений" },
                    { new Guid("9f96e91f-f0ce-4202-ad41-58088bfc1cd7"), "Специальные главы высшей математики" },
                    { new Guid("a211418a-763d-4cae-86bf-0a996a39a495"), "Математический инструментарий и модели оценки бизнеса" },
                    { new Guid("ace8bc1a-c8f4-4db7-b2ab-f8701fb26d7b"), "Интернет технологии" },
                    { new Guid("b4176dfe-9068-482d-94fb-f53c9b78e6fe"), "Дискретная математика" },
                    { new Guid("b51989d0-235e-42cf-ac0b-ee1401ba35b5"), "Основы искусственного интеллекта" },
                    { new Guid("c0a2d817-c7f0-4c1c-90d8-6f66f0ec2317"), "Стандатизация, сертификация и управление качеством программного обеспечения" },
                    { new Guid("c750dd05-0a39-43d1-8a42-c135026adde2"), "Иностранный язык" },
                    { new Guid("c8f7e0d4-0739-411b-a2bf-e82b0c0cb1c6"), "Русский язык и культура речи" },
                    { new Guid("d29b3e99-3e3d-4d7c-9745-28ab34d0ef64"), "Правоведение" },
                    { new Guid("d46fa45f-a43e-48c8-bfeb-611ecb872f4b"), "Анализ данных" },
                    { new Guid("d5c4f978-6f55-452f-9542-43a545c9128a"), "Безопасность жизнедеятельности" },
                    { new Guid("d94d8e22-f511-45e1-ba0b-50a07fecf017"), "Экономика" },
                    { new Guid("d9b31ec4-1bc4-497f-8263-84e84cf59382"), "Технологическая (производственная) практика" },
                    { new Guid("daaa1bb9-24a5-4fba-9ffb-e2072af9382f"), "Подготовка к процедуре защиты и защита выпускной квалификационной работы" },
                    { new Guid("db69e3d9-98bb-4224-aec3-2d6730323fb8"), "Программная инженерия" },
                    { new Guid("e64f6f59-ff86-4260-a4fc-77093a7e579a"), "История России" },
                    { new Guid("ea958358-df1e-494f-9fb6-6243916ffde5"), "Теория систем и системный анализ" },
                    { new Guid("edb78982-eedc-4df2-835b-69b5321de6b8"), "Теория риска и моделирование рисковых ситуаций" }
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
                name: "IX_PublicActivities_TeacherId",
                table: "PublicActivities",
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
                name: "PublicActivities");

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
