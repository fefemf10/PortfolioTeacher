using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IdentityServer.Migrations.ConfigurationDb
{
    /// <inheritdoc />
    public partial class UpdateVersionMySQLComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PushedAuthorizationLifetime",
                table: "Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequirePushedAuthorization",
                table: "Clients",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PushedAuthorizationLifetime",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RequirePushedAuthorization",
                table: "Clients");
        }
    }
}
