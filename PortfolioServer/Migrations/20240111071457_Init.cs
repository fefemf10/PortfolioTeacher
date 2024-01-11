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
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
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
                    FacultyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    Image = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teachers_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
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
                    Size = table.Column<uint>(type: "int unsigned", nullable: false),
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
                    { new Guid("00c9b7fd-f930-4ce9-b4a7-a791c5264689"), "Системы поддержки принятия решений" },
                    { new Guid("04c69e8f-f8c6-4cc9-b071-eb9e351e3c5e"), "Стандартизация и сертификация товаров и услуг" },
                    { new Guid("0e945009-06c8-49b9-a59b-60bd0ddcc9f7"), "Основы программирования" },
                    { new Guid("156d07e5-b424-4931-9b4e-7451f20ee951"), "Электронный бизнес" },
                    { new Guid("2245f749-8535-4349-8497-20d3aef36ac9"), "Дискретная математика" },
                    { new Guid("25f0c58e-3d10-4051-8960-9a69362bbfa9"), "Основы военной подготовки" },
                    { new Guid("28721d05-499c-449e-99b0-a82f6aaacb27"), "ИТ инфраструкту рапредприятия" },
                    { new Guid("2ae7c7e0-cbbe-4e7c-b627-8a40b7de549a"), "Корпоративные информационные системы" },
                    { new Guid("2bd5f1af-32e2-4072-8db6-9e1bade151c2"), "Операционные системы" },
                    { new Guid("2e338091-7461-4782-8ec2-241ccad86837"), "Русский язык и культура речи" },
                    { new Guid("36ef629f-dc81-43de-ad5e-e8279da39440"), "Подготовка к процедуре защиты и защита выпускной квалификационной работы" },
                    { new Guid("38e80190-e719-4f2a-8bac-b5f9f7659cc9"), "Стандатизация, сертификация и управление качеством программного обеспечения" },
                    { new Guid("4f08a32f-5b34-4e5b-a55d-2073e1613094"), "Технологии разработки программного продукта" },
                    { new Guid("501560c0-d542-4e85-9687-ed26b5850453"), "Специальные главы высшей математики" },
                    { new Guid("52fab53c-00eb-4c46-85fa-98ff9f0d5247"), "Управление проектами" },
                    { new Guid("541b28ee-dada-4b81-8b17-719ce864efbe"), "Теория систем и системный анализ" },
                    { new Guid("56087a6c-94db-44dd-8f01-fd33fd3f1da7"), "Научно-исследовательская работа" },
                    { new Guid("5833745a-fa76-40c1-97b0-d4dbe0487f1d"), "Информационная безопасность" },
                    { new Guid("5a0b53be-ad89-4234-8f7a-e7b166228fd8"), "Технологическая (учебная) практика" },
                    { new Guid("5c92f52e-65cd-4b40-a587-b5e2009aec03"), "Исследование операций" },
                    { new Guid("61a3adc9-a530-4a26-adbe-56a658163c7a"), "История России" },
                    { new Guid("6de75f33-9c83-4ecb-aa91-c79a7dd4c75d"), "Правоведение" },
                    { new Guid("787db592-8295-4b76-9a1e-7ff38b605a8b"), "Базы данных" },
                    { new Guid("7c588855-b26b-418b-915a-bed8be779fac"), "Преддипломная (производственная) практика" },
                    { new Guid("7edd1aea-dff7-44ba-a07a-322110c834bf"), "Анализ данных" },
                    { new Guid("9310df47-05c0-448f-983a-3e6880be1d79"), "Прогнозирование социальноэкономических процессов" },
                    { new Guid("98fca2d4-6879-4ffc-b43c-7ca5fb48eae5"), "Основы искусственного интеллекта" },
                    { new Guid("9e4ee716-7fb5-46a5-9001-547c6d73a4d1"), "Информационные системы и технологии в управленческой деятельности" },
                    { new Guid("a268a2e2-a465-4dbc-a0d6-03dc18a6d3fe"), "Высшая математика" },
                    { new Guid("a5031ede-935d-41ad-85cc-eb28d4158a76"), "Физическая культура и спорт" },
                    { new Guid("af5c7f49-c006-41b6-884c-e172a829ba46"), "Развитие информационного общества" },
                    { new Guid("afec8530-e85e-4b36-957a-538445a0d567"), "Философия" },
                    { new Guid("b17daf86-5e63-49cf-8377-f5b6ff26122a"), "Управление жизненным циклом информационных систем" },
                    { new Guid("b58b525e-b3db-4b83-a4dc-5fe50828a213"), "Физическая культура и спорт" },
                    { new Guid("b5d9fafd-f8fa-46e1-bcee-9a230d116657"), "Психология" },
                    { new Guid("b64b70f6-206d-4152-b0a4-204426e98d75"), "Теория риска и моделирование рисковых ситуаций" },
                    { new Guid("beb24be4-3811-4627-adf0-dadcdcbc93a0"), "Безопасность жизнедеятельности" },
                    { new Guid("bf530cb5-d4f5-4e68-ac9d-5b7d1861cf14"), "Математические методы принятия решений" },
                    { new Guid("c97eeead-57e4-4de6-8aa0-5ea765028e53"), "Математика криптографии" },
                    { new Guid("d31ee0cb-ada8-4f1f-aec2-2fccca84c0df"), "Основы российской государственности" },
                    { new Guid("d53f9cc7-63fa-4265-8751-78c80ae6b142"), "Ознакомительная (учебная) практика" },
                    { new Guid("d91b95b2-7aa8-4737-8b9d-3e354e47ef78"), "Экономика" },
                    { new Guid("ddcbe6bd-d123-48a6-963e-c634658f9376"), "Программная инженерия" },
                    { new Guid("e0d2114d-cf5b-4c8a-81f7-a72aabcef611"), "Технологическая (производственная) практика" },
                    { new Guid("e1fc57cd-e0b5-453d-b462-b97f2c8a7bc6"), "Моделирование бизнеспроцессов" },
                    { new Guid("e23e9ede-0739-4a19-853b-e6e8e3e0f922"), "Социология" },
                    { new Guid("e32128b2-becc-4fcf-a3e7-11f5c06d3613"), "Интернет технологии" },
                    { new Guid("f020a22f-ba11-43dd-8918-d656a9eab567"), "Иностранный язык" },
                    { new Guid("f252d969-2de7-496b-9d7b-e2bb2a87571a"), "Численные методы" },
                    { new Guid("f35d3718-ade5-47af-83b9-71adfd636b42"), "Вычислительные системы, сети, телекоммуникации" },
                    { new Guid("f370e8e0-5eaf-48e1-a100-9efd30744619"), "Математический инструментарий и модели оценки бизнеса" },
                    { new Guid("f77d9167-5751-4e92-b286-3b7486d77343"), "Информатика" },
                    { new Guid("fa0f8fb0-201f-416b-a1cc-ef5f1c016077"), "Основы научных исследований" },
                    { new Guid("fb73543d-a472-489a-9de0-56acefb7076c"), "Основы алгоритмизации" }
                });

            migrationBuilder.InsertData(
                table: "Faculties",
                columns: new[] { "Id", "FullName", "Name" },
                values: new object[,]
                {
                    { new Guid("57390fd9-34f1-430a-bb8c-093bf3d34728"), "Горный", "Горный" },
                    { new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Фундаментального Инженерного Образования и Инноваций", "ФИОИ" },
                    { new Guid("7217294e-e4de-4725-a522-8d64555fe142"), "Автоматизации Производственных Процессов", "АПП" },
                    { new Guid("7ce42d42-826e-49a9-80c7-11575f891a7c"), "Экономики и Бизнеса", "ЭБ" },
                    { new Guid("eb9a4659-4663-421a-97ad-e54104e751cb"), "Металлургического и Машиностроительного Производства", "ММП" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "FacultyId", "Name" },
                values: new object[,]
                {
                    { new Guid("0530b037-7b07-452e-a950-53840e398c26"), new Guid("7ce42d42-826e-49a9-80c7-11575f891a7c"), "Теории и практики перевода и общего языкознания" },
                    { new Guid("0de1c062-0a18-43b0-8626-78c4570056ce"), new Guid("eb9a4659-4663-421a-97ad-e54104e751cb"), "Технологии и организации машиностроительного производства" },
                    { new Guid("2a416a4e-d08b-4e3d-a837-8e75f6770324"), new Guid("7217294e-e4de-4725-a522-8d64555fe142"), "Специализированных компьютерных систем" },
                    { new Guid("2ac044d9-8ba2-442c-abfd-217231c784e9"), new Guid("7217294e-e4de-4725-a522-8d64555fe142"), "Автоматизированных электромеханических систем имени проф. А.Б. Зеленова" },
                    { new Guid("2d49b107-3731-40aa-8d26-04f244c178b7"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Промышленного строительства" },
                    { new Guid("3cb7b753-2655-4931-80ca-ec591bf88871"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Архитектурного дизайна и строительных конструкций" },
                    { new Guid("4acc78ce-009f-4e24-a288-b66a79372e78"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Информационных технологий" },
                    { new Guid("62831566-6eb9-44a7-9481-323164b741b4"), new Guid("57390fd9-34f1-430a-bb8c-093bf3d34728"), "Экологии и безопасности жизнедеятельности" },
                    { new Guid("6c06bf14-1f60-493d-9fa3-afc6c857c873"), new Guid("7ce42d42-826e-49a9-80c7-11575f891a7c"), "Финансов" },
                    { new Guid("70bdc85c-b82c-4af7-b3b6-da4d84ca7e05"), new Guid("7217294e-e4de-4725-a522-8d64555fe142"), "Автоматизированного управления технологическими процессами" },
                    { new Guid("8104c9b6-05b4-45c4-8b25-317414740310"), new Guid("57390fd9-34f1-430a-bb8c-093bf3d34728"), "Геотехнологий и безопасности производств" },
                    { new Guid("91a675f9-38a3-40c8-9406-317260c857a8"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Инженерной механики и строительства" },
                    { new Guid("933b1fc2-624c-43fb-b118-2ecffa5ce63a"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Языковой подготовки специалистов" },
                    { new Guid("979cabfa-c56d-4770-b1c3-5c876567dc54"), new Guid("57390fd9-34f1-430a-bb8c-093bf3d34728"), "Горных энергомеханических систем" },
                    { new Guid("a782c774-4557-4168-b12d-d667db3eae29"), new Guid("7ce42d42-826e-49a9-80c7-11575f891a7c"), "Менеджмента" },
                    { new Guid("ad968ac8-8ce7-4a12-a23a-59875e3b43b1"), new Guid("7ce42d42-826e-49a9-80c7-11575f891a7c"), "Государственного аудита" },
                    { new Guid("b44db6d6-388d-45d6-9790-155adf52b3b7"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Управления инновациями в промышленности" },
                    { new Guid("c8ba340f-3e02-47b7-ad4d-5a3c750e2210"), new Guid("eb9a4659-4663-421a-97ad-e54104e751cb"), "Физического воспитания и спорта" },
                    { new Guid("ca42d0d8-d0ab-4ee5-b9b0-6acbc7387885"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Социально-гуманитарных дисциплин" },
                    { new Guid("cb2d93ba-258a-4178-a6d1-c5343309ee15"), new Guid("69e1105a-042f-45e4-9df8-c817e270447e"), "Высшей математики" },
                    { new Guid("d23201aa-46ed-4ea4-9dde-8e895901b913"), new Guid("7217294e-e4de-4725-a522-8d64555fe142"), "Электроники и радиофизики" },
                    { new Guid("d695edb2-9d4c-45f8-8a4b-e6a71c668fc5"), new Guid("7217294e-e4de-4725-a522-8d64555fe142"), "Электрических машин и аппаратов" },
                    { new Guid("dd0c290c-b7c4-4e64-bddd-99b32622a934"), new Guid("eb9a4659-4663-421a-97ad-e54104e751cb"), "Металлургических технологий" },
                    { new Guid("eb0f963d-0691-4c84-b093-697e8fb2b5c1"), new Guid("eb9a4659-4663-421a-97ad-e54104e751cb"), "Машин металлургического комплекса" },
                    { new Guid("ff819604-b34c-4eb8-a9b0-39426a00eedc"), new Guid("7ce42d42-826e-49a9-80c7-11575f891a7c"), "Экономики и управления" }
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
                name: "IX_Teachers_FacultyId",
                table: "Teachers",
                column: "FacultyId");

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
