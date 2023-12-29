using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PortfolioServer.Migrations
{
    /// <inheritdoc />
    public partial class AddPublicActivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndTimeWork",
                table: "ScienceProjects",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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

            migrationBuilder.InsertData(
                table: "Disciplines",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00afcb28-512e-4992-9ee3-dc3ebb164f70"), "Основы российской государственности" },
                    { new Guid("04dd8007-0c08-4d5c-8f4d-5c76d4ffc8b4"), "Стандатизация, сертификация и управление качеством программного обеспечения" },
                    { new Guid("09c8288e-0b18-43e7-90be-09a2291514f9"), "Прогнозирование социальноэкономических процессов" },
                    { new Guid("0bcabe5b-1ebe-4235-a2d1-803c34932e58"), "Преддипломная (производственная) практика" },
                    { new Guid("0e726a92-6e33-4cf1-bd8c-cadfc701514c"), "История России" },
                    { new Guid("14bcf215-9833-45ec-a2a4-7c3765487cdb"), "Стандартизация и сертификация товаров и услуг" },
                    { new Guid("19c2b014-32e5-41aa-b25e-3b9fcd5a0c30"), "Программная инженерия" },
                    { new Guid("1d2a2a3e-3a46-4b7d-8cd0-ab4094c7a7ff"), "Моделирование бизнеспроцессов" },
                    { new Guid("1fd69c52-e9b8-4a55-8562-3bb6d2bc56e8"), "Математический инструментарий и модели оценки бизнеса" },
                    { new Guid("20582338-bf91-42ce-8ff5-7dc933fb13f1"), "Философия" },
                    { new Guid("21a983ca-5c4e-438c-975d-84322ddb44f2"), "Развитие информационного общества" },
                    { new Guid("2470cbca-ceae-4544-959c-37dd8d7ef822"), "Теория риска и моделирование рисковых ситуаций" },
                    { new Guid("25951e2c-70cb-4756-ab3e-d6c14a02a875"), "Основы военной подготовки" },
                    { new Guid("28ff49bd-979d-47fc-b0a8-247da36abf1b"), "Основы алгоритмизации" },
                    { new Guid("2d116a74-6d5f-438e-bc00-7d665f27e942"), "Специальные главы высшей математики" },
                    { new Guid("2dea047b-c6db-415c-980c-8e3e42da854c"), "Вычислительные системы, сети, телекоммуникации" },
                    { new Guid("2f81a68b-61f0-45b4-8d16-870d24200f4e"), "Корпоративные информационные системы" },
                    { new Guid("324e61f5-fb0c-407a-83e4-2dc95d3d897c"), "Технологическая (производственная) практика" },
                    { new Guid("33c3344e-e0f3-48b0-84bd-f89e2adfa33b"), "Информационные системы и технологии в управленческой деятельности" },
                    { new Guid("4424caa1-49da-4a1d-962a-53e6ab01439e"), "Управление жизненным циклом информационных систем" },
                    { new Guid("45d6dfd7-69b9-4cc3-80dc-7612a29e8f2c"), "Ознакомительная (учебная) практика" },
                    { new Guid("4b04a29f-9047-493d-bf18-2440688b8bd8"), "Интернет технологии" },
                    { new Guid("4b855ea2-e9b4-4f47-a580-75df98083b76"), "Информатика" },
                    { new Guid("52a9585b-2ea1-4b85-b92b-a82a9647f6c6"), "Базы данных" },
                    { new Guid("5e28f7af-1b01-43c5-b7e7-bd097f8768cb"), "Дискретная математика" },
                    { new Guid("6bd9b020-e855-4cc8-8137-8354ff09abdd"), "ИТ инфраструкту рапредприятия" },
                    { new Guid("6eee4e8c-75a9-44f3-85b8-7d18ffa14422"), "Безопасность жизнедеятельности" },
                    { new Guid("8812f04f-c5e8-4150-bd06-f8c7ee89a8be"), "Научно-исследовательская работа" },
                    { new Guid("8abee24a-de5b-4292-85f7-04dc6ea8460f"), "Технологическая (учебная) практика" },
                    { new Guid("8ff555f2-1673-4380-965f-26ac77622d9c"), "Операционные системы" },
                    { new Guid("9714911a-fa18-49be-a845-8f70677e04b0"), "Правоведение" },
                    { new Guid("97b4e4ba-20f1-4257-abc1-8822bf9bc6cf"), "Основы искусственного интеллекта" },
                    { new Guid("9c107776-ca5a-4ea2-a765-79fe600caa6f"), "Русский язык и культура речи" },
                    { new Guid("a05130ac-791b-4df0-ad8d-a3b0bb8bf40e"), "Подготовка к процедуре защиты и защита выпускной квалификационной работы" },
                    { new Guid("a9b8d935-f708-4bd7-9b06-01265151361e"), "Системы поддержки принятия решений" },
                    { new Guid("ab111c73-6750-439a-a2cf-f67e36a0d435"), "Основы программирования" },
                    { new Guid("af65f157-14f5-49bc-b7d1-5f2a33b7c798"), "Технологии разработки программного продукта" },
                    { new Guid("af86bae9-1bf3-48dc-9c71-4f259dd34964"), "Теория систем и системный анализ" },
                    { new Guid("b71353d4-5e0d-44c3-bca8-fdf78a061e67"), "Физическая культура и спорт" },
                    { new Guid("b865d464-f36c-4b02-aa9f-3a9b6e57b136"), "Социология" },
                    { new Guid("b8ce0e54-847a-4c45-a392-e2ac0715408b"), "Управление проектами" },
                    { new Guid("c230a4e7-d040-415e-b897-06650d55f3c5"), "Математические методы принятия решений" },
                    { new Guid("c5c2d2c6-2bc5-4fac-92ce-4aee44bf4bf9"), "Анализ данных" },
                    { new Guid("c8dd45e2-64f2-4169-b57b-afbe743a13b1"), "Иностранный язык" },
                    { new Guid("cb03cbb7-84db-4285-ad4f-4ff9a6a78f69"), "Электронный бизнес" },
                    { new Guid("cc0dcca9-6e7e-4d7c-8db7-ea5dae76c28f"), "Экономика" },
                    { new Guid("dbd5bab4-d099-46c0-a6e3-8e3e94450318"), "Физическая культура и спорт" },
                    { new Guid("dd3a352b-d041-41bf-ab58-693704304084"), "Основы научных исследований" },
                    { new Guid("e5723c67-6a6e-41bc-92be-21e0ef4c765c"), "Математика криптографии" },
                    { new Guid("ef1b80f0-df23-4887-bb22-fcc30f3a8259"), "Психология" },
                    { new Guid("f0cb44a1-400b-40f9-8af7-904cfafeaff5"), "Исследование операций" },
                    { new Guid("fc2571d2-e0cb-4cea-8331-7e6112ad0aa5"), "Высшая математика" },
                    { new Guid("fc7c976c-d6b7-4d2e-8859-2b91930744b9"), "Численные методы" },
                    { new Guid("fff3a7ff-7884-415e-b534-ba22afabd318"), "Информационная безопасность" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PublicActivities_TeacherId",
                table: "PublicActivities",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicActivities");

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("00afcb28-512e-4992-9ee3-dc3ebb164f70"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("04dd8007-0c08-4d5c-8f4d-5c76d4ffc8b4"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("09c8288e-0b18-43e7-90be-09a2291514f9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0bcabe5b-1ebe-4235-a2d1-803c34932e58"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("0e726a92-6e33-4cf1-bd8c-cadfc701514c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("14bcf215-9833-45ec-a2a4-7c3765487cdb"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("19c2b014-32e5-41aa-b25e-3b9fcd5a0c30"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1d2a2a3e-3a46-4b7d-8cd0-ab4094c7a7ff"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("1fd69c52-e9b8-4a55-8562-3bb6d2bc56e8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("20582338-bf91-42ce-8ff5-7dc933fb13f1"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("21a983ca-5c4e-438c-975d-84322ddb44f2"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("2470cbca-ceae-4544-959c-37dd8d7ef822"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("25951e2c-70cb-4756-ab3e-d6c14a02a875"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("28ff49bd-979d-47fc-b0a8-247da36abf1b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("2d116a74-6d5f-438e-bc00-7d665f27e942"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("2dea047b-c6db-415c-980c-8e3e42da854c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("2f81a68b-61f0-45b4-8d16-870d24200f4e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("324e61f5-fb0c-407a-83e4-2dc95d3d897c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("33c3344e-e0f3-48b0-84bd-f89e2adfa33b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("4424caa1-49da-4a1d-962a-53e6ab01439e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("45d6dfd7-69b9-4cc3-80dc-7612a29e8f2c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("4b04a29f-9047-493d-bf18-2440688b8bd8"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("4b855ea2-e9b4-4f47-a580-75df98083b76"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("52a9585b-2ea1-4b85-b92b-a82a9647f6c6"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("5e28f7af-1b01-43c5-b7e7-bd097f8768cb"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("6bd9b020-e855-4cc8-8137-8354ff09abdd"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("6eee4e8c-75a9-44f3-85b8-7d18ffa14422"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8812f04f-c5e8-4150-bd06-f8c7ee89a8be"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8abee24a-de5b-4292-85f7-04dc6ea8460f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("8ff555f2-1673-4380-965f-26ac77622d9c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("9714911a-fa18-49be-a845-8f70677e04b0"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("97b4e4ba-20f1-4257-abc1-8822bf9bc6cf"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("9c107776-ca5a-4ea2-a765-79fe600caa6f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a05130ac-791b-4df0-ad8d-a3b0bb8bf40e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("a9b8d935-f708-4bd7-9b06-01265151361e"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("ab111c73-6750-439a-a2cf-f67e36a0d435"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("af65f157-14f5-49bc-b7d1-5f2a33b7c798"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("af86bae9-1bf3-48dc-9c71-4f259dd34964"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b71353d4-5e0d-44c3-bca8-fdf78a061e67"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b865d464-f36c-4b02-aa9f-3a9b6e57b136"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("b8ce0e54-847a-4c45-a392-e2ac0715408b"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c230a4e7-d040-415e-b897-06650d55f3c5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c5c2d2c6-2bc5-4fac-92ce-4aee44bf4bf9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("c8dd45e2-64f2-4169-b57b-afbe743a13b1"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("cb03cbb7-84db-4285-ad4f-4ff9a6a78f69"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("cc0dcca9-6e7e-4d7c-8db7-ea5dae76c28f"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("dbd5bab4-d099-46c0-a6e3-8e3e94450318"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("dd3a352b-d041-41bf-ab58-693704304084"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("e5723c67-6a6e-41bc-92be-21e0ef4c765c"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("ef1b80f0-df23-4887-bb22-fcc30f3a8259"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("f0cb44a1-400b-40f9-8af7-904cfafeaff5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fc2571d2-e0cb-4cea-8331-7e6112ad0aa5"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fc7c976c-d6b7-4d2e-8859-2b91930744b9"));

            migrationBuilder.DeleteData(
                table: "Disciplines",
                keyColumn: "Id",
                keyValue: new Guid("fff3a7ff-7884-415e-b534-ba22afabd318"));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "EndTimeWork",
                table: "ScienceProjects",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

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
        }
    }
}
