using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCascadeDeleting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardStudent_Students_StudentId",
                table: "AwardStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Teachers_TeacherId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalDevelopments_Teachers_TeacherId",
                table: "ProfessionalDevelopments");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Teachers_TeacherId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScienceProjects_Teachers_TeacherId",
                table: "ScienceProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Teachers_TeacherId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Teachers_TeacherId",
                table: "Works");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("047d52a8-8327-4c61-9d3c-c07ea8e086b0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0933d3b6-56ad-48ec-9d64-0eda8da495ca"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0a4e059b-f82a-43df-a0f4-2308be63fae9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0d5f77b2-bb04-4802-bca7-08d513064865"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1052553c-8701-42d7-8856-7ca9ac7e781d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("10c955a1-5f0b-4b28-a925-0a1002018d05"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1161cf75-0b13-4ba6-9ba5-9068a2a5231f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1191ce0a-0412-41b1-b4e9-e99a95a96292"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("138d8787-ea1b-4a2d-bc7d-ea20357e2671"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1820e674-784b-4132-a02a-9e57d5076154"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("2a94ab11-d4e9-49a3-a948-6e27dd213897"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("351d07cc-1231-4e5d-9994-994f8f03a6a3"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("376615b9-1738-4ad9-a3e8-4cb258fed042"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("399ef924-57ff-44de-913c-8c2adfe2ae7d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("39f5d742-9d7d-4b2d-9ce7-4f4582bbc0f4"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("3a20ef94-ea3b-466c-aa19-9197e1dd6eb2"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("3d8da6fd-f1c6-4b1f-9e76-93c21ab7f955"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("47054824-41f9-413c-9b64-546251a5d63c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("523da6af-68e3-4085-bae6-2efd946fe6d3"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("53abfd92-1bcd-4085-bb11-a961a88259a5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("5a41ac81-fffe-46ef-b20b-44314b6d5796"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("5a50856f-9087-4dfe-bcab-24ab23aa6b33"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("5e2d6aed-0d8b-4310-9adf-af265bbfc62e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("604e6e91-191c-418a-ae04-0430513f21e6"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("616ec123-59b3-4c35-aa4a-f6589a1d89a4"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("62d3a17d-e46d-4527-9f93-975092005d0d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("64626701-555e-4356-befd-c985a3d90c0a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("6783c19c-affb-4673-b078-e650de6e0725"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("68e9216d-a80c-4e68-a8b7-95d554023b9d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("6af6d05b-0458-45c2-98e5-e552530d4dba"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("82bcfe2d-d66c-4fcd-87a1-7749c7442aa7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("89147081-8697-4cc6-a5f1-dd9c4862fb41"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8a7fb6d8-d286-403f-bb80-d0a8ca627e8f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8ab32200-0348-4230-b31b-8c947cafbee5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8eba311b-76c5-47a6-858d-539388393cae"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a45d7569-79ac-483b-8c1f-5ebabe829e89"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a800d8f8-ee66-402a-b5b6-ae134e543101"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a88cd626-2d56-4cc6-93fd-b9d74824053c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b05e6b7b-036a-44f7-8024-bf1f242eaabe"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b3ad2d68-801e-43ee-b32c-b33a061f1940"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("bcb67b9a-41b7-4614-a88c-462d7a5df58a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c61bc8b3-4817-45d6-ad24-62575da07d48"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c668255c-4f46-4320-8286-c38ea70fb11f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("ca2c1cad-6872-49e3-9404-197eff47767a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("cd27d0b9-ffc9-4d33-a9dd-fa934d6dd90e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("d31150f3-03c1-45da-8bcc-63827e910ceb"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("d484aae6-a15d-4544-a989-9aa327113161"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("d93ce3a2-e6a4-4a12-a55d-c62309e05fa3"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("ead5b1a5-8b11-489a-9978-bec9e391e05d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("f0c15ee1-10f6-44fb-82a8-054034abad08"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("f93b6226-4149-4f90-8141-b823b43c5c63"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fbf7b32e-153b-4b38-919b-a2beb7fc3901"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fd60802c-f8eb-45ba-981e-3cd09b96a96a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fe17670b-eed4-453a-8a64-a57b1576e6e9"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Works",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Universities",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "ScienceProjects",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Publications",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "ProfessionalDevelopments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Dissertations",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Awards",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "AwardStudent",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0005f8d5-3f23-4cd2-af31-24f893311a47"), "Информационные системы и технологии в управленческой деятельности" },
                    { new Guid("064fabad-a8f7-4557-95f6-50ea079939e9"), "Основы научных исследований" },
                    { new Guid("078f32b1-48c0-4de3-b9bd-6d5e2706be08"), "Моделирование бизнеспроцессов" },
                    { new Guid("0af3d2bd-75d1-4c6b-8835-3e218e09df28"), "Основы искусственного интеллекта" },
                    { new Guid("12ffe8b8-01eb-4c09-81a7-7e15c911b1cb"), "История России" },
                    { new Guid("1598d07e-c99d-4839-a790-61256cb8a47f"), "Основы программирования" },
                    { new Guid("1762b005-c4d0-44b9-915c-32238e2a8210"), "Технологическая (производственная) практика" },
                    { new Guid("19da9c1f-a421-487a-bf92-16429226e00a"), "Программная инженерия" },
                    { new Guid("2041d761-3993-4b7f-ac6d-9246af5301f8"), "Электронный бизнес" },
                    { new Guid("235dc790-c49a-4b14-bc1d-017fe745b32e"), "Философия" },
                    { new Guid("28ee9963-1e42-462b-a544-a3660a0b5980"), "Корпоративные информационные системы" },
                    { new Guid("296568c4-677d-4a88-a8b9-f08090b006ee"), "Специальные главы высшей математики" },
                    { new Guid("31c592ad-61af-4edb-866e-4204fedf6848"), "Управление жизненным циклом информационных систем" },
                    { new Guid("344966da-a613-4371-83c2-db08c0395089"), "ИТ инфраструкту рапредприятия" },
                    { new Guid("35112c50-da42-4a94-9693-9062cdac15fc"), "Подготовка к процедуре защиты и защита выпускной квалификационной работы" },
                    { new Guid("3f169905-50b7-4a84-b424-140eb3946cd8"), "Основы российской государственности" },
                    { new Guid("3fb201c8-43bb-4d94-a6e9-fa9aaca2d86a"), "Стандартизация и сертификация товаров и услуг" },
                    { new Guid("48386306-691f-468b-b867-eb22ee3df0b8"), "Информатика" },
                    { new Guid("4cec87e4-cdb4-4b09-b480-6e7ee8903fd7"), "Исследование операций" },
                    { new Guid("4f4847ab-4c87-47e6-b83e-f9a012ed8491"), "Численные методы" },
                    { new Guid("52569844-396b-4ccb-b529-d9ca85a94617"), "Физическая культура и спорт" },
                    { new Guid("53ef19d2-6fae-4966-82b6-0ee4129d7497"), "Математические методы принятия решений" },
                    { new Guid("6060cdc6-fddc-43fc-80c9-132a4c5c9791"), "Интернет технологии" },
                    { new Guid("616f003d-c1f6-4219-9697-f87bd7c33d6f"), "Стандатизация, сертификация и управление качеством программного обеспечения" },
                    { new Guid("62001240-683a-4409-b5c4-ce04778d2939"), "Основы алгоритмизации" },
                    { new Guid("74b956a0-08a0-44a5-b065-d329174febe5"), "Операционные системы" },
                    { new Guid("7a098b5b-b9ef-4972-bbd4-19fb9431b99e"), "Технологическая (учебная) практика" },
                    { new Guid("7df7032d-f8ff-4bbe-b8f7-f7d6b4049464"), "Управление проектами" },
                    { new Guid("8c2e674e-b4b6-4205-aaf4-93c45706d6aa"), "Безопасность жизнедеятельности" },
                    { new Guid("8e1c394d-8d69-4756-85e5-612c5d188d70"), "Информационная безопасность" },
                    { new Guid("a4807c61-1fb1-4c4f-8a7d-4964cb38d980"), "Русский язык и культура речи" },
                    { new Guid("a78d181d-1f35-4caa-a72a-2b5ea8e6d06c"), "Экономика" },
                    { new Guid("ad2ae88a-1659-4647-b627-1cb2d2e52b82"), "Системы поддержки принятия решений" },
                    { new Guid("b3141e8f-04a4-4a11-b1bb-da23a5b63ac1"), "Преддипломная (производственная) практика" },
                    { new Guid("b6b85179-cea3-4686-9c9e-9abd3c6ef39c"), "Теория риска и моделирование рисковых ситуаций" },
                    { new Guid("b843b0b7-0856-48a1-b695-1d8896b265cb"), "Психология" },
                    { new Guid("b8fe41ba-f8fa-40e0-a74d-18b79eef077c"), "Дискретная математика" },
                    { new Guid("c3dcc704-b393-46e0-92a7-9019f0c62c1a"), "Анализ данных" },
                    { new Guid("c3e3eacd-8ac1-4bb6-b448-eaa6d7588b96"), "Социология" },
                    { new Guid("c4183262-cb6e-4d9e-8f28-8b2edd2599ae"), "Иностранный язык" },
                    { new Guid("c4758bab-4ddd-48b1-978c-0afafd910bec"), "Прогнозирование социальноэкономических процессов" },
                    { new Guid("c6558dec-2c27-4422-a857-dfdfdd234c85"), "Вычислительные системы, сети, телекоммуникации" },
                    { new Guid("c8e32c09-4f2e-44aa-a5f6-ac2df567e77a"), "Основы военной подготовки" },
                    { new Guid("d2b85abd-a623-4249-9484-5021e05124a5"), "Физическая культура и спорт" },
                    { new Guid("d66d9b36-6be7-48ec-8b32-44f6a1db29e7"), "Математический инструментарий и модели оценки бизнеса" },
                    { new Guid("d6fc0fac-954a-4086-b38b-895b62726500"), "Ознакомительная (учебная) практика" },
                    { new Guid("deee41c0-b76f-46a3-a63c-3bb215ecb188"), "Научно-исследовательская работа" },
                    { new Guid("e1286a19-96cc-4c8f-add9-7bd03085c5ef"), "Развитие информационного общества" },
                    { new Guid("e1975a73-2028-4967-adc7-0423cbd3a00d"), "Математика криптографии" },
                    { new Guid("e3c3d704-3250-4488-aa6a-ed5725a92944"), "Базы данных" },
                    { new Guid("ef22b2fe-e6e3-47ff-bed7-dd56ffc6e3f0"), "Правоведение" },
                    { new Guid("f0c3415b-470e-4c6e-ae12-9af082d772c6"), "Теория систем и системный анализ" },
                    { new Guid("f3c3b2f1-0170-42a4-9524-9f9f9b127fc2"), "Высшая математика" },
                    { new Guid("f65a0795-2b10-44ee-8b12-aa5f23753270"), "Технологии разработки программного продукта" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AwardStudent_Students_StudentId",
                table: "AwardStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Teachers_TeacherId",
                table: "Awards",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalDevelopments_Teachers_TeacherId",
                table: "ProfessionalDevelopments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Teachers_TeacherId",
                table: "Publications",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ScienceProjects_Teachers_TeacherId",
                table: "ScienceProjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Teachers_TeacherId",
                table: "Universities",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Teachers_TeacherId",
                table: "Works",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardStudent_Students_StudentId",
                table: "AwardStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_Awards_Teachers_TeacherId",
                table: "Awards");

            migrationBuilder.DropForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalDevelopments_Teachers_TeacherId",
                table: "ProfessionalDevelopments");

            migrationBuilder.DropForeignKey(
                name: "FK_Publications_Teachers_TeacherId",
                table: "Publications");

            migrationBuilder.DropForeignKey(
                name: "FK_ScienceProjects_Teachers_TeacherId",
                table: "ScienceProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Teachers_TeacherId",
                table: "Universities");

            migrationBuilder.DropForeignKey(
                name: "FK_Works_Teachers_TeacherId",
                table: "Works");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0005f8d5-3f23-4cd2-af31-24f893311a47"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("064fabad-a8f7-4557-95f6-50ea079939e9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("078f32b1-48c0-4de3-b9bd-6d5e2706be08"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0af3d2bd-75d1-4c6b-8835-3e218e09df28"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("12ffe8b8-01eb-4c09-81a7-7e15c911b1cb"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1598d07e-c99d-4839-a790-61256cb8a47f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1762b005-c4d0-44b9-915c-32238e2a8210"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("19da9c1f-a421-487a-bf92-16429226e00a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("2041d761-3993-4b7f-ac6d-9246af5301f8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("235dc790-c49a-4b14-bc1d-017fe745b32e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("28ee9963-1e42-462b-a544-a3660a0b5980"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("296568c4-677d-4a88-a8b9-f08090b006ee"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("31c592ad-61af-4edb-866e-4204fedf6848"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("344966da-a613-4371-83c2-db08c0395089"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("35112c50-da42-4a94-9693-9062cdac15fc"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("3f169905-50b7-4a84-b424-140eb3946cd8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("3fb201c8-43bb-4d94-a6e9-fa9aaca2d86a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("48386306-691f-468b-b867-eb22ee3df0b8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("4cec87e4-cdb4-4b09-b480-6e7ee8903fd7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("4f4847ab-4c87-47e6-b83e-f9a012ed8491"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("52569844-396b-4ccb-b529-d9ca85a94617"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("53ef19d2-6fae-4966-82b6-0ee4129d7497"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("6060cdc6-fddc-43fc-80c9-132a4c5c9791"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("616f003d-c1f6-4219-9697-f87bd7c33d6f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("62001240-683a-4409-b5c4-ce04778d2939"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("74b956a0-08a0-44a5-b065-d329174febe5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("7a098b5b-b9ef-4972-bbd4-19fb9431b99e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("7df7032d-f8ff-4bbe-b8f7-f7d6b4049464"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8c2e674e-b4b6-4205-aaf4-93c45706d6aa"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8e1c394d-8d69-4756-85e5-612c5d188d70"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a4807c61-1fb1-4c4f-8a7d-4964cb38d980"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a78d181d-1f35-4caa-a72a-2b5ea8e6d06c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("ad2ae88a-1659-4647-b627-1cb2d2e52b82"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b3141e8f-04a4-4a11-b1bb-da23a5b63ac1"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b6b85179-cea3-4686-9c9e-9abd3c6ef39c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b843b0b7-0856-48a1-b695-1d8896b265cb"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b8fe41ba-f8fa-40e0-a74d-18b79eef077c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c3dcc704-b393-46e0-92a7-9019f0c62c1a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c3e3eacd-8ac1-4bb6-b448-eaa6d7588b96"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c4183262-cb6e-4d9e-8f28-8b2edd2599ae"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c4758bab-4ddd-48b1-978c-0afafd910bec"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c6558dec-2c27-4422-a857-dfdfdd234c85"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c8e32c09-4f2e-44aa-a5f6-ac2df567e77a"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("d2b85abd-a623-4249-9484-5021e05124a5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("d66d9b36-6be7-48ec-8b32-44f6a1db29e7"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("d6fc0fac-954a-4086-b38b-895b62726500"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("deee41c0-b76f-46a3-a63c-3bb215ecb188"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("e1286a19-96cc-4c8f-add9-7bd03085c5ef"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("e1975a73-2028-4967-adc7-0423cbd3a00d"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("e3c3d704-3250-4488-aa6a-ed5725a92944"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("ef22b2fe-e6e3-47ff-bed7-dd56ffc6e3f0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("f0c3415b-470e-4c6e-ae12-9af082d772c6"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("f3c3b2f1-0170-42a4-9524-9f9f9b127fc2"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("f65a0795-2b10-44ee-8b12-aa5f23753270"));

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Works",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Universities",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "ScienceProjects",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Publications",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "ProfessionalDevelopments",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Dissertations",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "TeacherId",
                table: "Awards",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "AwardStudent",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AwardStudent_Students_StudentId",
                table: "AwardStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Awards_Teachers_TeacherId",
                table: "Awards",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dissertations_Teachers_TeacherId",
                table: "Dissertations",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalDevelopments_Teachers_TeacherId",
                table: "ProfessionalDevelopments",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_Teachers_TeacherId",
                table: "Publications",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Works_Teachers_TeacherId",
                table: "Works",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
