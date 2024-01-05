using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
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
                name: "Faculties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculties", x => x.Id);
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
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacultyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("007fc26a-b566-4986-ad13-49a9a483a2a8"), "Основы военной подготовки" },
                    { new Guid("0604e92f-f3a6-48e4-86c5-9f9374ce4c74"), "Программная инженерия" },
                    { new Guid("060d49a5-3f67-4dff-b483-6abb79fc1f5c"), "ИТ инфраструкту рапредприятия" },
                    { new Guid("07317a96-d5ea-42f6-81de-f36b28945061"), "Управление жизненным циклом информационных систем" },
                    { new Guid("094910c6-138e-4673-8348-10fc960ccf25"), "Информационные системы и технологии в управленческой деятельности" },
                    { new Guid("0a1f7076-d782-44f8-8c0e-1c02bb4a1468"), "Информационная безопасность" },
                    { new Guid("0e806e83-ff69-428b-8812-8de01180bffe"), "Теория систем и системный анализ" },
                    { new Guid("10b81fcb-6374-4667-95cd-1a1a15c85341"), "Безопасность жизнедеятельности" },
                    { new Guid("13d4551d-ed46-43af-b8e6-bffb66fb4ae0"), "Стандатизация, сертификация и управление качеством программного обеспечения" },
                    { new Guid("147d16f6-bd4e-47ce-8c9b-dc560db9025f"), "Информатика" },
                    { new Guid("1cda4323-e379-4ff2-aa0c-e0d218f26c1b"), "Технологическая (производственная) практика" },
                    { new Guid("1fb68c0a-4793-4832-930e-c1c73732faef"), "Основы научных исследований" },
                    { new Guid("224ca286-ed1e-4eca-adfd-7a55dc2298f1"), "Научно-исследовательская работа" },
                    { new Guid("25a86e06-d1de-404f-b5b6-f428878a3061"), "Дискретная математика" },
                    { new Guid("26890444-848d-4c2d-8f12-da010ad8d84f"), "Стандартизация и сертификация товаров и услуг" },
                    { new Guid("27dfcbd8-59d5-4518-8fa1-09986aa75433"), "Основы искусственного интеллекта" },
                    { new Guid("33c5fac8-428c-4661-82ad-19fac03663e6"), "Философия" },
                    { new Guid("3525b34f-7ce5-4f15-a82b-76e58d2153bc"), "Психология" },
                    { new Guid("3ae027ea-9670-4235-a637-fbe5c3a3f81a"), "Социология" },
                    { new Guid("441a5fab-5bb6-491d-a8c9-8dd941f7404f"), "Теория риска и моделирование рисковых ситуаций" },
                    { new Guid("4f777a7f-d6e8-4905-ac98-bbf039505600"), "Русский язык и культура речи" },
                    { new Guid("52953462-3be4-4349-a086-2c3dc321d8ea"), "Вычислительные системы, сети, телекоммуникации" },
                    { new Guid("5695a9c2-da4f-4952-9442-ef99ad24fe9e"), "Корпоративные информационные системы" },
                    { new Guid("581d2a5e-66dc-45e6-8313-4e8049f727da"), "Управление проектами" },
                    { new Guid("6a26f1bd-369a-48f0-9bcc-8765c0b7b1f3"), "Правоведение" },
                    { new Guid("6f087119-3318-474a-9c9d-6b38b3175171"), "Анализ данных" },
                    { new Guid("74492d42-bfe3-4063-a3c1-bb1a06ce9b47"), "Математические методы принятия решений" },
                    { new Guid("7815f1d3-818e-4396-8105-54c8edbe8900"), "Преддипломная (производственная) практика" },
                    { new Guid("7a9b80e7-13e2-4b6e-8e62-4bd763ae6b82"), "Математический инструментарий и модели оценки бизнеса" },
                    { new Guid("7c8d30d8-9a67-49e5-84de-61c453789236"), "Физическая культура и спорт" },
                    { new Guid("8ba8eb53-87f4-41a0-8875-44cdefc15c61"), "Электронный бизнес" },
                    { new Guid("929864e7-8ea6-4021-9c8e-87c99db70077"), "Специальные главы высшей математики" },
                    { new Guid("99b2b4d8-828c-4fee-a583-f8b8abfec73c"), "Моделирование бизнеспроцессов" },
                    { new Guid("9a3f825b-cc87-453e-a819-ae45850f05ef"), "Экономика" },
                    { new Guid("9e59dce9-0da1-403b-a732-84767fbffa35"), "Базы данных" },
                    { new Guid("a502079d-edb3-47cd-abaf-f93e42fccabb"), "Технологии разработки программного продукта" },
                    { new Guid("a9a16ccd-8f75-4906-977a-7122fcdd85df"), "Численные методы" },
                    { new Guid("ad17ccdc-e5f3-4e2a-9742-7817cde7c314"), "Физическая культура и спорт" },
                    { new Guid("af17d1ee-1f42-44b8-a7fa-ecc2e85cae94"), "Системы поддержки принятия решений" },
                    { new Guid("b1752f48-13d9-4474-8dfa-80a08a5ac512"), "Операционные системы" },
                    { new Guid("b33cf226-2b4a-4aaf-b0f2-82786e56e325"), "Развитие информационного общества" },
                    { new Guid("b534a3d3-150a-4e7b-b751-63c6d7b5e37c"), "Исследование операций" },
                    { new Guid("badd7e73-a6f7-4713-a90a-f8110fcbe200"), "Математика криптографии" },
                    { new Guid("cc602659-f846-4ee5-b67c-dfc55a4cd776"), "Подготовка к процедуре защиты и защита выпускной квалификационной работы" },
                    { new Guid("d059640c-4cab-40cb-b42c-898873df86ec"), "Высшая математика" },
                    { new Guid("d4159673-8d3b-49d8-9298-90e6ff0eb319"), "Иностранный язык" },
                    { new Guid("d4ecfcd1-4a05-4d8c-a0d0-b25970a3a030"), "Основы российской государственности" },
                    { new Guid("df1b3e87-231d-4da5-9ce2-c62379ed292d"), "Основы алгоритмизации" },
                    { new Guid("e139d310-eb90-464b-b91d-ee2f2d06b6f0"), "Интернет технологии" },
                    { new Guid("e393525c-b3ad-43ac-91bb-5fec30fb2e23"), "Ознакомительная (учебная) практика" },
                    { new Guid("e448b0e9-b3e7-433a-9bbc-df342ee681ba"), "Прогнозирование социальноэкономических процессов" },
                    { new Guid("e5c71e1c-56c1-431d-a2af-9cb2d18e1a4c"), "Основы программирования" },
                    { new Guid("fb69aff8-4b7a-4100-ae80-f5ab69e5da32"), "История России" },
                    { new Guid("fdf37719-0e2e-4e7b-a967-4f16420288c1"), "Технологическая (учебная) практика" }
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
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

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
                name: "IX_Teachers_DepartmentId",
                table: "Teachers",
                column: "DepartmentId");

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
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Faculties");
        }
    }
}
